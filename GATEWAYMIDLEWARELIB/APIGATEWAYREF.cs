using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
namespace MIDDLEWARELIB
{
    public class APIGATEWAYREF
    {
        private readonly RequestDelegate _requestdelegate;

        public APIGATEWAYREF(RequestDelegate requestdelegate)
        {
            _requestdelegate = requestdelegate;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            string referrer = context.Request.Headers["referrer"].ToString();
            if (string.IsNullOrEmpty(referrer))
            {
                context.Response.StatusCode = StatusCodes.Status403Forbidden;
                await context.Response.WriteAsync("you are not authorized to call this API");
                return;
            }
            else
            
                await _requestdelegate(context);
            
                
        }

    }
}
