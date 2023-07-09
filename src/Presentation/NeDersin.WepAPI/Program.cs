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
//    options.IdleTimeout = TimeSpan.FromMinutes(15); // Oturum zaman a��m� s�resi (15 dakika)
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

#region Test ��in Db olu�turma Kodu
//using (var context = app.Services.CreateScope().ServiceProvider.GetRequiredService<NeDersinDbContext>())
//{
//    context.Database.EnsureCreated();
//}
//Console.WriteLine("E�er sadece db olu�turmak istersen buraya breakpoint koy gelince program� kapat");
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

#region Test edilecek 15 dk sonra direk ��k��
/*
 app.Use(async (context, next) =>
{
    var user = context.User;

    if (user.Identity.IsAuthenticated)
    {
        var sessionStartedAt = context.Session.GetString("SessionStartedAt");

        if (string.IsNullOrEmpty(sessionStartedAt))
        {
            // E�er oturum ba�lang�� zaman� bo�sa (yani kullan�c� yeni oturum a�t�ysa),
            // oturum ba�lang�� zaman�n� kaydediyoruz.
            context.Session.SetString("SessionStartedAt", DateTime.UtcNow.ToString());
        }
        else
        {
            // Oturum ba�lang�� zaman� kaydedilmi�se, �u anki zaman ile kar��la�t�rarak
            // oturumun 15 dakikadan fazla s�redir i�lemsiz oldu�unu kontrol ediyoruz.
            var startTime = DateTime.Parse(sessionStartedAt);
            var currentTime = DateTime.UtcNow;

            if ((currentTime - startTime).TotalMinutes > 15)
            {
                // E�er oturum 15 dakikadan fazla s�redir i�lemsizse, oturumu sonland�r�yoruz.
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
