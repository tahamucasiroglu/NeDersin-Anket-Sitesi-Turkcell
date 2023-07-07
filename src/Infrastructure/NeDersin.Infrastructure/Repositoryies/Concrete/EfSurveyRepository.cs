using Microsoft.EntityFrameworkCore;
using NeDersin.Entities.Concrete.Entities;
using NeDersin.Infrastructure.Contexts;
using NeDersin.Infrastructure.Repositoryies.Abstract;
using NeDersin.Infrastructure.Repositoryies.Base;
using NeDersin.ReturnModel.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace NeDersin.Infrastructure.Repositoryies.Concrete
{
    public sealed class EfSurveyRepository : EfEntityRepositoryBase<Survey, NeDersinDbContext>, ISurveyRepository
    {
        public EfSurveyRepository(NeDersinDbContext context) : base(context) { }

        public IReturnModel<Survey> GetByIncludeQuestions(Expression<Func<Survey, bool>> filter)
        {
            Survey? result = context.Surveys.Include(s => s.Questions).FirstOrDefault(filter);
            return CheckIsNull(result);
        }

        public async Task<IReturnModel<Survey>> GetByIncludeQuestionsAsync(Expression<Func<Survey, bool>> filter)
        {
            Survey? result = await context.Surveys.Include(s => s.Questions).FirstOrDefaultAsync(filter);
            return CheckIsNull(result);
        }
        public IReturnModel<Survey> GetByIncludeQuestionsAndAnswers(Expression<Func<Survey, bool>> filter)
        {
            Survey? result = context.Surveys.Include(s => s.Questions).ThenInclude(s => s.Answers).FirstOrDefault(filter);
            return CheckIsNull(result);
        }
        public async Task<IReturnModel<Survey>> GetByIncludeQuestionsAndAnswersAsync(Expression<Func<Survey, bool>> filter)
        {
            Survey? result = await context.Surveys.Include(s => s.Questions).ThenInclude(s => s.Answers).FirstOrDefaultAsync(filter);
            return CheckIsNull(result);
        }
        public IReturnModel<Survey> GetSurveyWithUser(Expression<Func<Survey, bool>> filter)
        {
            Survey? result = context.Surveys.Include(s => s.User).FirstOrDefault(filter);
            return CheckIsNull(result);
        }

        public async Task<IReturnModel<Survey>> GetSurveyWithUserAsync(Expression<Func<Survey, bool>> filter)
        {
            Survey? result = await context.Surveys.Include(s => s.User).FirstOrDefaultAsync(filter);
            return CheckIsNull(result);
        }

        public IReturnModel<IEnumerable<Survey>> GetAllSurveyWithUser<Tout>(Expression<Func<Survey, bool>>? filter, Expression<Func<Survey, Tout>> order)
        {
            IEnumerable<Survey>? result = filter == null ? context.Surveys.Include(s => s.User).OrderBy(order) : context.Surveys.Include(s => s.User).Where(filter).OrderBy(order);
            return CheckIsNull(result);
        }

        public async Task<IReturnModel<IEnumerable<Survey>>> GetAllSurveyWithUserAsync<Tout>(Expression<Func<Survey, bool>>? filter, Expression<Func<Survey, Tout>> order)
        {
            IEnumerable<Survey>? result = await Task.FromResult<IEnumerable<Survey>>(filter == null ? context.Surveys.Include(s => s.User).OrderBy(order) : context.Surveys.Include(s => s.User).Where(filter).OrderBy(order));
            return CheckIsNull(result);
        }

        public IReturnModel<IEnumerable<Survey>> GetAllSurveyWithUser(Expression<Func<Survey, bool>>? filter = null)
        {
            IEnumerable<Survey>? result = filter == null ? context.Surveys.Include(s => s.User) : context.Surveys.Include(s => s.User).Where(filter);
            return CheckIsNull(result);
        }

        public async Task<IReturnModel<IEnumerable<Survey>>> GetAllSurveyWithUserAsync(Expression<Func<Survey, bool>>? filter = null)
        {
            IEnumerable<Survey>? result = await Task.FromResult<IEnumerable<Survey>>(filter == null ? context.Surveys.Include(s => s.User) : context.Surveys.Include(s => s.User).Where(filter));
            return CheckIsNull(result);
        }

        public IReturnModel<Survey> GetByIncludeQuestionsAndAnswersValue(Expression<Func<Survey, bool>> filter)
        {
            Survey? result = context.Surveys.Include(s => s.Questions).ThenInclude(s => s.Answers).ThenInclude(s => s.AnswerValue).FirstOrDefault(filter);
            return CheckIsNull(result);
        }

        public async Task<IReturnModel<Survey>> GetByIncludeQuestionsAndAnswersValueAsync(Expression<Func<Survey, bool>> filter)
        {
            Survey? result = await context.Surveys.Include(s => s.Questions).ThenInclude(s => s.Answers).ThenInclude(s => s.AnswerValue).FirstOrDefaultAsync(filter);
            return CheckIsNull(result);
        }
    }
}
