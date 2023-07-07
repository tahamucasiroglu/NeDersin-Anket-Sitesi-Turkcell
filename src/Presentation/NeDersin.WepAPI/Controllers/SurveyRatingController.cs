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
    public class SurveyRatingController : BasePostController<AddSurveyRatingRequestDTO, UpdateSurveyRatingRequestDTO, DeleteSurveyRatingRequestDTO, GetSurveyRatingResponseDTO>
    {
        private readonly ISurveyRatingService surveyRatingService;

        public SurveyRatingController(ISurveyRatingService surveyRatingService, HateoasEnumeration hateoasEnumeration, ILogger<SurveyRatingController> logger) : base(surveyRatingService, hateoasEnumeration.GetSurveyRatingControllerHateoas, logger)
        {
            this.surveyRatingService = surveyRatingService;
        }

        [HttpGet("[action]")]
        public IActionResult GetBySurveyId([FromBody] IdModel id)
        {
            if (!ModelState.IsValid) return ModelStateNonValid<IdModel>(nameof(GetBySurveyId));
            var result = surveyRatingService.GetBySurveyId(id.Id);
            LogResultError(result);
            return StaticHelperMethods.SolveResult(result, hateoasModel);
        }
        [HttpGet("[action]")]
        public IActionResult GetByUserId([FromBody] IdModel id)
        {
            if (!ModelState.IsValid) return ModelStateNonValid<IdModel>(nameof(GetByUserId));
            var result = surveyRatingService.GetByUserId(id.Id);
            LogResultError(result);
            return StaticHelperMethods.SolveResult(result, hateoasModel);
        }
        [HttpGet("[action]")]
        public IActionResult GetByRating([FromBody] IntValueModel rating)
        {
            if (!ModelState.IsValid) return ModelStateNonValid<IdModel>(nameof(GetByRating));
            var result = surveyRatingService.GetByRating(rating.Value);
            LogResultError(result);
            return StaticHelperMethods.SolveResult(result, hateoasModel);
        }

    }
}
