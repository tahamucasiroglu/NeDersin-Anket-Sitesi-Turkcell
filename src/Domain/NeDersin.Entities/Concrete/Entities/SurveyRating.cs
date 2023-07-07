using NeDersin.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeDersin.Entities.Concrete.Entities
{
    public partial class SurveyRating : IEntity
    {
        public int Id { get; set; }

        public int SurveyId { get; set; }

        public int? UserId { get; set; }

        public string? RatingText { get; set; }

        public int RatingNumber { get; set; }

        public virtual Survey Survey { get; set; } = null!;

        public virtual User? User { get; set; }
    }
}
