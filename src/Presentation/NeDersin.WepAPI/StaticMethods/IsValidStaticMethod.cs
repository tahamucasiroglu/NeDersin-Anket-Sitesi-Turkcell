using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using NeDersin.DTOs.Concrete.Response.Models.HateoasModels;
using NeDersin.DTOs.Concrete.Response.Models.ReturnModels;

namespace NeDersin.WepAPI.StaticMethods
{
    static public partial class StaticHelperMethods
    {
        /// <summary>
        /// Eğer modelstate isvalid doğru değilse attribute lerden hataları çekerek error döndürür
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ModelState"></param>
        /// <param name="hateoasModel"></param>
        /// <returns></returns>
        static public BadRequestObjectResult ReturnError<T>(ModelStateDictionary ModelState, HateoasModel hateoasModel)
        {
            string errorText = "";
            foreach (var key in ModelState.Keys)
            {
                errorText += ModelState[key]?.Errors.FirstOrDefault()?.ErrorMessage + "\n";
            }
            return new BadRequestObjectResult(new ErrorReturnToClientModel<T>(errorText, default, hateoasModel));
        }
    }
}
