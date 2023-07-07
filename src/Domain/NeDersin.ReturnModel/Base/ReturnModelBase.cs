using NeDersin.ReturnModel.Abstract;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeDersin.ReturnModel.Base
{
    public record class ReturnModelBase<T> : IReturnModel<T>
    {
        public bool Status { get ; init; }
        public T? Data { get; init; }
        public string? Message { get; init; }
        public Exception? Exception { get; init; }

        public ReturnModelBase(bool Status, string? Message, T? Data, Exception? Exception) 
        {
            this.Status = Status;
            this.Message = Message;
            this.Data = Data;
            this.Exception = Exception;
        }

        static public ReturnModelBase<TEntity> Create<TEntity>(bool Status, string? Message, TEntity? Data, Exception? Exception) => new ReturnModelBase<TEntity>(Status, Message, Data, Exception);
    }
}
