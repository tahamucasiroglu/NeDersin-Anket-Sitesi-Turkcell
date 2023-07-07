using NeDersin.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeDersin.Entities.Concrete.Entities
{
    public partial class Question : IEntity
    {
        public int Id { get; set; }

        public string QuestionText { get; set; } = null!;

        public string? ImageAdress { get; set; }

        public int SurveyId { get; set; }

        public virtual ICollection<Answer> Answers { get; set; } = new List<Answer>();

        public virtual ICollection<Response> Responses { get; set; } = new List<Response>();

        public virtual Survey Survey { get; set; } = null!;
    }
}
