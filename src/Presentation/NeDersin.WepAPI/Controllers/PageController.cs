﻿using Microsoft.AspNetCore.Mvc;
using NeDersin.DTOs.Concrete.Models;
using NeDersin.DTOs.Concrete.Response.Models.MethodModels;
using NeDersin.DTOs.Concrete.Response.Models.ReturnModels;
using NeDersin.ReturnModel.Abstract;
using NeDersin.Services.Service.Abstract;
using NeDersin.WepAPI.Controllers.Base;
using NeDersin.WepAPI.Enumeration;
using NeDersin.WepAPI.Enumeration.HateoasEnumeration;
using NeDersin.WepAPI.Filters;
using NeDersin.WepAPI.StaticMethods;
using System.Net;

namespace NeDersin.WepAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PageController : BaseController
    {
        private readonly ISurveyService surveyService;
        public PageController(ISurveyService surveyService, HateoasEnumeration hateoasEnumeration, ILogger<PageController> logger) : base(hateoasEnumeration.GetSurveyPageControllerHateoas, logger)
        {
            this.surveyService = surveyService;
        }

        [HttpGet]
        [ServiceFilter(typeof(LogFilterAttribute))]
        public IActionResult Get([FromBody] PageControllerGetMethodModel getModel)
        {
            if (!ModelState.IsValid) return ModelStateNonValid<PageControllerGetMethodModel>(nameof(Get));

            IReturnModel<GetPaginationModel>? result = GetPageModel(getModel);
            
            if(result == null) { return BadRequest(new ErrorReturnToClientModel<PageControllerGetMethodModel>("\"Order Yanlış", null, hateoasModel)); }
            else
            {
                LogResultError(result);

                return StaticHelperMethods.SolveResult<GetPaginationModel, PageControllerGetMethodModel>(result, hateoasModel);
            }
        }


        private IReturnModel<GetPaginationModel>? GetPageModel(PageControllerGetMethodModel getModel)
        {
            return getModel.order switch
            {
                OrderEnumeration.StartDate => surveyService.GetByStartDatePagination(getModel.pageNum, getModel.pageSize),
                OrderEnumeration.StartDateDesc => surveyService.GetByStartDateDescPagination(getModel.pageNum, getModel.pageSize),
                _ => null,
            };
        }

    }
}
