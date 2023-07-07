using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NeDersin.DTOs.Concrete.Request.Add;
using NeDersin.DTOs.Concrete.Request.Delete;
using NeDersin.DTOs.Concrete.Request.Update;
using NeDersin.DTOs.Concrete.Response.Get;
using NeDersin.DTOs.Concrete.Response.Models.MethodModels;
using NeDersin.ReturnModel.Abstract;
using NeDersin.Services.Service.Abstract;
using NeDersin.WepAPI.Controllers.Base;
using NeDersin.WepAPI.Enumeration.HateoasEnumeration;
using NeDersin.WepAPI.Filters;
using NeDersin.WepAPI.StaticMethods;

namespace NeDersin.WepAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserAsyncController : BaseController
    {
        private readonly IUserService userService;
        public UserAsyncController(IUserService userService, HateoasEnumeration hateoasEnumeration, ILogger<UserController> logger) : base(hateoasEnumeration.GetUserControllerHateoas, logger)
        {
            this.userService = userService;
        }

        [HttpGet("[action]")]
        [ServiceFilter(typeof(LogFilterAttribute))]
        public async Task<IActionResult> GetById([FromBody] IdModel id)
        {
            if (!ModelState.IsValid) return ModelStateNonValid<IdModel>(nameof(GetById));
            var result = await userService.GetByIdAsync(id.Id);
            LogResultError(result);
            return StaticHelperMethods.SolveResult(result, hateoasModel);
        }

        [HttpGet("[action]")]
        [ServiceFilter(typeof(LogFilterAttribute))]
        public async Task<IActionResult> GetByName([FromBody] StringValueModel name)
        {
            if (!ModelState.IsValid) return ModelStateNonValid<StringValueModel>(nameof(GetByName));
            var result = await userService.GetByNameAsync(name.Value);
            LogResultError(result);
            return StaticHelperMethods.SolveResult(result, hateoasModel);
        }

        [HttpGet("[action]")]
        [ServiceFilter(typeof(LogFilterAttribute))]
        public async Task<IActionResult> CheckPassword([FromBody] UserCheckPasswordModel user)
        {
            if (!ModelState.IsValid) return ModelStateNonValid<UserCheckPasswordModel>(nameof(CheckPassword));

            if (user.Id != null)
            {
                IReturnModel<bool> result = await userService.CheckPasswordAsync(user.Id ?? 0, user.Password); //sırf uyarı vermesin diye yoksa zaten kontrollerden dolayı Id BURADA boş olamaz
                LogResultError(result);
                return StaticHelperMethods.SolveResult(result, hateoasModel);
            }
            else
            {
                IReturnModel<bool> result = await userService.CheckPasswordAsync(user.Email ?? "", user.Password); //sırf uyarı vermesin diye yoksa zaten kontrollerden dolayı email BURADA boş olamaz
                LogResultError(result);
                return StaticHelperMethods.SolveResult(result, hateoasModel);
            }
            
        }





    }
}
