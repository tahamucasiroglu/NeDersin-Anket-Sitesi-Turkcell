using Microsoft.AspNetCore.Authorization;

namespace NeDersin.WepAPI.StaticMethods.StaticAttributes
{
    public class AdminAuthorizeAttribute : AuthorizeAttribute
    {
        public AdminAuthorizeAttribute() 
        {
            Roles = StaticHelperMethods.Admin;
        }
    }
}
