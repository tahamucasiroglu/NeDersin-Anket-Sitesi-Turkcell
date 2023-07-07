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
    public interface ISurveyRatingService : IService<GetSurveyRatingResponseDTO, AddSurveyRatingRequestDTO, UpdateSurveyRatingRequestDTO, DeleteSurveyRatingRequestDTO>
    {
        public IReturnModel<IEnumerable<GetSurveyRatingResponseDTO>> GetBySurveyId(int id);
        public Task<IReturnModel<IEnumerable<GetSurveyRatingResponseDTO>>> GetBySurveyIdAsync(int id);
        public IReturnModel<IEnumerable<GetSurveyRatingResponseDTO>> GetByUserId(int id);
        public Task<IReturnModel<IEnumerable<GetSurveyRatingResponseDTO>>> GetByUserIdAsync(int id);
        public IReturnModel<IEnumerable<GetSurveyRatingResponseDTO>> GetByRating(int rate);
        public Task<IReturnModel<IEnumerable<GetSurveyRatingResponseDTO>>> GetByRatingAsync(int rate);
        public IReturnModel<IEnumerable<GetSurveyRatingResponseDTO>> GetByRating(Range range);
        public Task<IReturnModel<IEnumerable<GetSurveyRatingResponseDTO>>> GetByRatingAsync(Range range);
    }
}
