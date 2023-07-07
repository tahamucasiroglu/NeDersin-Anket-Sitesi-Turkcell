using AutoMapper;
using NeDersin.DTOs.Concrete.Request.Add;
using NeDersin.DTOs.Concrete.Request.Delete;
using NeDersin.DTOs.Concrete.Request.Update;
using NeDersin.DTOs.Concrete.Response.Get;
using NeDersin.DTOs.Extensions;
using NeDersin.Entities.Concrete.Entities;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeDersin.Services.Mappings
{
    public class MapProfile : Profile
    {
        public MapProfile() // normalde .ReverseMap() gerekmez fakat veritabanı ile yapılan işlemlerde sınıfı geri döndürdüğüm için kullandım peki niye döndürdüm bir cevap modeli ile işlemlerin daha düzenli olmasını istediğim için oldu mu bence oldu
        {
            CreateMap<AddAnswerRequestDTO, Answer>().ReverseMap();
            CreateMap<AddAnswerTypeRequestDTO, AnswerType>().ReverseMap();
            CreateMap<AddAnswerValueRequestDTO, AnswerValue>().ReverseMap();
            CreateMap<AddQuestionRequestDTO, Question>().ReverseMap();
            CreateMap<AddResponseRequestDTO, Response>().ReverseMap();
            CreateMap<AddSurveyRatingRequestDTO, SurveyRating>().ReverseMap();
            CreateMap<AddSurveyRequestDTO, Survey>()
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => Guid.NewGuid()))
                .ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => DateTime.Now))
                .ForMember(dest => dest.IsEnd, opt => opt.MapFrom(src => false))
                .ReverseMap();
            CreateMap<AddUserRequestDTO, User>()
                .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password.ToSha256()))
                .ForMember(dest => dest.UserStatusId, opt => opt.MapFrom(src => 3))
                .ReverseMap();
            CreateMap<AddUserStatusRequestDTO, UserStatus>().ReverseMap();

            CreateMap<DeleteAnswerRequestDTO, Answer>().ReverseMap();
            CreateMap<DeleteAnswerTypeRequestDTO, AnswerType>().ReverseMap();
            CreateMap<DeleteAnswerValueRequestDTO, AnswerValue>().ReverseMap();
            CreateMap<DeleteQuestionRequestDTO, Question>().ReverseMap();
            CreateMap<DeleteResponseRequestDTO, Response>().ReverseMap();
            CreateMap<DeleteSurveyRatingRequestDTO, SurveyRating>().ReverseMap();
            CreateMap<DeleteSurveyRequestDTO, Survey>().ReverseMap();
            CreateMap<DeleteUserRequestDTO, User>().ReverseMap();
            CreateMap<DeleteUserStatusRequestDTO, UserStatus>().ReverseMap();

            CreateMap<UpdateAnswerRequestDTO, Answer>().ReverseMap();
            CreateMap<UpdateAnswerTypeRequestDTO, AnswerType>().ReverseMap();
            CreateMap<UpdateAnswerValueRequestDTO, AnswerValue>().ReverseMap();
            CreateMap<UpdateQuestionRequestDTO, Question>().ReverseMap();
            CreateMap<UpdateResponseRequestDTO, Response>().ReverseMap();
            CreateMap<UpdateSurveyRatingRequestDTO, SurveyRating>().ReverseMap();
            CreateMap<UpdateSurveyRequestDTO, Survey>().ReverseMap();
            CreateMap<UpdateUserRequestDTO, User>().ReverseMap();
            CreateMap<UpdateUserStatusRequestDTO, UserStatus>().ReverseMap();

            CreateMap<Answer, GetAnswerResponseDTO> ().ReverseMap();
            CreateMap<AnswerType, GetAnswerTypeResponseDTO>().ReverseMap();
            CreateMap<AnswerValue, GetAnswerValueResponseDTO>().ReverseMap();
            CreateMap<Question, GetQuestionResponseDTO>().ReverseMap();
            CreateMap<Response, GetResponseResponseDTO>().ReverseMap();
            CreateMap<SurveyRating, GetSurveyRatingResponseDTO>().ReverseMap();
            CreateMap<Survey, GetSurveyResponseDTO>().ReverseMap();
            CreateMap<User, GetUserResponseDTO>().ReverseMap();
            CreateMap<UserStatus, GetUserStatusResponseDTO>().ReverseMap();
        }
    }
}
