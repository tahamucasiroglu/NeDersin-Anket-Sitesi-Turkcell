using NeDersin.DTOs.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeDersin.DTOs.Concrete.Request.Update
{
    public sealed class UpdateQuestionRequestDTO : IRequestDTO
    {
        public int Id { get; set; }

        public string QuestionText { get; set; } = null!;

        public string? ImageAdress { get; set; }

        public int SurveyId { get; set; }
    }
}
