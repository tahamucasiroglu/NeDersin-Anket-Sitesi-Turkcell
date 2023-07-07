using AutoMapper;
using NeDersin.DTOs.Concrete.Request.Add;
using NeDersin.DTOs.Concrete.Request.Delete;
using NeDersin.DTOs.Concrete.Request.Update;
using NeDersin.DTOs.Concrete.Response.Get;
using NeDersin.Entities.Concrete.Entities;
using NeDersin.Infrastructure.Repositoryies.Abstract;
using NeDersin.ReturnModel.Abstract;
using NeDersin.Services.Extensions;
using NeDersin.Services.Service.Abstract;
using NeDersin.Services.Service.Concrete.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeDersin.Services.Service.Concrete
{
    public sealed class SurveyRatingService : ServiceBase<SurveyRating, GetSurveyRatingResponseDTO, AddSurveyRatingRequestDTO, UpdateSurveyRatingRequestDTO, DeleteSurveyRatingRequestDTO>, ISurveyRatingService
    {
        public SurveyRatingService(ISurveyRatingRepository repository, IMapper mapper) : base(repository, mapper) { }

        public IReturnModel<IEnumerable<GetSurveyRatingResponseDTO>> GetByRating(int rate)
        {
            IReturnModel<IEnumerable<SurveyRating>> result = repository.GetAll(r => r.RatingNumber == rate);
            return ConvertToReturn<GetSurveyRatingResponseDTO, SurveyRating>(result, mapper);
        }

        public IReturnModel<IEnumerable<GetSurveyRatingResponseDTO>> GetByRating(Range range)
        {
            IReturnModel<IEnumerable<SurveyRating>> result = repository.GetAll(r => r.RatingNumber >= range.Start.Value && r.RatingNumber <= range.End.Value);
            return ConvertToReturn<GetSurveyRatingResponseDTO, SurveyRating>(result, mapper);
        }

        public async Task<IReturnModel<IEnumerable<GetSurveyRatingResponseDTO>>> GetByRatingAsync(int rate)
        {
            IReturnModel<IEnumerable<SurveyRating>> result = await repository.GetAllAsync(r => r.RatingNumber == rate);
            return ConvertToReturn<GetSurveyRatingResponseDTO, SurveyRating>(result, mapper);
        }

        public async Task<IReturnModel<IEnumerable<GetSurveyRatingResponseDTO>>> GetByRatingAsync(Range range)
        {
            IReturnModel<IEnumerable<SurveyRating>> result = await repository.GetAllAsync(r => r.RatingNumber >= range.Start.Value && r.RatingNumber <= range.End.Value);
            return ConvertToReturn<GetSurveyRatingResponseDTO, SurveyRating>(result, mapper);
        }

        public IReturnModel<IEnumerable<GetSurveyRatingResponseDTO>> GetBySurveyId(int id)
        {
            IReturnModel<IEnumerable<SurveyRating>> result = repository.GetAll(r => r.SurveyId == id);
            return ConvertToReturn<GetSurveyRatingResponseDTO, SurveyRating>(result, mapper);
        }

        public async Task<IReturnModel<IEnumerable<GetSurveyRatingResponseDTO>>> GetBySurveyIdAsync(int id)
        {
            IReturnModel<IEnumerable<SurveyRating>> result = await repository.GetAllAsync(r => r.SurveyId == id);
            return ConvertToReturn<GetSurveyRatingResponseDTO, SurveyRating>(result, mapper);
        }

        public IReturnModel<IEnumerable<GetSurveyRatingResponseDTO>> GetByUserId(int id)
        {
            IReturnModel<IEnumerable<SurveyRating>> result = repository.GetAll(r => r.UserId == id);
            return ConvertToReturn<GetSurveyRatingResponseDTO, SurveyRating>(result, mapper);
        }

        public async Task<IReturnModel<IEnumerable<GetSurveyRatingResponseDTO>>> GetByUserIdAsync(int id)
        {
            IReturnModel<IEnumerable<SurveyRating>> result = await repository.GetAllAsync(r => r.UserId == id);
            return ConvertToReturn<GetSurveyRatingResponseDTO, SurveyRating>(result, mapper);
        }
        public IReturnModel<IEnumerable<GetSurveyRatingResponseDTO>> GetById(int id)
        {
            IReturnModel<IEnumerable<SurveyRating>> result = repository.GetAll(r => r.Id == id);
            return ConvertToReturn<GetSurveyRatingResponseDTO, SurveyRating>(result, mapper);
        }

        public async Task<IReturnModel<IEnumerable<GetSurveyRatingResponseDTO>>> GetByIdAsync(int id)
        {
            IReturnModel<IEnumerable<SurveyRating>> result = await repository.GetAllAsync(r => r.Id == id);
            return ConvertToReturn<GetSurveyRatingResponseDTO, SurveyRating>(result, mapper);
        }
    }
}
