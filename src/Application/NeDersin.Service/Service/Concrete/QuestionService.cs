using AutoMapper;
using NeDersin.DTOs.Concrete.Request.Add;
using NeDersin.DTOs.Concrete.Request.Delete;
using NeDersin.DTOs.Concrete.Request.Update;
using NeDersin.DTOs.Concrete.Response.Get;
using NeDersin.Services.Extensions;
using NeDersin.Infrastructure.Repositoryies.Abstract;
using NeDersin.Services.Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NeDersin.Services.Service.Concrete.Base;
using NeDersin.Entities.Concrete.Entities;
using NeDersin.ReturnModel.Abstract;

namespace NeDersin.Services.Service.Concrete
{
    public sealed class QuestionService : ServiceBase<Question, GetQuestionResponseDTO, AddQuestionRequestDTO, UpdateQuestionRequestDTO, DeleteQuestionRequestDTO>, IQuestionService
    {

        public QuestionService(IQuestionRepository repository, IMapper mapper) : base(repository, mapper) { }

        public IReturnModel<GetQuestionResponseDTO> GetQuestionById(int id)
        {
            IReturnModel<Question> result = repository.Get(r => r.Id == id);
            return ConvertToReturn<GetQuestionResponseDTO, Question>(result, mapper);
        }

        public async Task<IReturnModel<GetQuestionResponseDTO>> GetQuestionByIdAsync(int id)
        {
            IReturnModel<Question> result = await repository.GetAsync(r => r.Id == id);
            return ConvertToReturn<GetQuestionResponseDTO, Question>(result, mapper);
        }

        public IReturnModel<IEnumerable<GetQuestionResponseDTO>> GetQuestionsBySurveyId(int surveyId)
        {
            IReturnModel<IEnumerable<Question>> result = repository.GetAll(r => r.SurveyId == surveyId);
            return ConvertToReturn<GetQuestionResponseDTO, Question>(result, mapper);
        }

        public async Task<IReturnModel<IEnumerable<GetQuestionResponseDTO>>> GetQuestionsBySurveyIdAsync(int surveyId)
        {
            IReturnModel<IEnumerable<Question>> result = await repository.GetAllAsync(r => r.SurveyId == surveyId);
            return ConvertToReturn<GetQuestionResponseDTO, Question>(result, mapper);
        }
    }
}
