using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NeDersin.DTOs.Concrete.Request.Add;
using NeDersin.DTOs.Concrete.Request.Delete;
using NeDersin.DTOs.Concrete.Request.Update;
using NeDersin.DTOs.Concrete.Response.Get;
using NeDersin.DTOs.Concrete.Response.Models.MethodModels;
using NeDersin.Entities.Concrete.Entities;
using NeDersin.ReturnModel.Abstract;
using NeDersin.Services.Service.Abstract;
using NeDersin.WepAPI.Controllers.Base;
using NeDersin.WepAPI.Enumeration.HateoasEnumeration;
using NeDersin.WepAPI.Filters;
using NeDersin.WepAPI.StaticMethods;
using NeDersin.WepAPI.StaticMethods.StaticAttributes;

namespace NeDersin.WepAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    //[ApiExplorerSettings(GroupName = "v1")]
    public class AnswerAsyncController : BasePostController<AddAnswerRequestDTO, UpdateAnswerRequestDTO, DeleteAnswerRequestDTO, GetAnswerResponseDTO>
    {
        private readonly IAnswerService answerService;

        public AnswerAsyncController(IAnswerService answerService, HateoasEnumeration hateoasEnumeration, ILogger<AnswerController> logger) : base(answerService, hateoasEnumeration.GetAnswerControllerHateoas, logger)
        {
            this.answerService = answerService;
        }

        [HttpGet("[action]")]
        [ServiceFilter(typeof(LogFilterAttribute))]
        [Authorize]
        public async Task<IActionResult> GetByQuestionId([FromBody] IdModel QuestionId)
        {
            if (!ModelState.IsValid) return ModelStateNonValid<IdModel>(nameof(GetByQuestionId));

            IReturnModel<IEnumerable<GetAnswerResponseDTO>> result = await answerService.GetByQuestionIdAsync(QuestionId.Id);
            LogResultError(result);
            return StaticHelperMethods.SolveResult(result, hateoasModel);

        }


    }
}
