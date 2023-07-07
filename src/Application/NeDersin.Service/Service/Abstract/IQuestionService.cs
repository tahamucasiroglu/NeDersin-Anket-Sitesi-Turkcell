using NeDersin.DTOs.Concrete.Request.Add;
using NeDersin.DTOs.Concrete.Request.Delete;
using NeDersin.DTOs.Concrete.Request.Update;
using NeDersin.DTOs.Concrete.Response.Get;
using NeDersin.ReturnModel.Abstract;
using NeDersin.Services.Service.Abstract.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeDersin.Services.Service.Abstract
{
    public interface IQuestionService : IService<GetQuestionResponseDTO, AddQuestionRequestDTO, UpdateQuestionRequestDTO, DeleteQuestionRequestDTO>
    {
        public IReturnModel<GetQuestionResponseDTO> GetQuestionById(int id);
        public Task<IReturnModel<GetQuestionResponseDTO>> GetQuestionByIdAsync(int id);
        public IReturnModel<IEnumerable<GetQuestionResponseDTO>> GetQuestionsBySurveyId(int surveyId);
        public Task<IReturnModel<IEnumerable<GetQuestionResponseDTO>>> GetQuestionsBySurveyIdAsync(int surveyId);
    }
}
