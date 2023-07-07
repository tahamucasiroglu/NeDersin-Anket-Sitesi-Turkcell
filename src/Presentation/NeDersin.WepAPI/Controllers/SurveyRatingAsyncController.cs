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
using NeDersin.WepAPI.StaticMethods;

namespace NeDersin.WepAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SurveyAsyncRatingController : BasePostController<AddSurveyRatingRequestDTO, UpdateSurveyRatingRequestDTO, DeleteSurveyRatingRequestDTO, GetSurveyRatingResponseDTO>
    {
        private readonly ISurveyRatingService surveyRatingService;

        public SurveyAsyncRatingController(ISurveyRatingService surveyRatingService, HateoasEnumeration hateoasEnumeration, ILogger<SurveyRatingController> logger) : base(surveyRatingService, hateoasEnumeration.GetSurveyRatingControllerHateoas, logger)
        {
            this.surveyRatingService = surveyRatingService;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetBySurveyId([FromBody] IdModel id)
        {
            if (!ModelState.IsValid) return ModelStateNonValid<IdModel>(nameof(GetBySurveyId));
            var result = await surveyRatingService.GetBySurveyIdAsync(id.Id);
            LogResultError(result);
            return StaticHelperMethods.SolveResult(result, hateoasModel);
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetByUserId([FromBody] IdModel id)
        {
            if (!ModelState.IsValid) return ModelStateNonValid<IdModel>(nameof(GetByUserId));
            var result = await surveyRatingService.GetByUserIdAsync(id.Id);
            LogResultError(result);
            return StaticHelperMethods.SolveResult(result, hateoasModel);
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetByRating([FromBody] IntValueModel rating)
        {
            if (!ModelState.IsValid) return ModelStateNonValid<IdModel>(nameof(GetByRating));
            var result = await surveyRatingService.GetByRatingAsync(rating.Value);
            LogResultError(result);
            return StaticHelperMethods.SolveResult(result, hateoasModel);
        }

    }
}
