using NeDersin.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeDersin.Entities.Concrete.Entities
{
    public partial class Answer : IEntity
    {
        public int Id { get; set; }

        public int QuestionId { get; set; }

        public int? AnswerValueId { get; set; }

        public int TypeId { get; set; }

        public virtual AnswerType Type { get; set; } = null!;

        public virtual AnswerValue AnswerValue { get; set; } = null!;

        public virtual Question Question { get; set; } = null!;


    }
}
