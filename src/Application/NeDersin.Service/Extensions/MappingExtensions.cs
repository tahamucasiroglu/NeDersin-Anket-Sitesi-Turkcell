using AutoMapper;
using Microsoft.IdentityModel.Tokens;
using NeDersin.DTOs.Abstract;
using NeDersin.DTOs.Concrete.Request.Add;
using NeDersin.DTOs.Concrete.Request.Delete;
using NeDersin.DTOs.Concrete.Request.Update;
using NeDersin.DTOs.Concrete.Response.Get;
using NeDersin.Entities.Abstract;
using NeDersin.Entities.Concrete.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeDersin.Services.Extensions
{
    static public class MappingExtensions
    {
        //public static IEnumerable<T> ConvertToEntity<T>(this IEnumerable<IRequestDTO> entity, IMapper mapper)
        //    where T : class, IEntity => mapper.Map<IEnumerable<T>>(entity);

        //public static T ConvertToEntity<T>(this IRequestDTO entity, IMapper mapper)
        //    where T : class, IEntity => mapper.Map<T>(entity);

        //public static IEnumerable<T> ConvertToDto<T>(this IEnumerable<IEntity> entity, IMapper mapper)
        //    where T : class, IResponseDTO => mapper.Map<IEnumerable<T>>(entity);

        //public static T ConvertToDto<T>(this IEntity entity, IMapper mapper)
        //    where T : class, IResponseDTO => mapper.Map<T>(entity);

        // üstteki kısa ama her kullanımda tipleri vermemek için bunları private yaparak maplere özel extension
        // ekledim bu sayede her kullanımda tip belirtilmez


        private static IEnumerable<T> ConvertToEntity<T>(IEnumerable<IRequestDTO> entity, IMapper mapper)
            where T : class, IEntity 
            => mapper.Map<IEnumerable<T>>(entity);
        private static T ConvertToEntity<T>(IRequestDTO entity, IMapper mapper)
            where T : class, IEntity 
            => mapper.Map<T>(entity);
        private static IEnumerable<T> ConvertToDto<T>(IEnumerable<IEntity> entity, IMapper mapper)
            where T : class, IDto
            =>  mapper.Map<IEnumerable<T>>(entity);
        private static T ConvertToDto<T>(IEntity entity, IMapper mapper)
            where T : class, IDto
            => mapper.Map<T>(entity);

        public static IEnumerable<T> ConvertToEntityCustom<T>(this IEnumerable<IRequestDTO> entity, IMapper mapper)
            where T : class, IEntity => 
            ConvertToEntity<T>(entity, mapper);
        public static T ConvertToEntityCustom<T>(this IRequestDTO entity, IMapper mapper)
            where T : class, IEntity => 
            ConvertToEntity<T>(entity, mapper);
        public static IEnumerable<T> ConvertToDtoCustom<T>(this IEnumerable<IEntity> entity, IMapper mapper)
            where T : class, IDto
            => ConvertToDto<T>(entity, mapper);
        public static T ConvertToDtoCustom<T>(this IEntity entity, IMapper mapper)
            where T : class, IDto
            => ConvertToDto<T>(entity, mapper);


        public static IEnumerable<Answer> ConvertToEntity(this IEnumerable<AddAnswerRequestDTO> entity, IMapper mapper)
            => ConvertToEntity<Answer>(entity, mapper);
        public static IEnumerable<AnswerType> ConvertToEntity(this IEnumerable<AddAnswerTypeRequestDTO> entity, IMapper mapper)
            => ConvertToEntity<AnswerType>(entity, mapper);
        public static IEnumerable<AnswerValue> ConvertToEntity(this IEnumerable<AddAnswerValueRequestDTO> entity, IMapper mapper)
            => ConvertToEntity<AnswerValue>(entity, mapper);
        public static IEnumerable<Question> ConvertToEntity(this IEnumerable<AddQuestionRequestDTO> entity, IMapper mapper)
            => ConvertToEntity<Question>(entity, mapper);
        public static IEnumerable<Response> ConvertToEntity(this IEnumerable<AddResponseRequestDTO> entity, IMapper mapper)
            => ConvertToEntity<Response>(entity, mapper);
        public static IEnumerable<Survey> ConvertToEntity(this IEnumerable<AddSurveyRequestDTO> entity, IMapper mapper)
            => ConvertToEntity<Survey>(entity, mapper);
        public static IEnumerable<SurveyRating> ConvertToEntity(this IEnumerable<AddSurveyRatingRequestDTO> entity, IMapper mapper)
            => ConvertToEntity<SurveyRating>(entity, mapper);
        public static IEnumerable<User> ConvertToEntity(this IEnumerable<AddUserRequestDTO> entity, IMapper mapper)
            => ConvertToEntity<User>(entity, mapper);
        public static IEnumerable<UserStatus> ConvertToEntity(this IEnumerable<AddUserStatusRequestDTO> entity, IMapper mapper)
            => ConvertToEntity<UserStatus>(entity, mapper);

        public static IEnumerable<Answer> ConvertToEntity(this IEnumerable<UpdateAnswerRequestDTO> entity, IMapper mapper)
            => ConvertToEntity<Answer>(entity, mapper);
        public static IEnumerable<AnswerType> ConvertToEntity(this IEnumerable<UpdateAnswerTypeRequestDTO> entity, IMapper mapper)
            => ConvertToEntity<AnswerType>(entity, mapper);
        public static IEnumerable<AnswerValue> ConvertToEntity(this IEnumerable<UpdateAnswerValueRequestDTO> entity, IMapper mapper)
            => ConvertToEntity<AnswerValue>(entity, mapper);
        public static IEnumerable<Question> ConvertToEntity(this IEnumerable<UpdateQuestionRequestDTO> entity, IMapper mapper)
            => ConvertToEntity<Question>(entity, mapper);
        public static IEnumerable<Response> ConvertToEntity(this IEnumerable<UpdateResponseRequestDTO> entity, IMapper mapper)
            => ConvertToEntity<Response>(entity, mapper);
        public static IEnumerable<Survey> ConvertToEntity(this IEnumerable<UpdateSurveyRequestDTO> entity, IMapper mapper)
            => ConvertToEntity<Survey>(entity, mapper);
        public static IEnumerable<SurveyRating> ConvertToEntity(this IEnumerable<UpdateSurveyRatingRequestDTO> entity, IMapper mapper)
            => ConvertToEntity<SurveyRating>(entity, mapper);
        public static IEnumerable<User> ConvertToEntity(this IEnumerable<UpdateUserRequestDTO> entity, IMapper mapper)
            => ConvertToEntity<User>(entity, mapper);
        public static IEnumerable<UserStatus> ConvertToEntity(this IEnumerable<UpdateUserStatusRequestDTO> entity, IMapper mapper)
            => ConvertToEntity<UserStatus>(entity, mapper);

        public static IEnumerable<Answer> ConvertToEntity(this IEnumerable<DeleteAnswerRequestDTO> entity, IMapper mapper)
            => ConvertToEntity<Answer>(entity, mapper);
        public static IEnumerable<AnswerType> ConvertToEntity(this IEnumerable<DeleteAnswerTypeRequestDTO> entity, IMapper mapper)
            => ConvertToEntity<AnswerType>(entity, mapper);
        public static IEnumerable<AnswerValue> ConvertToEntity(this IEnumerable<DeleteAnswerValueRequestDTO> entity, IMapper mapper)
            => ConvertToEntity<AnswerValue>(entity, mapper);
        public static IEnumerable<Question> ConvertToEntity(this IEnumerable<DeleteQuestionRequestDTO> entity, IMapper mapper)
            => ConvertToEntity<Question>(entity, mapper);
        public static IEnumerable<Response> ConvertToEntity(this IEnumerable<DeleteResponseRequestDTO> entity, IMapper mapper)
            => ConvertToEntity<Response>(entity, mapper);
        public static IEnumerable<Survey> ConvertToEntity(this IEnumerable<DeleteSurveyRequestDTO> entity, IMapper mapper)
            => ConvertToEntity<Survey>(entity, mapper);
        public static IEnumerable<SurveyRating> ConvertToEntity(this IEnumerable<DeleteSurveyRatingRequestDTO> entity, IMapper mapper)
            => ConvertToEntity<SurveyRating>(entity, mapper);
        public static IEnumerable<User> ConvertToEntity(this IEnumerable<DeleteUserRequestDTO> entity, IMapper mapper)
            => ConvertToEntity<User>(entity, mapper);
        public static IEnumerable<UserStatus> ConvertToEntity(this IEnumerable<DeleteUserStatusRequestDTO> entity, IMapper mapper)
            => ConvertToEntity<UserStatus>(entity, mapper);


        public static Answer ConvertToEntity(this AddAnswerRequestDTO entity, IMapper mapper)
            => ConvertToEntity<Answer>(entity, mapper);
        public static AnswerType ConvertToEntity(this AddAnswerTypeRequestDTO entity, IMapper mapper)
            => ConvertToEntity<AnswerType>(entity, mapper);
        public static AnswerValue ConvertToEntity(this AddAnswerValueRequestDTO entity, IMapper mapper)
            => ConvertToEntity<AnswerValue>(entity, mapper);
        public static Question ConvertToEntity(this AddQuestionRequestDTO entity, IMapper mapper)
            => ConvertToEntity<Question>(entity, mapper);
        public static Response ConvertToEntity(this AddResponseRequestDTO entity, IMapper mapper)
            => ConvertToEntity<Response>(entity, mapper);
        public static Survey ConvertToEntity(this AddSurveyRequestDTO entity, IMapper mapper)
            => ConvertToEntity<Survey>(entity, mapper);
        public static SurveyRating ConvertToEntity(this AddSurveyRatingRequestDTO entity, IMapper mapper)
            => ConvertToEntity<SurveyRating>(entity, mapper);
        public static User ConvertToEntity(this AddUserRequestDTO entity, IMapper mapper)
            => ConvertToEntity<User>(entity, mapper);
        public static UserStatus ConvertToEntity(this AddUserStatusRequestDTO entity, IMapper mapper)
            => ConvertToEntity<UserStatus>(entity, mapper);

        public static Answer ConvertToEntity(this UpdateAnswerRequestDTO entity, IMapper mapper)
            => ConvertToEntity<Answer>(entity, mapper);
        public static AnswerType ConvertToEntity(this UpdateAnswerTypeRequestDTO entity, IMapper mapper)
            => ConvertToEntity<AnswerType>(entity, mapper);
        public static AnswerValue ConvertToEntity(this UpdateAnswerValueRequestDTO entity, IMapper mapper)
            => ConvertToEntity<AnswerValue>(entity, mapper);
        public static Question ConvertToEntity(this UpdateQuestionRequestDTO entity, IMapper mapper)
            => ConvertToEntity<Question>(entity, mapper);
        public static Response ConvertToEntity(this UpdateResponseRequestDTO entity, IMapper mapper)
            => ConvertToEntity<Response>(entity, mapper);
        public static Survey ConvertToEntity(this UpdateSurveyRequestDTO entity, IMapper mapper)
            => ConvertToEntity<Survey>(entity, mapper);
        public static SurveyRating ConvertToEntity(this UpdateSurveyRatingRequestDTO entity, IMapper mapper)
            => ConvertToEntity<SurveyRating>(entity, mapper);
        public static User ConvertToEntity(this UpdateUserRequestDTO entity, IMapper mapper)
            => ConvertToEntity<User>(entity, mapper);
        public static UserStatus ConvertToEntity(this UpdateUserStatusRequestDTO entity, IMapper mapper)
            => ConvertToEntity<UserStatus>(entity, mapper);

        public static Answer ConvertToEntity(this DeleteAnswerRequestDTO entity, IMapper mapper)
            => ConvertToEntity<Answer>(entity, mapper);
        public static AnswerType ConvertToEntity(this DeleteAnswerTypeRequestDTO entity, IMapper mapper)
            => ConvertToEntity<AnswerType>(entity, mapper);
        public static AnswerValue ConvertToEntity(this DeleteAnswerValueRequestDTO entity, IMapper mapper)
            => ConvertToEntity<AnswerValue>(entity, mapper);
        public static Question ConvertToEntity(this DeleteQuestionRequestDTO entity, IMapper mapper)
            => ConvertToEntity<Question>(entity, mapper);
        public static Response ConvertToEntity(this DeleteResponseRequestDTO entity, IMapper mapper)
            => ConvertToEntity<Response>(entity, mapper);
        public static Survey ConvertToEntity(this DeleteSurveyRequestDTO entity, IMapper mapper)
            => ConvertToEntity<Survey>(entity, mapper);
        public static SurveyRating ConvertToEntity(this DeleteSurveyRatingRequestDTO entity, IMapper mapper)
            => ConvertToEntity<SurveyRating>(entity, mapper);
        public static User ConvertToEntity(this DeleteUserRequestDTO entity, IMapper mapper)
            => ConvertToEntity<User>(entity, mapper);
        public static UserStatus ConvertToEntity(this DeleteUserStatusRequestDTO entity, IMapper mapper)
            => ConvertToEntity<UserStatus>(entity, mapper);


        public static IEnumerable<GetAnswerResponseDTO> ConvertToDto(this IEnumerable<Answer> entity, IMapper mapper)
            => ConvertToDto<GetAnswerResponseDTO>(entity, mapper);
        public static IEnumerable<GetAnswerTypeResponseDTO> ConvertToDto(this IEnumerable<AnswerType> entity, IMapper mapper)
            => ConvertToDto<GetAnswerTypeResponseDTO>(entity, mapper);
        public static IEnumerable<GetAnswerValueResponseDTO> ConvertToDto(this IEnumerable<AnswerValue> entity, IMapper mapper)
            => ConvertToDto<GetAnswerValueResponseDTO>(entity, mapper);
        public static IEnumerable<GetQuestionResponseDTO> ConvertToDto(this IEnumerable<Question> entity, IMapper mapper)
            => ConvertToDto<GetQuestionResponseDTO>(entity, mapper);
        public static IEnumerable<GetResponseResponseDTO> ConvertToDto(this IEnumerable<Response> entity, IMapper mapper)
            => ConvertToDto<GetResponseResponseDTO>(entity, mapper);
        public static IEnumerable<GetSurveyResponseDTO> ConvertToDto(this IEnumerable<Survey> entity, IMapper mapper)
            => ConvertToDto<GetSurveyResponseDTO>(entity, mapper);
        public static IEnumerable<GetSurveyRatingResponseDTO> ConvertToDto(this IEnumerable<SurveyRating> entity, IMapper mapper)
            => ConvertToDto<GetSurveyRatingResponseDTO>(entity, mapper);
        public static IEnumerable<GetUserResponseDTO> ConvertToDto(this IEnumerable<User> entity, IMapper mapper)
            => ConvertToDto<GetUserResponseDTO>(entity, mapper);
        public static IEnumerable<GetUserStatusResponseDTO> ConvertToDto(this IEnumerable<UserStatus> entity, IMapper mapper)
            => ConvertToDto<GetUserStatusResponseDTO>(entity, mapper);

        public static GetAnswerResponseDTO ConvertToDto(this Answer entity, IMapper mapper)
            => ConvertToDto<GetAnswerResponseDTO>(entity, mapper);
        public static GetAnswerTypeResponseDTO ConvertToDto(this AnswerType entity, IMapper mapper)
            => ConvertToDto<GetAnswerTypeResponseDTO>(entity, mapper);
        public static GetAnswerValueResponseDTO ConvertToDto(this AnswerValue entity, IMapper mapper)
            => ConvertToDto<GetAnswerValueResponseDTO>(entity, mapper);
        public static GetQuestionResponseDTO ConvertToDto(this Question entity, IMapper mapper)
            => ConvertToDto<GetQuestionResponseDTO>(entity, mapper);
        public static GetResponseResponseDTO ConvertToDto(this Response entity, IMapper mapper)
            => ConvertToDto<GetResponseResponseDTO>(entity, mapper);
        public static GetSurveyResponseDTO ConvertToDto(this Survey entity, IMapper mapper)
            => ConvertToDto<GetSurveyResponseDTO>(entity, mapper);
        public static GetSurveyRatingResponseDTO ConvertToDto(this SurveyRating entity, IMapper mapper)
            => ConvertToDto<GetSurveyRatingResponseDTO>(entity, mapper);
        public static GetUserResponseDTO ConvertToDto(this User entity, IMapper mapper)
            => ConvertToDto<GetUserResponseDTO>(entity, mapper);
        public static GetUserStatusResponseDTO ConvertToDto(this UserStatus entity, IMapper mapper)
            => ConvertToDto<GetUserStatusResponseDTO>(entity, mapper);


    }
}
