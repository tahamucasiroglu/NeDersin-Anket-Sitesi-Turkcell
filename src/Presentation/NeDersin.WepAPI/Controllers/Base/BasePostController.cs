using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using NeDersin.DTOs.Abstract;
using NeDersin.DTOs.Concrete.Request.Add;
using NeDersin.DTOs.Concrete.Response.Get;
using NeDersin.DTOs.Concrete.Response.Models.HateoasModels;
using NeDersin.DTOs.Extensions;
using NeDersin.Entities.Concrete.Entities;
using NeDersin.ReturnModel.Abstract;
using NeDersin.Services.Service.Abstract;
using NeDersin.Services.Service.Abstract.Base;
using NeDersin.Services.Service.Concrete;
using NeDersin.WepAPI.Enumeration.HateoasEnumeration;
using NeDersin.WepAPI.StaticMethods;
using NeDersin.WepAPI.StaticMethods.StaticAttributes;

namespace NeDersin.WepAPI.Controllers.Base
{
    public abstract class BasePostController<TAdd, TUpdate, TDelete, TGet> : BaseController<TAdd, TUpdate, TDelete, TGet>, IBasePostController<TAdd, TUpdate, TDelete>, IBaseController
        where TGet : class, IResponseDTO, new()
        where TAdd : class, IRequestDTO, new()
        where TUpdate : class, IRequestDTO, new()
        where TDelete : class, IRequestDTO, new()
    {
        public BasePostController(IService<TGet, TAdd, TUpdate, TDelete> service, HateoasModel hateoasModel, ILogger<ControllerBase> logger) : base(service, hateoasModel, logger) { }

        
        [HttpPost]
        [Authorize]
        public virtual IActionResult Add([FromBody] TAdd survey)
        {
            if (!ModelState.IsValid) 
            {
                LogModelState(survey, "Ekleme");
                return StaticHelperMethods.ReturnError<TAdd>(ModelState, hateoasModel); 
            }

            IReturnModel<TGet> result = service.Add(survey);

            LogResultError(result);

            return StaticHelperMethods.SolveResult<TGet, TAdd>(result, hateoasModel);
        }
        
        [HttpDelete]
        [Authorize]
        public virtual IActionResult Delete([FromBody] TDelete survey)
        {
            if (!ModelState.IsValid) 
            {
                LogModelState(survey, "Silme");
                return StaticHelperMethods.ReturnError<TDelete>(ModelState, hateoasModel); 
            }


            IReturnModel<TGet> result = service.Delete(survey);

            LogResultError(result);

            return StaticHelperMethods.SolveResult<TGet, TDelete>(result, hateoasModel);
        }
        [HttpPut]
        [Authorize]
        public virtual IActionResult Update([FromBody] TUpdate survey)
        {
            if (!ModelState.IsValid) 
            {
                LogModelState(survey, "Güncelleme");
                return StaticHelperMethods.ReturnError<TUpdate>(ModelState, hateoasModel); 
            }

            IReturnModel<TGet> result = service.Update(survey);

            LogResultError(result);

            return StaticHelperMethods.SolveResult<TGet, TUpdate>(result, hateoasModel);
        }

        
    }
}
