using NeDersin.DTOs.Concrete.Response.Models.ReturnModels;
using NeDersin.DTOs.Extensions;
using NeDersin.WepAPI.Enumeration.HateoasEnumeration;
using Newtonsoft.Json.Linq;
using System.Text.Json.Nodes;

namespace NeDersin.WepAPI.Middlewares
{

    public class DetectBadWordsMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly List<string> stringList = new List<string>() { "Mal", "M4l", "mal", "m4l", "Aptal", "aptal", "4ptal"};
        private readonly HateoasEnumeration hateoasEnumeration;
        public DetectBadWordsMiddleware(RequestDelegate next, HateoasEnumeration hateoasEnumeration)
        {
            _next = next;
            this.hateoasEnumeration = hateoasEnumeration;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (context.Request.Method == "GET")
            {
                var jsonBody = (string?)context.Items["JsonBody"];
                if (jsonBody != null)
                {
                    bool status = false;
                    foreach (string str in stringList)
                    {
                        if (jsonBody.Contains(str)) { status = true; break; }
                    }
                    if(status)
                    {
                        Console.WriteLine("\n\n\n\n\nKÜFÜR VAR\n\n\n\n\n");
                        //context.Response.Headers.Add("Content-Type", "application/json; charset=utf-8");
                        //await context.Response.WriteAsJsonAsync(
                        //        ("Hata: Argo Kelimeler Tespit Edildi Düzgün Konuş Hımmmıına",
                        //        hateoasEnumeration.AllControllerHateoas
                        //        ));
                        await context.Response.WriteAsync("Hata: Argo Kelimeler Tespit Edildi Düzgün Konuş Hımmmıına \n");
                        return;
                    }
                }
            }

            await _next(context);
        }
    }
}
