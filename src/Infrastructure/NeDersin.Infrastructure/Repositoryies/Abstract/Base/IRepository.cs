using NeDersin.Entities.Abstract;
using NeDersin.ReturnModel.Abstract;
using NeDersin.ReturnModel.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NeDersin.Infrastructure.Repositoryies.Abstract.Base
{
    public interface IRepository<T> where T : class, IEntity, new()
    {

        public IReturnModel<T> Get(Expression<Func<T, bool>> filter);
        public Task<IReturnModel<T>> GetAsync(Expression<Func<T, bool>> filter);
        public IReturnModel<IEnumerable<T>> GetAll();
        public IReturnModel<IEnumerable<T>> GetAll(Expression<Func<T, bool>>? filter = null);
        public IReturnModel<IEnumerable<T>> GetAll(Expression<Func<T, bool>>? filter = null, bool reserve = false);
        public IReturnModel<IEnumerable<T>> GetAll(Expression<Func<T, bool>>? filter = null, Expression<Func<T, bool>>? order = null, bool reserve = false);
        public IReturnModel<IEnumerable<T>> GetAll<Tout>(Expression<Func<T, bool>>? filter = null, Expression<Func<T, Tout>>? order = null, bool reserve = false);
        public Task<IReturnModel<IEnumerable<T>>> GetAllAsync();
        public Task<IReturnModel<IEnumerable<T>>> GetAllAsync(Expression<Func<T, bool>>? filter = null);
        public Task<IReturnModel<IEnumerable<T>>> GetAllAsync(Expression<Func<T, bool>>? filter = null, bool reserve = false);
        public Task<IReturnModel<IEnumerable<T>>> GetAllAsync(Expression<Func<T, bool>>? filter = null, Expression<Func<T, bool>>? order = null, bool reserve = false);
        public Task<IReturnModel<IEnumerable<T>>> GetAllAsync<Tout>(Expression<Func<T, bool>>? filter = null, Expression<Func<T, Tout>>? order = null, bool reserve = false);
        public IReturnModel<int> Count(Expression<Func<T, bool>>? filter = null);
        public Task<IReturnModel<int>> CountAsync(Expression<Func<T, bool>>? filter = null);
        public IReturnModel<bool> IsExist(Expression<Func<T, bool>> filter);
        public Task<IReturnModel<bool>> IsExistAsync(Expression<Func<T, bool>> filter);
        public IReturnModel<T> Add(T entity);
        public Task<IReturnModel<T>> AddAsync(T entity);
        public IReturnModel<IEnumerable<T>> AddMultiple(IEnumerable<T> entity);
        public Task<IReturnModel<IEnumerable<T>>> AddMultipleAsync(IEnumerable<T> entity);
        public IReturnModel<T> Update(T entity);
        public Task<IReturnModel<T>> UpdateAsync(T entity);
        public IReturnModel<IEnumerable<T>> UpdateMultiple(IEnumerable<T> entity);
        public Task<IReturnModel<IEnumerable<T>>> UpdateMultipleAsync(IEnumerable<T> entity);
        public IReturnModel<T> Delete(T entity);
        public Task<IReturnModel<T>> DeleteAsync(T entity);
        public IReturnModel<IEnumerable<T>> DeleteMultiple(IEnumerable<T> entity);
        public Task<IReturnModel<IEnumerable<T>>> DeleteMultipleAsync(IEnumerable<T> entity);

    }
}
