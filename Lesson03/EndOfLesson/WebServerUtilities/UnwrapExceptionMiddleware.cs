using System;
using System.Runtime.ExceptionServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace WebServerUtilities
{
    public class UnwrapExceptionMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                ExceptionDispatchInfo.Throw(ex.GetBaseException());
            }
        }
    }
}
