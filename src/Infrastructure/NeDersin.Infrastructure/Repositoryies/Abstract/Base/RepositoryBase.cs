using Microsoft.EntityFrameworkCore;
using NeDersin.Entities.Abstract;
using NeDersin.ReturnModel.Abstract;
using NeDersin.ReturnModel.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeDersin.Infrastructure.Repositoryies.Abstract.Base
{
    abstract public class RepositoryBase<TEntity, TContext>
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {
        internal readonly TContext context;
        public RepositoryBase(TContext context)
        {
            this.context = context;
        }
        internal IReturnModel<TEntity> Save(TEntity entity)
        {
            try
            {
                if (context.SaveChanges() > 0)
                {
                    return new SuccessReturnModel<TEntity>(entity);
                }
                return new ErrorReturnModel<TEntity>(entity);
            }
            catch (Exception e)
            {
                return new ErrorReturnModel<TEntity>(entity, e);
            }
        }

        internal IReturnModel<IEnumerable<TEntity>> Save(IEnumerable<TEntity> entity)
        {
            try
            {
                if (context.SaveChanges() > 0)
                {
                    return new SuccessReturnModel<IEnumerable<TEntity>>(entity);
                }
                return new ErrorReturnModel<IEnumerable<TEntity>>(entity);
            }
            catch (Exception e)
            {
                return new ErrorReturnModel<IEnumerable<TEntity>>(entity, e);
            }
        }
        internal async Task<IReturnModel<TEntity>> SaveAsync(TEntity entity)
        {
            try
            {
                if (await context.SaveChangesAsync() > 0)
                {
                    return new SuccessReturnModel<TEntity>(entity);
                }
                return new ErrorReturnModel<TEntity>(entity);
            }
            catch (Exception e)
            {
                return new ErrorReturnModel<TEntity>(entity, e);
            }
        }

        internal async Task<IReturnModel<IEnumerable<TEntity>>> SaveAsync(IEnumerable<TEntity> entity)
        {
            try
            {
                if (await context.SaveChangesAsync() > 0)
                {
                    return new SuccessReturnModel<IEnumerable<TEntity>>(entity);
                }
                return new ErrorReturnModel<IEnumerable<TEntity>>(entity);
            }
            catch (Exception e)
            {
                return new ErrorReturnModel<IEnumerable<TEntity>>(entity, e);
            }
        }

        internal IReturnModel<TNull> CheckIsNull<TNull>(TNull? result) 
            => (result == null) ? new ErrorReturnModel<TNull>() : new SuccessReturnModel<TNull>(result);
    }
}
