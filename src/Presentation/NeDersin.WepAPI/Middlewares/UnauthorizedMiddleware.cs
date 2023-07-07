namespace NeDersin.WepAPI.Middlewares
{
    public class UnauthorizedMiddleware
    {
        private readonly RequestDelegate _next;

        public UnauthorizedMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            await _next(context);

            if (context.Response.StatusCode == 401)
            {
                var response = new { message = "Yetkisiz giriş." };
                await context.Response.WriteAsJsonAsync(response);
            }
        }
    }
}
