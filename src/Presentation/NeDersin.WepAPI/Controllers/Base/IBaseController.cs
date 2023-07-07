using Microsoft.Extensions.Logging;
using NeDersin.DTOs.Extensions;
using NeDersin.ReturnModel.Abstract;

namespace NeDersin.WepAPI.Controllers.Base
{
    public interface IBaseController
    {
        public void LogModelState<TLog>(TLog value);
        public void LogModelState<TLog>();
        public void LogModelState<TLog>(TLog value, string MethodName);
        public void LogModelState<TLog>(string MethodName);
        public bool LogResultError<TLog>(IReturnModel<TLog> result);
    }
}
