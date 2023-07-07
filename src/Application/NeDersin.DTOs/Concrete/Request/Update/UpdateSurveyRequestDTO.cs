using NeDersin.DTOs.Abstract;
using NeDersin.Utils.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeDersin.DTOs.Concrete.Request.Update
{
    public sealed class UpdateSurveyRequestDTO : IRequestDTO
    {
        [Required]
        [NumberBiggerThan(0)]
        public int Id { get; set; }
        [Required]
        [MinLength(1)]
        public string Title { get; set; } = null!;

        public string? Description { get; set; }

        public DateTime? EndDate { get; set; }

        public int? MaxResponse { get; set; }

        public int? MinResponse { get; set; }
    }
}
