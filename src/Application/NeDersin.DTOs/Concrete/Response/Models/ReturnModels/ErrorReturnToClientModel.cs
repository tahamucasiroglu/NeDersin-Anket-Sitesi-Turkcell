using NeDersin.DTOs.Concrete.Response.Models.HateoasModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeDersin.DTOs.Concrete.Response.Models.ReturnModels
{
    public sealed record class ErrorReturnToClientModel<T> : ReturnToClientModel<T>
    {
        public ErrorReturnToClientModel(string? message, T? data, HateoasModel hateoasModel) : base("Başarısız - " + message, false, data, hateoasModel) { }
    }

    public sealed record class ErrorReturnToClientModel : ReturnToClientModelCore
    {
        public ErrorReturnToClientModel(string? message, HateoasModel hateoasModel) : base("Başarısız - " + message, false, hateoasModel) { }
    }
}
