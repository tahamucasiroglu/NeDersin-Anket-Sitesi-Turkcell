using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace NeDersin.WepAPI.StaticMethods.StaticAttributes
{
    public class AnketorAuthorizeAttribute : AuthorizeAttribute
    {
        public AnketorAuthorizeAttribute()
        {
            Roles = StaticHelperMethods.Anketor;
        }
    }
}
