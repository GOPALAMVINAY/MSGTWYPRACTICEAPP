namespace APIGATEWAY
{
    public class GatewayMiddleware
    {
        private readonly RequestDelegate _requestdelegate;

        public GatewayMiddleware(RequestDelegate requestdelegate)
        {
            _requestdelegate = requestdelegate;
        }

        public async Task InvokeAsync(HttpContext context)
        {

            context.Request.Headers["referrer"] = "api-gateway";
            await _requestdelegate(context);
        }
    }

}
