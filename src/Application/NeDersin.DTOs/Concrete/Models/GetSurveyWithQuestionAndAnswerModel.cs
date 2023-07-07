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
    public class GetSurveyWithQuestionAndAnswerModel : ModelBase<GetSurveyWithQuestionAndAnswerModel>
    {
        public GetSurveyResponseDTO Survey { get; set; } = new GetSurveyResponseDTO();
        public IEnumerable<QuestionAndAnswersModel> QuestionsAndAnswers { get; set; } = Enumerable.Empty<QuestionAndAnswersModel>();

        public GetSurveyWithQuestionAndAnswerModel(GetSurveyResponseDTO getSurveyResponseDTO, IEnumerable<QuestionAndAnswersModel> questionAndAnswersModels)
        {
            Survey = getSurveyResponseDTO;
            QuestionsAndAnswers = questionAndAnswersModels;
        }
        public GetSurveyWithQuestionAndAnswerModel()
        {
            
        }
    }
}
