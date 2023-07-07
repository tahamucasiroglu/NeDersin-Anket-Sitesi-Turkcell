using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NeDersin.DTOs.Concrete.Request.Add;
using NeDersin.DTOs.Concrete.Request.Delete;
using NeDersin.DTOs.Concrete.Request.Update;
using NeDersin.DTOs.Concrete.Response.Get;
using NeDersin.DTOs.Concrete.Response.Models.MethodModels;
using NeDersin.Services.Service.Abstract;
using NeDersin.WepAPI.Controllers.Base;
using NeDersin.WepAPI.Enumeration.HateoasEnumeration;
using NeDersin.WepAPI.Filters;
using NeDersin.WepAPI.StaticMethods;

namespace NeDersin.WepAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserStatusAsyncController : BasePostController<AddUserStatusRequestDTO, UpdateUserStatusRequestDTO, DeleteUserStatusRequestDTO, GetUserStatusResponseDTO>
    {
        private readonly IUserStatusService userStatusService;
        public UserStatusAsyncController(IUserStatusService userStatusService, HateoasEnumeration hateoasEnumeration, ILogger<UserStatusController> logger) : base(userStatusService, hateoasEnumeration.GetUserStatusControllerHateoas, logger)
        {
            this.userStatusService = userStatusService;
        }

        [HttpGet("[action]")]

        [ServiceFilter(typeof(LogFilterAttribute))]
        public async Task<IActionResult> GetById([FromBody] IdModel Id)
        {
            if (!ModelState.IsValid) return ModelStateNonValid<IdModel>(nameof(GetById));
            var result = await userStatusService.GetByIdAsync(Id.Id);
            LogResultError(result);
            return StaticHelperMethods.SolveResult(result, hateoasModel);
        }
        [HttpGet("[action]")]

        [ServiceFilter(typeof(LogFilterAttribute))]
        public async Task<IActionResult> GetAll()
        {
            if (!ModelState.IsValid) return ModelStateNonValid<IEnumerable<GetUserStatusResponseDTO>>(nameof(GetAll));
            var result = await userStatusService.GetAllAsync();
            LogResultError(result);
            return StaticHelperMethods.SolveResult(result, hateoasModel);
        }

    }
}
