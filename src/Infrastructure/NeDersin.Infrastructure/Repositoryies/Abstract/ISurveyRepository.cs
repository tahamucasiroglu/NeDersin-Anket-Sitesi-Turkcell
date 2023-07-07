using NeDersin.Entities.Concrete.Entities;
using NeDersin.Infrastructure.Repositoryies.Abstract.Base;
using NeDersin.ReturnModel.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NeDersin.Infrastructure.Repositoryies.Abstract
{
    public interface ISurveyRepository : IRepository<Survey>
    {
        //public Survey GetByIdIncludeQuestions(int id);
        //public Task<Survey> GetByIdIncludeQuestionsAsync(int id);
        //public Survey GetByAddressIncludeQuestions(Guid Address);
        //public Task<Survey> GetByAddressIncludeQuestionsAsync(Guid Address);
        //public Survey GetByIdIncludeQuestionsAndAnswers(int id);
        //public Task<Survey> GetByIdIncludeQuestionsAndAnswersAsync(int id);
        //public Survey GetByAddressIncludeQuestionsAndAnswers(Guid Address);
        //public Task<Survey> GetByAddressIncludeQuestionsAndAnswersAsync(Guid Address);
        public IReturnModel<Survey> GetByIncludeQuestions(Expression<Func<Survey, bool>> filter);
        public Task<IReturnModel<Survey>> GetByIncludeQuestionsAsync(Expression<Func<Survey, bool>> filter);
        public IReturnModel<Survey> GetByIncludeQuestionsAndAnswers(Expression<Func<Survey, bool>> filter);
        public Task<IReturnModel<Survey>> GetByIncludeQuestionsAndAnswersAsync(Expression<Func<Survey, bool>> filter);
        public IReturnModel<Survey> GetByIncludeQuestionsAndAnswersValue(Expression<Func<Survey, bool>> filter);
        public Task<IReturnModel<Survey>> GetByIncludeQuestionsAndAnswersValueAsync(Expression<Func<Survey, bool>> filter);
        public IReturnModel<Survey> GetSurveyWithUser(Expression<Func<Survey, bool>> filter);
        public Task<IReturnModel<Survey>> GetSurveyWithUserAsync(Expression<Func<Survey, bool>> filter);
        public IReturnModel<IEnumerable<Survey>> GetAllSurveyWithUser(Expression<Func<Survey, bool>>? filter = null);
        public IReturnModel<IEnumerable<Survey>> GetAllSurveyWithUser<Tout>(Expression<Func<Survey, bool>>? filter, Expression<Func<Survey, Tout>> order);
        public Task<IReturnModel<IEnumerable<Survey>>> GetAllSurveyWithUserAsync(Expression<Func<Survey, bool>>? filter = null);
        public Task<IReturnModel<IEnumerable<Survey>>> GetAllSurveyWithUserAsync<Tout>(Expression<Func<Survey, bool>>? filter, Expression<Func<Survey, Tout>> order);

    }
}
