using Microsoft.AspNetCore.Mvc;
using NeDersin.DTOs.Concrete.Models;
using NeDersin.DTOs.Concrete.Response.Models.MethodModels;
using NeDersin.DTOs.Concrete.Response.Models.ReturnModels;
using NeDersin.ReturnModel.Abstract;
using NeDersin.Services.Service.Abstract;
using NeDersin.WepAPI.Controllers.Base;
using NeDersin.WepAPI.Enumeration.HateoasEnumeration;
using NeDersin.WepAPI.Filters;
using NeDersin.WepAPI.StaticMethods;

namespace NeDersin.WepAPI.Controllers
{
    [Route("/Async")]
    [ApiController]
    public class GetSurveyPageAsyncController : BaseController
    {
        private readonly ISurveyService surveyService;
        public GetSurveyPageAsyncController(ISurveyService surveyService, HateoasEnumeration hateoasEnumeration, ILogger<GetSurveyPageController> logger) : base(hateoasEnumeration.GetSurveyPageControllerHateoas, logger)
        {
            this.surveyService = surveyService;
        }

        [HttpGet]
        [ServiceFilter(typeof(LogFilterAttribute))]
        public async Task<IActionResult> Get([FromBody] SurveyControllerGetMethodModel Address)
        {
            if (!ModelState.IsValid) return ModelStateNonValid<SurveyControllerGetMethodModel>(nameof(Get));

            IReturnModel<GetSurveyWithQuestionAndAnswerModel> result = await surveyService.GetByAddressWithQuestionAndAnswersAsync(Address.Address);

            LogResultError(result);

            return StaticHelperMethods.SolveResult(result, hateoasModel);
        }
    }
}
