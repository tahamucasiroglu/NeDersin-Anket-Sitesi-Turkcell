using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using NeDersin.DTOs.Concrete.Models;
using NeDersin.DTOs.Concrete.Response.Models.HateoasModels;
using NeDersin.DTOs.Extensions;
using NeDersin.ReturnModel.Abstract;
using NeDersin.WepAPI.StaticMethods;

namespace NeDersin.WepAPI.Controllers.Base
{
    public class BaseControllerCore : ControllerBase, IBaseController
    {
        internal readonly ILogger<ControllerBase> logger;
        internal readonly HateoasModel hateoasModel;

        public BaseControllerCore(HateoasModel hateoasModel, ILogger<ControllerBase> logger)
        {
            this.hateoasModel = hateoasModel;
            this.logger = logger;
        }
        public virtual void LogModelState<TLog>(TLog value)
            => logger.LogError($"{typeof(TLog).Name} tarafından yapılan işlemde istek ModelState'e takıldı.\nİstek = {value.ToJson()}");
        public virtual void LogModelState<TLog>()
           => logger.LogError($"{typeof(TLog).Name} tarafından yapılan işlemde istek ModelState'e takıldı.\nİstek = Null");
        public virtual void LogModelState<TLog>(TLog value, string MethodName)
           => logger.LogError($"{typeof(TLog).Name} tarafından yapılan {MethodName} işleminde istek ModelState'e takıldı.\nİstek = {value?.ToJson()}");
        public virtual void LogModelState<TLog>(string MethodName)
           => logger.LogError($"{typeof(TLog).Name} tarafından yapılan {MethodName} işleminde istek ModelState'e takıldı.\nİstek = Null");
        /// <summary>
        /// Eğer Status false veya data null ise hata loglar ayrıca false döner
        /// </summary>
        /// <typeparam name="TLog"></typeparam>
        /// <param name="result"></param>
        public virtual bool LogResultError<TLog>(IReturnModel<TLog> result)
        {
            if (!result.Status || result.Data == null)
            {
                string message = "";
                message += $" Status = {result.Status} \n";
                message += $" Data is Null = {result.Data == null} \n";
                message += $" Data Type Name = {result.Data?.GetType().Name} \n";
                message += $" Exception = {result.Exception?.Message} \n";
                message += $" Data = {result.Data?.ToJson()} \n";
                logger.LogError(message);
                return false;
            }
            return true;
        }


        public virtual BadRequestObjectResult ModelStateNonValid<TLog>(string methodName)
        {
            LogModelState<TLog>(methodName);
            return StaticHelperMethods.ReturnError<TLog>(ModelState, hateoasModel);
        }
    }
}
