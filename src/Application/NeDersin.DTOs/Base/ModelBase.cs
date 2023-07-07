using NeDersin.DTOs.Abstract;
using NeDersin.DTOs.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace NeDersin.DTOs.Base
{
    public class ModelBase<T> : IModel<T> where T : class, new()
    {
        public ModelBase()
        {
            
        }
        static public T FromString(string str) => str.FromString<T>();
    }
}
