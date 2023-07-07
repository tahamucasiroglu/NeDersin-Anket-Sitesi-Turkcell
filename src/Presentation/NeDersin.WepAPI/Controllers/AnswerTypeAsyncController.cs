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
    public class AnswerTypeAsyncController : BasePostController<AddAnswerTypeRequestDTO, UpdateAnswerTypeRequestDTO, DeleteAnswerTypeRequestDTO, GetAnswerTypeResponseDTO>
    {
        
        private readonly IAnswerTypeService answerTypeService;

        public AnswerTypeAsyncController(IAnswerTypeService answerTypeService, HateoasEnumeration hateoasEnumeration, ILogger<AnswerTypeController> logger) : base(answerTypeService, hateoasEnumeration.GetAnswerControllerHateoas, logger)
        {
            this.answerTypeService = answerTypeService;
        }

        [HttpGet("[action]")]
        [ServiceFilter(typeof(LogFilterAttribute))]
        [AnketorAuthorize]
        public async Task<IActionResult> GetById([FromBody] IdModel Id)
        {
            if (!ModelState.IsValid) return ModelStateNonValid<IdModel>(nameof(GetById));

            IReturnModel<GetAnswerTypeResponseDTO> result = await answerTypeService.GetByIdAsync(Id.Id);
            LogResultError(result);
            return StaticHelperMethods.SolveResult(result, hateoasModel);

        }


    }
}
