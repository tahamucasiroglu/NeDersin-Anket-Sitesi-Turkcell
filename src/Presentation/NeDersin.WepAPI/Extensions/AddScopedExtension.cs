
using Microsoft.AspNetCore.Identity;
using NeDersin.Entities.Concrete.Entities;
using NeDersin.Infrastructure.Repositoryies.Abstract;
using NeDersin.Infrastructure.Repositoryies.Concrete;
using NeDersin.Services.Service.Abstract;
using NeDersin.Services.Service.Concrete;
using NeDersin.WepAPI.Enumeration;

namespace NeDersin.WepAPI.Extensions
{
    static public class AddScopedExtension
    {
        public static IServiceCollection AddScopes(this IServiceCollection services)
        {
            services.AddScoped<IAnswerRepository, EfAnswerRepository>();
            services.AddScoped<IAnswerService, AnswerService>();

            services.AddScoped<IAnswerTypeRepository, EfAnswerTypeRepository>();
            services.AddScoped<IAnswerTypeService, AnswerTypeService>();

            services.AddScoped<IAnswerValueRepository, EfAnswerValueRepository>();
            services.AddScoped<IAnswerValueService, AnswerValueService>();

            services.AddScoped<IQuestionRepository, EfQuestionRepository>();
            services.AddScoped<IQuestionService, QuestionService>();

            services.AddScoped<IResponseRepository, EfResponseRepository>();
            services.AddScoped<IResponseService, ResponseService>();

            services.AddScoped<ISurveyRepository, EfSurveyRepository>();
            services.AddScoped<ISurveyService, SurveyService>();

            services.AddScoped<ISurveyRatingRepository, EfSurveyRatingRepository>();
            services.AddScoped<ISurveyRatingService, SurveyRatingService>();

            services.AddScoped<IUserRepository, EfUserRepository>();
            services.AddScoped<IUserService, UserService>();

            services.AddScoped<IUserStatusRepository, EfUserStatusRepository>();
            services.AddScoped<IUserStatusService, UserStatusService>();

            return services;
        }
    }
}
