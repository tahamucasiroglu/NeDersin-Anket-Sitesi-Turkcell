using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeDersin.ReturnModel.Abstract
{
    public interface IReturnModel<T>
    {
        public bool Status { get; init; }
        public string? Message { get; init; }
        public T? Data { get; init; }
        public Exception? Exception { get; init; }
    }
}
