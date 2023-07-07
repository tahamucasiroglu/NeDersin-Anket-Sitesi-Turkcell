using NeDersin.DTOs.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeDersin.DTOs.Concrete.Request.Add
{
    public sealed class AddAnswerTypeRequestDTO : IRequestDTO
    {
        public string Name { get; set; } = null!;
    }
}
