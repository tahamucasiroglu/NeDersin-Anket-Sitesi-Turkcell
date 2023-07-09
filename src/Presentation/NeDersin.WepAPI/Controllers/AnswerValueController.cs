using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NeDersin.DTOs.Concrete.Request.Add;
using NeDersin.DTOs.Concrete.Request.Delete;
using NeDersin.DTOs.Concrete.Request.Update;
using NeDersin.DTOs.Concrete.Response.Get;
using NeDersin.DTOs.Concrete.Response.Models.MethodModels;
using NeDersin.ReturnModel.Abstract;
using NeDersin.Services.Service.Abstract;
using NeDersin.Services.Service.Concrete;
using NeDersin.WepAPI.Controllers.Base;
using NeDersin.WepAPI.Enumeration.HateoasEnumeration;
using NeDersin.WepAPI.Filters;
using NeDersin.WepAPI.StaticMethods;
using NeDersin.WepAPI.StaticMethods.StaticAttributes;

namespace NeDersin.WepAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AnswerValueController : BasePostController<AddAnswerValueRequestDTO, UpdateAnswerValueRequestDTO, DeleteAnswerValueRequestDTO, GetAnswerValueResponseDTO>
    {
        private readonly IAnswerValueService answerValueService;

        public AnswerValueController(IAnswerValueService answerValueService, HateoasEnumeration hateoasEnumeration, ILogger<AnswerValueController> logger) : base(answerValueService, hateoasEnumeration.GetAnswerControllerHateoas, logger)
        {
            this.answerValueService = answerValueService;
        }

        [HttpGet("[action]")]
        [ServiceFilter(typeof(LogFilterAttribute))]
        [Authorize]
        public IActionResult GetById([FromBody] IdModel Id)
        {
            if (!ModelState.IsValid) return ModelStateNonValid<IdModel>(nameof(GetById));
            IReturnModel<GetAnswerValueResponseDTO> result = answerValueService.GetById(Id.Id);
            LogResultError(result);
            return StaticHelperMethods.SolveResult(result, hateoasModel);

        }

        [HttpGet("[action]")]
        [ServiceFilter(typeof(LogFilterAttribute))]
        [Authorize]
        public IActionResult GetByName([FromBody] StringValueModel Name)
        {
            if (!ModelState.IsValid) return ModelStateNonValid<StringValueModel>(nameof(GetByName));
            IReturnModel<GetAnswerValueResponseDTO> result = answerValueService.GetByName(Name.Value);
            LogResultError(result);
            return StaticHelperMethods.SolveResult(result, hateoasModel);

        }


    }
}
