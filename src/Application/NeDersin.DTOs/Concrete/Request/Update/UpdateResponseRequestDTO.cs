using NeDersin.DTOs.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeDersin.DTOs.Concrete.Request.Update
{
    public sealed class UpdateResponseRequestDTO : IRequestDTO
    {
        public int Id { get; set; }

        public string ResponseText { get; set; } = null!;

        public int? UserId { get; set; }

        public int QuestionId { get; set; }
    }
}
