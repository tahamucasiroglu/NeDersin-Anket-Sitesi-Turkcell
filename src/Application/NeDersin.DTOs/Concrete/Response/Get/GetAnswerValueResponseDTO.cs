using NeDersin.DTOs.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeDersin.DTOs.Concrete.Response.Get
{
    public sealed class GetAnswerValueResponseDTO : IResponseDTO
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string? Value { get; set; }
    }
}
