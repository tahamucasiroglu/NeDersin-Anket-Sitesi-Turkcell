using AutoMapper;
using NeDersin.DTOs.Concrete.Models;
using NeDersin.DTOs.Concrete.Request.Add;
using NeDersin.DTOs.Concrete.Request.Delete;
using NeDersin.DTOs.Concrete.Request.Update;
using NeDersin.DTOs.Concrete.Response.Get;
using NeDersin.Entities.Concrete.Entities;
using NeDersin.Infrastructure.Repositoryies.Abstract;
using NeDersin.ReturnModel.Abstract;
using NeDersin.ReturnModel.Concrete;
using NeDersin.Services.Extensions;
using NeDersin.Services.Service.Abstract;
using NeDersin.Services.Service.Concrete.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace NeDersin.Services.Service.Concrete
{
    public sealed class SurveyService : ServiceBase<Survey, GetSurveyResponseDTO, AddSurveyRequestDTO, UpdateSurveyRequestDTO, DeleteSurveyRequestDTO>, ISurveyService
    {
        private new readonly ISurveyRepository repository; //tip IRepository<IEntity> kaldığı için survey özel fonsiyonlarını bu sayede kullanabilirim
        public SurveyService(ISurveyRepository repository, IMapper mapper) : base(repository, mapper) { this.repository = repository; }

        public IReturnModel<GetSurveyResponseDTO> GetById(int id)
        {
            IReturnModel<Survey> result = repository.Get(r => r.Id == id);
            return ConvertToReturn<GetSurveyResponseDTO, Survey>(result, mapper);
        }

        public async Task<IReturnModel<GetSurveyResponseDTO>> GetByIdAsync(int id)
        {
            IReturnModel<Survey> result = await repository.GetAsync(r => r.Id == id);
            return ConvertToReturn<GetSurveyResponseDTO, Survey>(result, mapper);
        }

        public IReturnModel<IEnumerable<GetSurveyResponseDTO>> GetByTitle(string name)
        {
            IReturnModel<IEnumerable<Survey>> result = repository.GetAll(r => r.Title.Contains(name));
            return ConvertToReturn<GetSurveyResponseDTO, Survey>(result, mapper);
        }

        public async Task<IReturnModel<IEnumerable<GetSurveyResponseDTO>>> GetByTitleAsync(string name)
        {
            IReturnModel<IEnumerable<Survey>> result = await repository.GetAllAsync(r => r.Title.Contains(name));
            return ConvertToReturn<GetSurveyResponseDTO, Survey>(result, mapper);
        }

        public IReturnModel<IEnumerable<GetSurveyResponseDTO>> GetByStartDate(DateTime dateTime, bool isEnd)
        {
            IReturnModel<IEnumerable<Survey>> result = repository.GetAll(r => r.StartDate > dateTime && r.IsEnd == isEnd);
            return ConvertToReturn<GetSurveyResponseDTO, Survey>(result, mapper);
        }

        public async Task<IReturnModel<IEnumerable<GetSurveyResponseDTO>>> GetByStartDateAsync(DateTime dateTime, bool isEnd)
        {
            IReturnModel<IEnumerable<Survey>> result = await repository.GetAllAsync(r => r.StartDate > dateTime && r.IsEnd == isEnd);
            return ConvertToReturn<GetSurveyResponseDTO, Survey>(result, mapper);
        }

        public IReturnModel<GetSurveyResponseDTO> GetByAddress(Guid address)
        {
            IReturnModel<Survey> result = repository.Get(r => r.Address == address);
            return ConvertToReturn<GetSurveyResponseDTO, Survey>(result, mapper);
        }

        public async Task<IReturnModel<GetSurveyResponseDTO>> GetByAddressAsync(Guid address)
        {
            IReturnModel<Survey> result = await repository.GetAsync(r => r.Address == address);
            return ConvertToReturn<GetSurveyResponseDTO, Survey>(result, mapper);
        }

        public IReturnModel<GetSurveyWithQuestionModel> GetByIdWithQuestions(int id)
        {
            IReturnModel<Survey> result = repository.GetByIncludeQuestions(r => r.Id == id);
            if(result.Status)
            {
                return result.Data == null ?
                    new SuccessReturnModel<GetSurveyWithQuestionModel>("data is null") :
                    new SuccessReturnModel<GetSurveyWithQuestionModel>(new GetSurveyWithQuestionModel(result.Data.ConvertToDto(mapper), result.Data.Questions.ConvertToDto(mapper)));
            }
            return new ErrorReturnModel<GetSurveyWithQuestionModel>(result.Message, null, result.Exception);
        }

        public async Task<IReturnModel<GetSurveyWithQuestionModel>> GetByIdWithQuestionsAsync(int id)
        {
            IReturnModel<Survey> result = await repository.GetByIncludeQuestionsAsync(r => r.Id == id);
            if (result.Status)
            {
                return result.Data == null ?
                    new SuccessReturnModel<GetSurveyWithQuestionModel>("data is null") :
                    new SuccessReturnModel<GetSurveyWithQuestionModel>(new GetSurveyWithQuestionModel(result.Data.ConvertToDto(mapper), result.Data.Questions.ConvertToDto(mapper)));
            }
            return new ErrorReturnModel<GetSurveyWithQuestionModel>(result.Message, null, result.Exception);
        }

        public IReturnModel<GetSurveyWithQuestionModel> GetByAddressWithQuestions(Guid address)
        {
            IReturnModel<Survey> result = repository.GetByIncludeQuestions(r => r.Address == address);
            if (result.Status)
            {
                return result.Data == null ?
                    new SuccessReturnModel<GetSurveyWithQuestionModel>("data is null") :
                    new SuccessReturnModel<GetSurveyWithQuestionModel>(new GetSurveyWithQuestionModel(result.Data.ConvertToDto(mapper), result.Data.Questions.ConvertToDto(mapper)));
            }
            return new ErrorReturnModel<GetSurveyWithQuestionModel>(result.Message, null, result.Exception);
        }

        public async Task<IReturnModel<GetSurveyWithQuestionModel>> GetByAddressWithQuestionsAsync(Guid address)
        {
            IReturnModel<Survey> result = await repository.GetByIncludeQuestionsAsync(r => r.Address == address);
            if (result.Status)
            {
                return result.Data == null ?
                    new SuccessReturnModel<GetSurveyWithQuestionModel>("data is null") :
                    new SuccessReturnModel<GetSurveyWithQuestionModel>(new GetSurveyWithQuestionModel(result.Data.ConvertToDto(mapper), result.Data.Questions.ConvertToDto(mapper)));
            }
            return new ErrorReturnModel<GetSurveyWithQuestionModel>(result.Message, null, result.Exception);
        }

        public IReturnModel<GetSurveyWithQuestionAndAnswerModel> GetByIdWithQuestionsAndAnswers(int id)
        {
            IReturnModel<Survey> result = repository.GetByIncludeQuestionsAndAnswersValue(r => r.Id == id);
            if(result.Status && result.Data != null)
            {
                List<QuestionAndAnswersModel> model = result.Data.Questions.Select(question =>
                {
                    List<AnswerValueModel> answerValueModels = question.Answers.Select(answer =>
                        AnswerValueModel.FromString(answer.AnswerValue.Value ?? "")).ToList();
                    return new QuestionAndAnswersModel(question.ConvertToDto(mapper), answerValueModels);
                }).ToList();
                return new SuccessReturnModel<GetSurveyWithQuestionAndAnswerModel>(new GetSurveyWithQuestionAndAnswerModel(result.Data.ConvertToDto(mapper), model));
            }
            return new ErrorReturnModel<GetSurveyWithQuestionAndAnswerModel>();
        }

        public async Task<IReturnModel<GetSurveyWithQuestionAndAnswerModel>> GetByIdWithQuestionsAndAnswersAsync(int id)
        {
            IReturnModel<Survey> result = await repository.GetByIncludeQuestionsAndAnswersValueAsync(r => r.Id == id);
            if (result.Status && result.Data != null)
            {
                List<QuestionAndAnswersModel> model = result.Data.Questions.Select(question =>
                {
                    List<AnswerValueModel> answerValueModels = question.Answers.Select(answer =>
                        AnswerValueModel.FromString(answer.AnswerValue.Value ?? "")).ToList();
                    return new QuestionAndAnswersModel(question.ConvertToDto(mapper), answerValueModels);
                }).ToList();
                return new SuccessReturnModel<GetSurveyWithQuestionAndAnswerModel>(new GetSurveyWithQuestionAndAnswerModel(result.Data.ConvertToDto(mapper), model));
            }
            return new ErrorReturnModel<GetSurveyWithQuestionAndAnswerModel>();

        }

        public IReturnModel<GetSurveyWithQuestionAndAnswerModel> GetByAddressWithQuestionsAndAnswers(Guid address)
        {
            IReturnModel<Survey> result = repository.GetByIncludeQuestionsAndAnswersValue(r => r.Address == address);
            if (result.Status && result.Data != null)
            {
                List<QuestionAndAnswersModel> model = result.Data.Questions.Select(question =>
                {
                    List<AnswerValueModel> answerValueModels = question.Answers.Select(answer =>
                        AnswerValueModel.FromString(answer.AnswerValue.Value ?? "")).ToList();
                    return new QuestionAndAnswersModel(question.ConvertToDto(mapper), answerValueModels);
                }).ToList();
                return new SuccessReturnModel<GetSurveyWithQuestionAndAnswerModel>(new GetSurveyWithQuestionAndAnswerModel(result.Data.ConvertToDto(mapper), model));
            }
            return new ErrorReturnModel<GetSurveyWithQuestionAndAnswerModel>();
        }

        public async Task<IReturnModel<GetSurveyWithQuestionAndAnswerModel>> GetByAddressWithQuestionAndAnswersAsync(Guid address)
        {
            IReturnModel<Survey> result = await repository.GetByIncludeQuestionsAndAnswersValueAsync(r => r.Address == address);
            if (result.Status && result.Data != null)
            {
                List<QuestionAndAnswersModel> model = result.Data.Questions.Select(question =>
                {
                    List<AnswerValueModel> answerValueModels = question.Answers.Select(answer =>
                        AnswerValueModel.FromString(answer.AnswerValue.Value ?? "")).ToList();
                    return new QuestionAndAnswersModel(question.ConvertToDto(mapper), answerValueModels);
                }).ToList();
                return new SuccessReturnModel<GetSurveyWithQuestionAndAnswerModel>(new GetSurveyWithQuestionAndAnswerModel(result.Data.ConvertToDto(mapper), model));
            }
            return new ErrorReturnModel<GetSurveyWithQuestionAndAnswerModel>();
        }

        public IReturnModel<GetPaginationModel> GetByStartDatePagination(int pageNumber, int pageSize)
        {
            IReturnModel<IEnumerable<Survey>> result = repository.GetAllSurveyWithUser(r => !r.IsEnd, r => r.StartDate);
            if (!result.Status || result.Data == null) { return new ErrorReturnModel<GetPaginationModel>(result.Message, result.Exception); }
            IReturnModel<int> count = repository.Count(r => !r.IsEnd);
            int totalCount = count.Status ? count.Data : 0;
            int totalPage = (int)Math.Ceiling((double)totalCount / pageSize);
            int pageNum = pageNumber;
            if (pageNum < 1){ pageNum = 1; }
            if (pageNum > totalPage){ pageNum = totalPage; }
            int start = (pageNum - 1) * pageSize;
            int end = start + pageSize;
            if (end > totalCount){ end = totalCount; }
            List<GetSurveyListModel> surveyListModels = new List<GetSurveyListModel>();
            foreach (var item in result.Data.Skip(start).Take(pageSize))
            {
                surveyListModels.Add(new GetSurveyListModel()
                {
                    Title = item.Title,
                    Address = item.Address,
                    StartDate = item.StartDate,
                    EndDate = item.EndDate,
                    Writer = item.User.Name + " " + item.User.Surname
                });
            }
            return new SuccessReturnModel<GetPaginationModel>( 
                new GetPaginationModel(
                surveyListModels,
                pageNum,
                totalPage,
                pageSize,
                pageNum > 1,
                pageNum < totalPage
            ));

        }

        public async Task<IReturnModel<GetPaginationModel>> GetByStartDatePaginationAsync(int pageNumber, int pageSize)
        {
            IReturnModel<IEnumerable<Survey>> result = await repository.GetAllSurveyWithUserAsync(r => !r.IsEnd, r => r.StartDate);
            if (!result.Status || result.Data == null) { return new ErrorReturnModel<GetPaginationModel>(result.Message, result.Exception); }
            IReturnModel<int> count = await repository.CountAsync(r => !r.IsEnd);
            int totalCount = count.Status ? count.Data : 0;
            int totalPage = (int)Math.Ceiling((double)totalCount / pageSize);
            int pageNum = pageNumber;
            if (pageNum < 1) { pageNum = 1; }
            if (pageNum > totalPage) { pageNum = totalPage; }
            int start = (pageNum - 1) * pageSize;
            int end = start + pageSize;
            if (end > totalCount) { end = totalCount; }
            List<GetSurveyListModel> surveyListModels = new List<GetSurveyListModel>();
            foreach (var item in result.Data.Skip(start).Take(pageSize))
            {
                surveyListModels.Add(new GetSurveyListModel()
                {
                    Title = item.Title,
                    Address = item.Address,
                    StartDate = item.StartDate,
                    EndDate = item.EndDate,
                    Writer = item.User.Name + " " + item.User.Surname
                });
            }
            return new SuccessReturnModel<GetPaginationModel>(
                new GetPaginationModel(
                surveyListModels,
                pageNum,
                totalPage,
                pageSize,
                pageNum > 1,
                pageNum < totalPage
            ));
        }

        public IReturnModel<GetPaginationModel> GetByStartDateDescPagination(int pageNum, int pageSize)
        {
            IReturnModel<int> count = repository.Count(r => !r.IsEnd);
            IReturnModel<IEnumerable<Survey>> result = repository.GetAllSurveyWithUser(r => !r.IsEnd, r => r.StartDate);
            if(count.Status || result.Status || result.Data == null) { return new ErrorReturnModel<GetPaginationModel>(result.Message, result.Exception); }
            int totalCount = count.Status ? count.Data : 0;
            int totalPage = totalCount / pageSize;
            if (pageNum < 1) { pageNum = 1; }
            if (pageNum > totalPage) { pageNum = totalPage; }
            int start = (pageNum - 1) * pageSize;
            int end = pageNum * pageSize;
            if (end > totalCount) { end = totalCount; }
            List<GetSurveyListModel> surveyListModels = new List<GetSurveyListModel>();
            foreach (var item in result.Data.Take(start..end).Reverse())
            {
                surveyListModels.Add(new() { Title = item.Title, Address = item.Address, StartDate = item.StartDate, EndDate = item.EndDate, Writer = item.User.Name + " " + item.User.Surname });
            }
            return new SuccessReturnModel<GetPaginationModel>(
                new GetPaginationModel(
                    surveyListModels,
                    pageNum,
                    totalPage,
                    pageSize,
                    pageNum > 1,
                    pageNum < totalPage
                ));
        }

        public async Task<IReturnModel<GetPaginationModel>> GetByStartDateDescPaginationAsync(int pageNum, int pageSize)
        {
            IReturnModel<int> count = await repository.CountAsync(r => !r.IsEnd);
            IReturnModel<IEnumerable<Survey>> result = await repository.GetAllSurveyWithUserAsync(r => !r.IsEnd, r => r.StartDate);
            if (count.Status || result.Status || result.Data == null) { return new ErrorReturnModel<GetPaginationModel>(result.Message, result.Exception); }
            int totalCount = count.Status ? count.Data : 0;
            int totalPage = totalCount / pageSize;
            if (pageNum < 1) { pageNum = 1; }
            if (pageNum > totalPage) { pageNum = totalPage; }
            int start = (pageNum - 1) * pageSize;
            int end = pageNum * pageSize;
            if (end > totalCount) { end = totalCount; }
            List<GetSurveyListModel> surveyListModels = new List<GetSurveyListModel>();
            foreach (var item in result.Data.Take(start..end).Reverse())
            {
                surveyListModels.Add(new() { Title = item.Title, Address = item.Address, StartDate = item.StartDate, EndDate = item.EndDate, Writer = item.User.Name + " " + item.User.Surname });
            }
            return new SuccessReturnModel<GetPaginationModel>(
                new GetPaginationModel(
                    surveyListModels,
                    pageNum,
                    totalPage,
                    pageSize,
                    pageNum > 1,
                    pageNum < totalPage
                ));
        }
    }
}

/* eski versiyon yedek
 public sealed class SurveyService : ServiceBase<Survey, GetSurveyResponseDTO, AddSurveyRequestDTO, UpdateSurveyRequestDTO, DeleteSurveyRequestDTO>, ISurveyService
    {
        private new readonly ISurveyRepository repository; //tip IRepository<IEntity> kaldığı için survey özel fonsiyonlarını bu sayede kullanabilirim
        public SurveyService(ISurveyRepository repository, IMapper mapper) : base(repository, mapper) { this.repository = repository; }

        public IReturnModel<GetSurveyResponseDTO> GetById(int id)
        {
            return repository.Get(r => r.Id == id).ConvertToDto(mapper);
            return ConvertToReturn<GetSurveyRatingResponseDTO, SurveyRating>(result, mapper);
        }

        public async Task<IReturnModel<GetSurveyResponseDTO>> GetByIdAsync(int id)
        {
            return (await repository.GetAsync(r => r.Id == id)).ConvertToDto(mapper);
        }

        public IReturnModel<IEnumerable<GetSurveyResponseDTO>> GetByTitle(string name)
        {
            return repository.GetAll(r => r.Title.Contains(name)).ConvertToDto(mapper);
        }

        public async Task<IReturnModel<IEnumerable<GetSurveyResponseDTO>>> GetByTitleAsync(string name)
        {
            return (await repository.GetAllAsync(r => r.Title.Contains(name))).ConvertToDto(mapper);
        }

        public IReturnModel<IEnumerable<GetSurveyResponseDTO>> GetByStartDate(DateTime dateTime, bool reserve, bool isEnd)
        {
            return reserve ?
                repository.GetAll(r => r.StartDate > dateTime && r.IsEnd == isEnd).ConvertToDto(mapper).Reverse() :
                repository.GetAll(r => r.StartDate > dateTime && r.IsEnd == isEnd).ConvertToDto(mapper);
        }

        public async Task<IReturnModel<IEnumerable<GetSurveyResponseDTO>>> GetByStartDateAsync(DateTime dateTime, bool reserve, bool isEnd)
        {
            return reserve ?
                (await repository.GetAllAsync(r => r.StartDate > dateTime && r.IsEnd == isEnd)).ConvertToDto(mapper).Reverse() :
                (await repository.GetAllAsync(r => r.StartDate > dateTime && r.IsEnd == isEnd)).ConvertToDto(mapper);
        }

        public IReturnModel<GetSurveyResponseDTO> GetByAddress(Guid address)
        {
            return repository.Get(r => r.Address == address).ConvertToDto(mapper);
        }

        public async Task<IReturnModel<GetSurveyResponseDTO>> GetByAddressAsync(Guid address)
        {
            return (await repository.GetAsync(r => r.Address == address)).ConvertToDto(mapper);
        }

        public IReturnModel<GetSurveyWithQuestionModel> GetByIdWithQuestions(int id)
        {
            Survey result = repository.GetByIncludeQuestions(r => r.Id == id);
            return new GetSurveyWithQuestionModel(result.ConvertToDto(mapper), result.Questions.ConvertToDto(mapper));

        }

        public async Task<IReturnModel<GetSurveyWithQuestionModel>> GetByIdWithQuestionsAsync(int id)
        {
            Survey result = await repository.GetByIncludeQuestionsAsync(r => r.Id == id);
            return new GetSurveyWithQuestionModel(result.ConvertToDto(mapper), result.Questions.ConvertToDto(mapper));
        }

        public IReturnModel<GetSurveyWithQuestionModel> GetByAddressWithQuestions(Guid address)
        {
            Survey result = repository.GetByIncludeQuestions(r => r.Address == address);
            return new GetSurveyWithQuestionModel(result.ConvertToDto(mapper), result.Questions.ConvertToDto(mapper));
        }

        public async Task<IReturnModel<GetSurveyWithQuestionModel>> GetByAddressWithQuestionsAsync(Guid address)
        {
            Survey result = await repository.GetByIncludeQuestionsAsync(r => r.Address == address);
            return new GetSurveyWithQuestionModel(result.ConvertToDto(mapper), result.Questions.ConvertToDto(mapper));
        }

        public IReturnModel<GetSurveyWithQuestionAndAnswerModel> GetByIdWithQuestionsAndAnswers(int id)
        {
            Survey survey = repository.GetByIncludeQuestionsAndAnswersValue(r => r.Id == id);
            List<QuestionAndAnswersModel> model = survey.Questions.Select(question =>
            {
                List<AnswerValueModel> answerValueModels = question.Answers.Select(answer =>
                    AnswerValueModel.FromString(answer.AnswerValue.Value)).ToList();

                return new QuestionAndAnswersModel(question.ConvertToDto(mapper), answerValueModels);
            }).ToList();

            return new(survey.ConvertToDto(mapper), model);

        }

        public async Task<IReturnModel<GetSurveyWithQuestionAndAnswerModel>> GetByIdWithQuestionsAndAnswersAsync(int id)
        {
            Survey survey = await repository.GetByIncludeQuestionsAndAnswersValueAsync(r => r.Id == id);
            List<QuestionAndAnswersModel> model = survey.Questions.Select(question =>
            {
                List<AnswerValueModel> answerValueModels = question.Answers.Select(answer =>
                    AnswerValueModel.FromString(answer.AnswerValue.Value)).ToList();

                return new QuestionAndAnswersModel(question.ConvertToDto(mapper), answerValueModels);
            }).ToList();

            return new(survey.ConvertToDto(mapper), model);

        }

        public IReturnModel<GetSurveyWithQuestionAndAnswerModel> GetByAddressWithQuestionsAndAnswers(Guid address)
        {
            Survey survey = repository.GetByIncludeQuestionsAndAnswersValue(r => r.Address == address);
            List<QuestionAndAnswersModel> model = survey.Questions.Select(question =>
            {
                List<AnswerValueModel> answerValueModels = question.Answers.Select(answer =>
                    AnswerValueModel.FromString(answer.AnswerValue.Value)).ToList();

                return new QuestionAndAnswersModel(question.ConvertToDto(mapper), answerValueModels);
            }).ToList();

            return new(survey.ConvertToDto(mapper), model);

        }

        public async Task<IReturnModel<GetSurveyWithQuestionAndAnswerModel>> GetByAddressWithQuestionAndAnswersAsync(Guid address)
        {
            Survey survey = await repository.GetByIncludeQuestionsAndAnswersValueAsync(r => r.Address == address);
            List<QuestionAndAnswersModel> model = survey.Questions.Select(question =>
            {
                List<AnswerValueModel> answerValueModels = question.Answers.Select(answer =>
                    AnswerValueModel.FromString(answer.AnswerValue.Value)).ToList();

                return new QuestionAndAnswersModel(question.ConvertToDto(mapper), answerValueModels);
            }).ToList();

            return new(survey.ConvertToDto(mapper), model);
        }

        public IReturnModel<GetPaginationModel> GetByStartDatePagination(int pageNumber, int pageSize)
        {
            int totalCount = repository.Count(r => !r.IsEnd);
            int totalPage = (int)Math.Ceiling((double)totalCount / pageSize);
            int pageNum = pageNumber;
            if (pageNum < 1)
            {
                pageNum = 1;
            }
            if (pageNum > totalPage)
            {
                pageNum = totalPage;
            }
            int start = (pageNum - 1) * pageSize;
            int end = start + pageSize;
            if (end > totalCount)
            {
                end = totalCount;
            }
            List<GetSurveyListModel> surveyListModels = new List<GetSurveyListModel>();
            IEnumerable<Survey> surveyList = repository.GetAllSurveyWithUser(r => !r.IsEnd, r => r.StartDate).Skip(start).Take(pageSize);
            foreach (var item in surveyList)
            {
                surveyListModels.Add(new GetSurveyListModel()
                {
                    Title = item.Title,
                    Address = item.Address,
                    StartDate = item.StartDate,
                    EndDate = item.EndDate,
                    Writer = item.User.Name + " " + item.User.Surname
                });
            }

            return new (
                surveyListModels,
                pageNum,
                totalPage,
                pageSize,
                pageNum > 1,
                pageNum < totalPage
            );

        }

        public async Task<IReturnModel<GetPaginationModel>> GetByStartDatePaginationAsync(int pageNum, int pageSize)
        {
            int totalCount = await repository.CountAsync(r => !r.IsEnd);
            int totalPage = totalCount / pageSize;
            if (pageNum < 1) { pageNum = 1; }
            if (pageNum > totalPage) { pageNum = totalPage; }
            int start = (pageNum - 1) * pageSize;
            int end = pageNum * pageSize;
            if (end > totalCount) { end = totalCount; }
            List<GetSurveyListModel> surveyListModels = new List<GetSurveyListModel>();
            IEnumerable<Survey> surveyList = (await repository.GetAllSurveyWithUserAsync(r => !r.IsEnd, r => r.StartDate)).Take(start..end);
            foreach (var item in surveyList)
            {
                surveyListModels.Add(new() { Title = item.Title, Address = item.Address, StartDate = item.StartDate, EndDate = item.EndDate, Writer = item.User.Name + " " + item.User.Surname });
            }


            return new(
                surveyListModels,
                pageNum,
                totalPage,
                pageSize,
                pageNum > 1,
                pageNum < totalPage
                );
        }

        public IReturnModel<GetPaginationModel> GetByStartDateDescPagination(int pageNum, int pageSize)
        {
            int totalCount = repository.Count(r => !r.IsEnd);
            int totalPage = totalCount / pageSize;
            if (pageNum < 1) { pageNum = 1; }
            if (pageNum > totalPage) { pageNum = totalPage; }
            int start = (pageNum - 1) * pageSize;
            int end = pageNum * pageSize;
            if (end > totalCount) { end = totalCount; }
            List<GetSurveyListModel> surveyListModels = new List<GetSurveyListModel>();
            IEnumerable<Survey> surveyList = repository.GetAllSurveyWithUser(r => !r.IsEnd, r => r.StartDate).Take(start..end).Reverse();
            foreach (var item in surveyList)
            {
                surveyListModels.Add(new() { Title = item.Title, Address = item.Address, StartDate = item.StartDate, EndDate = item.EndDate, Writer = item.User.Name + " " + item.User.Surname });
            }


            return new(
                surveyListModels,
                pageNum,
                totalPage,
                pageSize,
                pageNum > 1,
                pageNum < totalPage
                );
        }

        public async Task<IReturnModel<GetPaginationModel>> GetByStartDateDescPaginationAsync(int pageNum, int pageSize)
        {
            int totalCount = await repository.CountAsync(r => !r.IsEnd);
            int totalPage = totalCount / pageSize;
            if (pageNum < 1) { pageNum = 1; }
            if (pageNum > totalPage) { pageNum = totalPage; }
            int start = (pageNum - 1) * pageSize;
            int end = pageNum * pageSize;
            if (end > totalCount) { end = totalCount; }
            List<GetSurveyListModel> surveyListModels = new List<GetSurveyListModel>();
            IEnumerable<Survey> surveyList = (await repository.GetAllSurveyWithUserAsync(r => !r.IsEnd, r => r.StartDate)).Take(start..end).Reverse();
            foreach (var item in surveyList)
            {
                surveyListModels.Add(new() { Title = item.Title, Address = item.Address, StartDate = item.StartDate, EndDate = item.EndDate, Writer = item.User.Name + " " + item.User.Surname });
            }


            return new(
                surveyListModels,
                pageNum,
                totalPage,
                pageSize,
                pageNum > 1,
                pageNum < totalPage
                );
        }
    }
 */
