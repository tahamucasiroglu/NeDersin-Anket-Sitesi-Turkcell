using NeDersin.DTOs.Abstract;
using NeDersin.Utils.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeDersin.DTOs.Concrete.Request.Add
{
    public sealed class AddSurveyRequestDTO : IRequestDTO
    {
        //public Guid Address { get; set; }
        [Required]
        [MinLength(1)]
        [MaxLength(150)]
        public string Title { get; set; } = null!;

        public string? Description { get; set; }

        public DateTime? EndDate { get; set; }

        public int? MaxResponse { get; set; }

        public int? MinResponse { get; set; }

        [Required]
        [NumberBiggerThan(0, nameof(UserId))]
        public int UserId { get; set; }
    }
}
