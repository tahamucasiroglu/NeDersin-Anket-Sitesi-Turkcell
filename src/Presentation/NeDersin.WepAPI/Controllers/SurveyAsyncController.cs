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
    public class SurveyAsyncController : BasePostController< AddSurveyRequestDTO, UpdateSurveyRequestDTO, DeleteSurveyRequestDTO, GetSurveyResponseDTO>
    {
        private readonly ISurveyService surveyService;
        public SurveyAsyncController(ISurveyService surveyService, HateoasEnumeration hateoasEnumeration, ILogger<SurveyController> logger) : base(surveyService, hateoasEnumeration.GetSurveyControllerHateoas, logger)
        {
            this.surveyService = surveyService;
        }

        [HttpGet("[action]")]
        [ServiceFilter(typeof(LogFilterAttribute))]
        public async Task<IActionResult> GetSurveyById([FromBody]IdModel Id)
        {
            if (!ModelState.IsValid) return ModelStateNonValid<IdModel>(nameof(GetSurveyById));

            var result = await surveyService.GetByIdAsync(Id.Id);

            LogResultError(result);

            return StaticHelperMethods.SolveResult(result, hateoasModel);
        }
    }
}
