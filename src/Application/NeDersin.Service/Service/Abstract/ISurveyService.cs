using NeDersin.DTOs.Concrete.Models;
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
    public interface ISurveyService : IService<GetSurveyResponseDTO, AddSurveyRequestDTO, UpdateSurveyRequestDTO, DeleteSurveyRequestDTO>
    {
        public IReturnModel<GetSurveyResponseDTO> GetById(int id);
        public Task<IReturnModel<GetSurveyResponseDTO>> GetByIdAsync(int id);
        public IReturnModel<GetSurveyResponseDTO> GetByAddress(Guid address);
        public Task<IReturnModel<GetSurveyResponseDTO>> GetByAddressAsync(Guid address);
        public IReturnModel<IEnumerable<GetSurveyResponseDTO>> GetByTitle(string name);
        public Task<IReturnModel<IEnumerable<GetSurveyResponseDTO>>> GetByTitleAsync(string name);
        public IReturnModel<IEnumerable<GetSurveyResponseDTO>> GetByStartDate(DateTime dateTime, bool isEnd);
        public Task<IReturnModel<IEnumerable<GetSurveyResponseDTO>>> GetByStartDateAsync(DateTime dateTime, bool isEnd);
        public IReturnModel<GetSurveyWithQuestionModel> GetByIdWithQuestions(int id);
        public Task<IReturnModel<GetSurveyWithQuestionModel>> GetByIdWithQuestionsAsync(int id);
        public IReturnModel<GetSurveyWithQuestionModel> GetByAddressWithQuestions(Guid address);
        public Task<IReturnModel<GetSurveyWithQuestionModel>> GetByAddressWithQuestionsAsync(Guid address);
        public IReturnModel<GetSurveyWithQuestionAndAnswerModel> GetByIdWithQuestionsAndAnswers(int id);
        public Task<IReturnModel<GetSurveyWithQuestionAndAnswerModel>> GetByIdWithQuestionsAndAnswersAsync(int id);
        public IReturnModel<GetSurveyWithQuestionAndAnswerModel> GetByAddressWithQuestionsAndAnswers(Guid address);
        public Task<IReturnModel<GetSurveyWithQuestionAndAnswerModel>> GetByAddressWithQuestionAndAnswersAsync(Guid address);
        public IReturnModel<GetPaginationModel> GetByStartDatePagination(int pageNum, int pageSize);
        public Task<IReturnModel<GetPaginationModel>> GetByStartDatePaginationAsync(int pageNum, int pageSize);
        public IReturnModel<GetPaginationModel> GetByStartDateDescPagination(int pageNum, int pageSize);
        public Task<IReturnModel<GetPaginationModel>> GetByStartDateDescPaginationAsync(int pageNum, int pageSize);



    }
}
