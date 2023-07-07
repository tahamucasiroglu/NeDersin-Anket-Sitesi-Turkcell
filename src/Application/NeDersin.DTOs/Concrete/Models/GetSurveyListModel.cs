using NeDersin.DTOs.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeDersin.DTOs.Concrete.Models
{
    public class GetSurveyListModel : ModelBase<GetSurveyListModel>
    {
        public Guid Address { get; set; }
        public string Title { get; set; } = null!;
        public string Writer { get; set; } = null!;
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }

    }
}
