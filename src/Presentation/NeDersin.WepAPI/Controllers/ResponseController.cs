using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NeDersin.DTOs.Concrete.Models;
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
    [AllowAnonymous]
    public class ResponseController : BasePostController<AddResponseRequestDTO, UpdateResponseRequestDTO, DeleteResponseRequestDTO, GetResponseResponseDTO>
    {
        private readonly IResponseService responseService;
        public ResponseController(IResponseService responseService, HateoasEnumeration hateoasEnumeration, ILogger<ResponseController> logger) : base(responseService, hateoasEnumeration.GetResponseControllerHateoas, logger)
        {
            this.responseService = responseService;
        }

        [HttpGet("[action]")]
        [ServiceFilter(typeof(LogFilterAttribute))]
        public IActionResult GetById([FromBody] IdModel Id)
        {
            if (!ModelState.IsValid) return ModelStateNonValid<IdModel>(nameof(GetById));

            IReturnModel<GetResponseResponseDTO> result = responseService.GetById(Id.Id);
            LogResultError(result);
            return StaticHelperMethods.SolveResult(result, hateoasModel);
        }

        [HttpGet("[action]")]
        [ServiceFilter(typeof(LogFilterAttribute))]
        public IActionResult GetByQuestionId([FromBody] IdModel QuestionId)
        {
            if (!ModelState.IsValid) return ModelStateNonValid<IdModel>(nameof(GetByQuestionId));
            IReturnModel<IEnumerable<GetResponseResponseDTO>> result = responseService.GetByQuestionId(QuestionId.Id);
            LogResultError(result);
            return StaticHelperMethods.SolveResult(result, hateoasModel);
        }

        [HttpGet("[action]")]
        [ServiceFilter(typeof(LogFilterAttribute))]
        public IActionResult GetByUserId([FromBody] IdModel UserId)
        {
            if (!ModelState.IsValid) return ModelStateNonValid<IdModel>(nameof(GetByUserId));
            IReturnModel<IEnumerable<GetResponseResponseDTO>> result = responseService.GetByUserId(UserId.Id);
            LogResultError(result);
            return StaticHelperMethods.SolveResult(result, hateoasModel);
        }
    }
}
