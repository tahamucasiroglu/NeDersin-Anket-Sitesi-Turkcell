using NeDersin.DTOs.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeDersin.DTOs.Concrete.Request.Update
{
    public sealed class UpdateAnswerRequestDTO : IRequestDTO
    {
        public int Id { get; set; }

        public int QuestionId { get; set; }

        public int TypeId { get; set; }

        public int AnswerValueId { get; set; }
    }
}
