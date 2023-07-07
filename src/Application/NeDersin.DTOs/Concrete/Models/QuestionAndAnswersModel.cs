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
    public class QuestionAndAnswersModel : ModelBase<QuestionAndAnswersModel>
    {
        public GetQuestionResponseDTO Question { get; set; } = new GetQuestionResponseDTO();
        public IEnumerable<AnswerValueModel> Answers { get; set; } = Enumerable.Empty<AnswerValueModel>();

        public QuestionAndAnswersModel(GetQuestionResponseDTO getQuestionResponseDTO, IEnumerable<AnswerValueModel> answerValueModel)
        {
            Question = getQuestionResponseDTO;
            Answers = answerValueModel;
        }
        public QuestionAndAnswersModel()
        {
            
        }
    }
}
