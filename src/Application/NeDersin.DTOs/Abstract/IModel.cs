using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace NeDersin.DTOs.Abstract
{
    public interface IModel<T> where T : class, new()
    {
    }
}
