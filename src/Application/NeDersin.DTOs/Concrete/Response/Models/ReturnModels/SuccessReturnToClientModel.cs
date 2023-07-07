using NeDersin.DTOs.Concrete.Response.Models.HateoasModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeDersin.DTOs.Concrete.Response.Models.ReturnModels
{
    public sealed record class SuccessReturnToClientModel<T> : ReturnToClientModel<T>
    {
        public SuccessReturnToClientModel(string? message, T? data, HateoasModel hateoasModel) : base("Başarılı - " + message, true, data, hateoasModel) { }
    }

    public sealed record class SuccessReturnToClientModel : ReturnToClientModelCore
    {
        public SuccessReturnToClientModel(string? message, HateoasModel hateoasModel) : base("Başarılı - " + message, true, hateoasModel) { }
    }
}
