using NeDersin.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeDersin.Entities.Concrete.Entities
{
    public partial class Response : IEntity
    {
        public int Id { get; set; }

        public string ResponseText { get; set; } = null!;

        public int? UserId { get; set; }

        public int QuestionId { get; set; }

        public virtual Question Question { get; set; } = null!;

        public virtual User? User { get; set; }
    }
}
