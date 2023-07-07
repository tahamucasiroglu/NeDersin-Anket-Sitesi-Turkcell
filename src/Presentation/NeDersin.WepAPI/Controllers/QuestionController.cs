﻿using Microsoft.AspNetCore.Mvc;
using NeDersin.DTOs.Concrete.Models;
using NeDersin.DTOs.Concrete.Request.Add;
using NeDersin.DTOs.Concrete.Request.Delete;
using NeDersin.DTOs.Concrete.Request.Update;
using NeDersin.DTOs.Concrete.Response.Get;
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
    [Route("[controller]")]
    [ApiController]
    public class QuestionController : BasePostController<AddQuestionRequestDTO, UpdateQuestionRequestDTO, DeleteQuestionRequestDTO, GetQuestionResponseDTO>
    {
        private readonly IQuestionService questionService;
        public QuestionController(IQuestionService questionService, HateoasEnumeration hateoasEnumeration, ILogger<QuestionController> logger) : base(questionService, hateoasEnumeration.GetSurveyPageControllerHateoas, logger)
        {
            this.questionService = questionService;
        }

        [HttpGet("[action]")]
        [ServiceFilter(typeof(LogFilterAttribute))]
        public IActionResult GetById([FromBody] IdModel Id)
        {
            if (!ModelState.IsValid) return ModelStateNonValid<IdModel>(nameof(GetById));
            var result = questionService.GetQuestionById(Id.Id);

            LogResultError(result);

            return StaticHelperMethods.SolveResult(result, hateoasModel);
            
        }

        [HttpGet("[action]")]
        [ServiceFilter(typeof(LogFilterAttribute))]
        public IActionResult GetBySurveyId([FromBody] IdModel Id)
        {
            if (!ModelState.IsValid) return ModelStateNonValid<IdModel>(nameof(GetBySurveyId));
            var result = questionService.GetQuestionsBySurveyId(Id.Id);

            LogResultError(result);

            return StaticHelperMethods.SolveResult(result, hateoasModel);
        }



    }
}
