using Hangfire;
using Hangfire.SqlServer;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.Configuration;
using NeDersin.Services.Hangfire;
using NeDersin.Services.Mappings;
using NeDersin.Services.Service.Abstract.Base;
using NeDersin.Services.Service.Concrete;
using NeDersin.WepAPI.Extensions;

var builder = WebApplication.CreateBuilder(args);

string? connectionString = builder.Configuration.GetConnectionString("NeDersinDbContext");
GlobalConfiguration.Configuration.UseSqlServerStorage(connectionString, new SqlServerStorageOptions { QueuePollInterval = TimeSpan.FromSeconds(1) });
builder.Services.AddControllers();

builder.Services.AddAutoMapper(typeof(MapProfile));

//builder.Services.AddSession(options =>
//{
//    options.IdleTimeout = TimeSpan.FromMinutes(15); // Oturum zaman aþýmý süresi (15 dakika)
//    //options.Cookie.HttpOnly = true;
//    //options.Cookie.IsEssential = true;
//});

builder.Services.AddCookie();//Extension
builder.Services.AddPolicy();//Extension
builder.Services.AddJWT();//Extension

builder.Services.AddCustomHangfireExtension(connectionString ?? "");


builder.Services.AddControllers(
    options =>
    {
        options.SuppressAsyncSuffixInActionNames = false;
    }).ConfigureApiBehaviorOptions(options =>
    {
        options.SuppressModelStateInvalidFilter = true;
    });




// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Logging.SetMinLevelToWarning();


builder.Services.AddScopes(); //Extension
builder.Services.AddSingletons(); //Extension
builder.Services.AddContext(connectionString); //Extension
builder.Services.AddLoggerToService(); //Extension
builder.Services.AddAuthentication();

var app = builder.Build();

app.UsePathBase("/");

#region Test Ýçin Db oluþturma Kodu
//using (var context = app.Services.CreateScope().ServiceProvider.GetRequiredService<NeDersinDbContext>())
//{
//    context.Database.EnsureCreated();
//}
//Console.WriteLine("Eðer sadece db oluþturmak istersen buraya breakpoint koy gelince programý kapat");
#endregion

app.AddMiddlewares(); //extension

//app.Services.DeleteDbIfExist(); //Extension
app.Services.CheckDb(); //Extension
//app.Services.TestDb(); //Extension
app.UseHangfireDashboard();
BackgroundJob.Enqueue<SurveyIsEndCheckHangfire>(x => x.CheckSurveys());
BackgroundJob.Schedule<SurveyIsEndCheckHangfire>(x => x.CheckSurveys(),DateTimeOffset.MaxValue);
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

#region Test edilecek 15 dk sonra direk çýkýþ
/*
 app.Use(async (context, next) =>
{
    var user = context.User;

    if (user.Identity.IsAuthenticated)
    {
        var sessionStartedAt = context.Session.GetString("SessionStartedAt");

        if (string.IsNullOrEmpty(sessionStartedAt))
        {
            // Eðer oturum baþlangýç zamaný boþsa (yani kullanýcý yeni oturum açtýysa),
            // oturum baþlangýç zamanýný kaydediyoruz.
            context.Session.SetString("SessionStartedAt", DateTime.UtcNow.ToString());
        }
        else
        {
            // Oturum baþlangýç zamaný kaydedilmiþse, þu anki zaman ile karþýlaþtýrarak
            // oturumun 15 dakikadan fazla süredir iþlemsiz olduðunu kontrol ediyoruz.
            var startTime = DateTime.Parse(sessionStartedAt);
            var currentTime = DateTime.UtcNow;

            if ((currentTime - startTime).TotalMinutes > 15)
            {
                // Eðer oturum 15 dakikadan fazla süredir iþlemsizse, oturumu sonlandýrýyoruz.
                await context.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                context.Session.Clear();
                return;
            }
        }
    }

    await next.Invoke();
});
 */
#endregion

app.MapControllers();

app.Run();
