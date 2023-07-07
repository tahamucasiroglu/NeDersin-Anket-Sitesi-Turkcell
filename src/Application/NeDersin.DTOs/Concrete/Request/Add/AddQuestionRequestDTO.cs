using NeDersin.Utils.Attributes;
using NeDersin.DTOs.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeDersin.DTOs.Concrete.Request.Add
{
    public sealed class AddQuestionRequestDTO : IRequestDTO
    {

        [Required(ErrorMessage = "Soru olmadan nasıl soru ekleyeyim acaba")]
        [StringLength(1000)]
        public string QuestionText { get; set; } = null!;
        [HttpAddressCheck]
        public string? ImageAdress { get; set; }
        [Required(ErrorMessage = "Sorunun anketi nerede ne yaapcam bu soruyla ben")]
        public int SurveyId { get; set; }
    }
}
