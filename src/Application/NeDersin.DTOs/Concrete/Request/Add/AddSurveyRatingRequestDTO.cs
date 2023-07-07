using NeDersin.DTOs.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeDersin.DTOs.Concrete.Request.Add
{
    public sealed class AddSurveyRatingRequestDTO : IRequestDTO
    {
        public int SurveyId { get; set; }

        public int? UserId { get; set; }

        public string? RatingText { get; set; }

        public int RatingNumber { get; set; }
    }
}
