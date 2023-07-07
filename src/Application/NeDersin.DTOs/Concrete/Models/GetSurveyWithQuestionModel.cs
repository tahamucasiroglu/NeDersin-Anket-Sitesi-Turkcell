using NeDersin.DTOs.Abstract;
using NeDersin.DTOs.Base;
using NeDersin.DTOs.Concrete.Response.Get;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace NeDersin.DTOs.Concrete.Models
{
    public class GetSurveyWithQuestionModel : ModelBase<GetSurveyWithQuestionModel>
    {
        public GetSurveyResponseDTO Survey { get; set; } = new GetSurveyResponseDTO();
        public IEnumerable<GetQuestionResponseDTO> Questions { get; set; } = Enumerable.Empty<GetQuestionResponseDTO>();

        public GetSurveyWithQuestionModel(GetSurveyResponseDTO getSurveyResponseDTO, IEnumerable<GetQuestionResponseDTO> getQuestionResponseDTOs)
        {
            Survey = getSurveyResponseDTO;
            Questions = getQuestionResponseDTOs;
        }
        public GetSurveyWithQuestionModel()
        {
            
        }
    }
}
