using NeDersin.DTOs.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeDersin.DTOs.Concrete.Request.Delete
{
    public sealed class DeleteQuestionRequestDTO : IRequestDTO
    {
        public int Id { get; set; }
    }
}
