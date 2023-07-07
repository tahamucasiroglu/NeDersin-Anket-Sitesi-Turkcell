using NeDersin.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeDersin.Entities.Concrete.Entities
{
    public partial class AnswerType : IEntity
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public virtual ICollection<Answer> Answers { get; set; } = new List<Answer>();
    }
}
