using NeDersin.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeDersin.Entities.Concrete.Entities
{
    public partial class Survey : IEntity
    {
        public int Id { get; set; }

        public Guid Address { get; set; }

        public string Title { get; set; } = null!;

        public string? Description { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public bool IsEnd { get; set; }

        public int? MaxResponse { get; set; }

        public int? MinResponse { get; set; }

        public int UserId { get; set; }

        public virtual ICollection<Question> Questions { get; set; } = new List<Question>();

        public virtual ICollection<SurveyRating> SurveyRatings { get; set; } = new List<SurveyRating>();

        public virtual User User { get; set; } = null!;
    }
}
