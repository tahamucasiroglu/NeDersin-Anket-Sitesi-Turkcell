using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace NeDersin.WepAPI.StaticMethods.StaticAttributes
{
    public class KullaniciAuthorizeAttribute : AuthorizeAttribute
    {
        public KullaniciAuthorizeAttribute()
        {
            Roles = StaticHelperMethods.Kullanici;
        }
    }
}
