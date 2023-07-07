using NeDersin.DTOs.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeDersin.DTOs.Concrete.Models
{
    public class GetPaginationModel : ModelBase<GetPaginationModel>
    {
        public IEnumerable<GetSurveyListModel> Surveys { get; set; } = Enumerable.Empty<GetSurveyListModel>();
        public int CurrentPageNumber { get; set; } = 0;
        public int MaxPageCount { get; set; } = 0;
        public int SurveysPerPage { get; set; } = 0;
        public bool HasBefore { get; set; } = false;
        public bool HasAfter { get; set; } = false;
        public int ResponseCount { get; set; } = 0;
        public GetPaginationModel(IEnumerable<GetSurveyListModel> surveys, int currentPageNumber, int maxPageCount, int surveysPerPage, bool hasBefore, bool hasAfter, int responponseCount = 0)
        {
            Surveys = surveys;
            CurrentPageNumber = currentPageNumber;
            MaxPageCount = maxPageCount;
            SurveysPerPage = surveysPerPage;
            HasBefore = hasBefore;
            HasAfter = hasAfter;
            ResponseCount = responponseCount;
        }
        public GetPaginationModel()
        {
            
        }
    }
}
