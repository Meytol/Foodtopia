using System;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Foodtopia.Middleware
{
    public class CheckAuthenticationSession
    {
        private readonly RequestDelegate _next;
        private readonly string _isAuthenticationChecked;
        public CheckAuthenticationSession(RequestDelegate next)
        {
            _next = next;
            _isAuthenticationChecked = "IsAuthenticationChecked";
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                if (context.Session.TryGetValue(_isAuthenticationChecked, out var isAuthenticationCheckedBytes))
                {
                    var isTrueString = Encoding.UTF8.GetString(isAuthenticationCheckedBytes);

                    if (bool.Parse(isTrueString))
                    {
                        context.Session.Remove(_isAuthenticationChecked);
                    }
                    else
                    {

                    }
                }
                else
                {
                    var falseString = bool.FalseString;
                    var buffer = Encoding.UTF8.GetBytes(falseString);

                    context.Session.Set(_isAuthenticationChecked, buffer);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }



            await _next(context);
            return;
        }
    }
}