using System.IO;
using System.Text;
using System.Threading.Tasks;
using Authentication.Service.IService;
using Microsoft.AspNetCore.Http;

namespace Foodtopia.Middleware
{
    /// <summary>
    /// Secure data with special header
    /// </summary>
    public class DataTranslator
    {
        private readonly RequestDelegate _next;
        private readonly ISecurityService _securityService;

        public DataTranslator(RequestDelegate next, ISecurityService securityService)
        {
            _next = next;
            _securityService = securityService;
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

            if (context.Request.ContentType != "ft-ejson") //TODO: Read this key from app setting json
                await _next(context);

            if (context.Response.ContentLength.GetValueOrDefault(0) == 0) // Input Request
            {
                using (var reader = new StreamReader(context.Request.Body, Encoding.UTF8))
                {
                    var cipherBody = reader.ReadToEnd();

                    var body = _securityService.Decrypt(cipherBody, ""); //TODO: Read this key from app setting json

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

                    var cipherBody = _securityService.Encrypt(body, ""); //TODO: Read this key from app setting json

                    context.Response.Body.Flush();

                    context.Response.Body.Write(Encoding.UTF8.GetBytes(cipherBody), 0, cipherBody.Length);
                    context.Response.ContentType = "ft-ejson";
                }

                await _next(context);
            }
        }
    }
}