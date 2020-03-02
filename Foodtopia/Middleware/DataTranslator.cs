using System.IO;
using System.Text;
using System.Threading.Tasks;
using Common.Cryptography.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace Foodtopia.Middleware
{
    /// <summary>
    /// Secure data with special header
    /// </summary>
    public class DataTranslator
    {
        private readonly RequestDelegate _next;
        private readonly ICryptographyService _securityService;
        private readonly IConfiguration _configuration;
        public DataTranslator(RequestDelegate next, ICryptographyService securityService, IConfiguration configuration)
        {
            _next = next;
            _securityService = securityService;
            _configuration = configuration;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (string.IsNullOrWhiteSpace(context.Request.ContentType))
            {
                //context.Response.StatusCode = (int) HttpStatusCode.BadRequest;
                //context.GetEndpoint();

                context.Request.ContentType = "text/plain";
                await _next(context);
            }
            
            var secureHeader = _configuration.GetValue<string>("AppSetting:SecureHeader"); // default is ft-ejson

            if (context.Request.ContentType != secureHeader)
                await _next(context);

            var encryptionKey = _configuration.GetValue<string>("AppSetting:EncryptionKey");

            if (context.Response.ContentLength.GetValueOrDefault(0) == 0) // Input Request
            {
                using (var reader = new StreamReader(context.Request.Body, Encoding.UTF8))
                {
                    var cipherBody = reader.ReadToEnd();

                    var body = _securityService.Decrypt(cipherBody, encryptionKey);

                    context.Request.Body.Flush();

                    context.Request.Body.Write(Encoding.UTF8.GetBytes(body), 0, body.Length);
                }

                await _next(context);
            }
            else // Output Response
            {
                using (var reader = new StreamReader(context.Response.Body, Encoding.UTF8))
                {
                    var body = reader.ReadToEnd();
                    var cipherBody = _securityService.Encrypt(body, encryptionKey);

                    context.Response.Body.Flush();

                    context.Response.Body.Write(Encoding.UTF8.GetBytes(cipherBody), 0, cipherBody.Length);
                    context.Response.ContentType = "ft-ejson";
                }

                await _next(context);
            }
        }
    }
}