using NeDersin.DTOs.Concrete.Response.Models.HateoasModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeDersin.DTOs.Concrete.Response.Models.ReturnModels
{
    public record class ReturnToClientModel<T> : ReturnToClientModelCore
    {
        public T? Data { get; init; }

        public ReturnToClientModel(string? message, bool status, T? data, HateoasModel hateoasModel) : base(message, status, hateoasModel)
        {
            Data = data;
        }
    }

    public record class ReturnToClientModelCore
    {
        public string? Message { get; init; }
        public bool Status { get; init; }
        public HateoasModel Hateoas { get; init; }

        public ReturnToClientModelCore(string? message, bool status, HateoasModel hateoasModel)
        {
            Message = message;
            Status = status;
            Hateoas = hateoasModel;
        }
    }
}
