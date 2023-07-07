using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Logging;
using NeDersin.DTOs.Abstract;
using NeDersin.DTOs.Concrete.Response.Models.HateoasModels;
using NeDersin.Services.Service.Abstract.Base;

namespace NeDersin.WepAPI.Controllers.Base
{
    public class BaseController<TAdd, TUpdate, TDelete, TGet> : BaseControllerCore, IBaseController
        where TGet : class, IResponseDTO, new()
        where TAdd : class, IRequestDTO, new()
        where TUpdate : class, IRequestDTO, new()
        where TDelete : class, IRequestDTO, new()
    {
        internal readonly IService<TGet, TAdd, TUpdate, TDelete> service;

        public BaseController(IService<TGet, TAdd, TUpdate, TDelete> service, HateoasModel hateoasModel, ILogger<ControllerBase> logger) : base(hateoasModel, logger)
        {
            this.service = service;
        }

    }
    public class BaseController : BaseControllerCore
    {
        
        public BaseController(HateoasModel hateoasModel, ILogger<ControllerBase> logger) : base(hateoasModel, logger)
        {
        }

    }
}
