using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using NeDersin.DTOs.Concrete.Models;
using NeDersin.DTOs.Concrete.Response.Get;
using NeDersin.DTOs.Concrete.Response.Models.HateoasModels;
using NeDersin.DTOs.Concrete.Response.Models.MethodModels;
using NeDersin.ReturnModel.Abstract;
using NeDersin.Services.Service.Abstract;
using NeDersin.WepAPI.Controllers.Base;
using NeDersin.WepAPI.Enumeration.HateoasEnumeration;
using NeDersin.WepAPI.Filters;
using NeDersin.WepAPI.StaticMethods.StaticAttributes;

namespace NeDersin.WepAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    
    public class SurveyResultController : BaseController  //burası yama oldu berbat oldu lakin çalışıyor :D
    {
        private readonly ISurveyService surveyService;
        private readonly IQuestionService questionService;
        private readonly IResponseService responseService;
        private readonly ISurveyRatingService surveyRatingService;
        private readonly IUserService userService;
        public SurveyResultController(ISurveyService surveyService, IResponseService responseService, ISurveyRatingService surveyRatingService, IQuestionService questionService, IUserService userService, HateoasEnumeration hateoasModel, ILogger<ControllerBase> logger) : base(hateoasModel.GetSurveyRatingControllerHateoas, logger)
        {
            this.surveyService = surveyService;
            this.responseService = responseService;
            this.surveyRatingService = surveyRatingService;
            this.userService = userService;
            this.questionService = questionService;
        }


        [HttpGet("[action]")]
        [AllowAnonymous]
        public IActionResult Get([FromBody] IdModel Id)
        {
            Console.WriteLine("asdasdasdasdsad");
            // anket soru cevap cevaba cevap veren kullanıcı
            if (!ModelState.IsValid) return ModelStateNonValid<IdModel>(nameof(Get));
            List<IReturnModel<IEnumerable<GetResponseResponseDTO>>> responses = new List<IReturnModel<IEnumerable<GetResponseResponseDTO>>>();
            IReturnModel<GetSurveyResponseDTO> survey = surveyService.GetById(Id.Id);
            if (!survey.Status || survey.Data == null) return BadRequest();
            IReturnModel<IEnumerable<GetQuestionResponseDTO>> questions = questionService.GetQuestionsBySurveyId(survey.Data.Id);
            if (!questions.Status || questions.Data == null) return BadRequest();
            foreach (var q in questions.Data) 
            {
                responses.Add(responseService.GetByQuestionId(q.Id));
            }
            
            return Ok(
                new Dictionary<string, object>()
                {
                    { "survey", survey },
                    { "questions", questions },
                    { "responses", responses }
                });


            

        }
    }
}
