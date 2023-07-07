namespace NeDersin.WepAPI.Middlewares
{
    public class JsonBodyCaughtMiddleware
    {

        private readonly RequestDelegate _next;

        public JsonBodyCaughtMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            if (context.Request.Method == "GET" && (context.Request.ContentType ?? "").StartsWith("application/json"))
            {
                var originalBody = context.Request.Body;
                var requestBodyStream = new MemoryStream();
                    await originalBody.CopyToAsync(requestBodyStream);
                    requestBodyStream.Seek(0, SeekOrigin.Begin);

                    using (var streamReader = new StreamReader(requestBodyStream))
                    {
                        var jsonBody = await streamReader.ReadToEndAsync();
                        context.Items["JsonBody"] = jsonBody;

                        // İsteğin gövdesini geri yükle
                        requestBodyStream.Seek(0, SeekOrigin.Begin);
                        context.Request.Body = requestBodyStream;

                        await _next(context);
                    }
                    context.Request.Body = originalBody;
                    requestBodyStream.Dispose();
            }
            else
            {
                await _next(context);
            }
        }

    }

}
