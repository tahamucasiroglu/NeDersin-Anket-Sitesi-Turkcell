using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using NeDersin.WepAPI.StaticMethods;
using System.Text;

namespace NeDersin.WepAPI.Extensions
{
    static public class AddAuthenticationExtension
    {
        static public IServiceCollection AddCookie(this IServiceCollection services)
        {
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(options =>
            {
                options.LoginPath = "/Membership/Login"; // Kullanıcı giriş yapmadıysa yönlendirilecek yol
                options.LogoutPath = "/Membership/Logout"; // Çıkış yapılacak yol
                options.ExpireTimeSpan = TimeSpan.FromMinutes(15); // Cookie süresi (15 dakika)
            });
            return services;
        }

        static public IServiceCollection AddPolicy(this IServiceCollection services)
        {
            services.AddAuthorization(options =>
            {
                options.AddPolicy(StaticHelperMethods.Admin, policy => policy.RequireRole(StaticHelperMethods.Admin));
                options.AddPolicy(StaticHelperMethods.Anketor, policy => policy.RequireRole(StaticHelperMethods.Admin, StaticHelperMethods.Anketor));
                options.AddPolicy(StaticHelperMethods.Kullanici, policy => policy.RequireRole(StaticHelperMethods.Admin, StaticHelperMethods.Anketor, StaticHelperMethods.Kullanici));
            });

            return services;
        }

        static public IServiceCollection AddJWT(this IServiceCollection services)
        {
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false; // HTTPS gerektiren durumları devre dışı bırakmak için
                options.SaveToken = true; // Token'ı kaydetmek için
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidIssuer = "client", // İstek oluşturan tarafın adı
                    ValidAudience = "server", // İsteğin hedeflendiği tarafın adı
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("YourSecretKey12345678")) // Secret key
                };
            });

            return services;
        }


    }
}
