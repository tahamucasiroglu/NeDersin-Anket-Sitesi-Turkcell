using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using NeDersin.Entities.Abstract;
using NeDersin.Entities.Extensions;
using NeDersin.Infrastructure.Repositoryies.Abstract.Base;
using NeDersin.ReturnModel.Abstract;
using NeDersin.ReturnModel.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NeDersin.Infrastructure.Repositoryies.Base
{

    public class EfEntityRepositoryBase<TEntity, TContext> : RepositoryBase<TEntity, TContext>, IRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {
        public EfEntityRepositoryBase(TContext context) : base(context) { }
        public IReturnModel<TEntity> Add(TEntity entity)
        {
            context.Set<TEntity>().Add(entity);
            return Save(entity);
        }

        public async Task<IReturnModel<TEntity>> AddAsync(TEntity entity)
        {

            await context.Set<TEntity>().AddAsync(entity);
            return await SaveAsync(entity);

        }

        public IReturnModel<IEnumerable<TEntity>> AddMultiple(IEnumerable<TEntity> entity)
        {
            context.Set<TEntity>().AddRange(entity);
            return Save(entity);
        }

        public async Task<IReturnModel<IEnumerable<TEntity>>> AddMultipleAsync(IEnumerable<TEntity> entity)
        {
            await context.Set<TEntity>().AddRangeAsync(entity);
            return await SaveAsync(entity);
        }

        public IReturnModel<TEntity> Delete(TEntity entity)
        {
            context.Set<TEntity>().Remove(entity);
            return Save(entity);
        }

        public async Task<IReturnModel<TEntity>> DeleteAsync(TEntity entity)
        {
            context.Set<TEntity>().Remove(entity);
            return await SaveAsync(entity);
        }

        public IReturnModel<IEnumerable<TEntity>> DeleteMultiple(IEnumerable<TEntity> entity)
        {
            context.Set<TEntity>().RemoveRange(entity);
            return Save(entity);
        }

        public async Task<IReturnModel<IEnumerable<TEntity>>> DeleteMultipleAsync(IEnumerable<TEntity> entity)
        {
            context.Set<TEntity>().RemoveRange(entity);
            return await SaveAsync(entity);
        }

        public IReturnModel<TEntity> Get(Expression<Func<TEntity, bool>> filter)
        {
            var result = context.Set<TEntity>().AsNoTracking().FirstOrDefault(filter);
            return CheckIsNull(result);
        }

        public async Task<IReturnModel<TEntity>> GetAsync(Expression<Func<TEntity, bool>> filter)
        {
            var result =  await context.Set<TEntity>().AsNoTracking().FirstOrDefaultAsync(filter);
            return CheckIsNull(result);
        }

        public IReturnModel<IEnumerable<TEntity>> GetAll()
        {
            return GetAll(null, false);
        }

        public IReturnModel<IEnumerable<TEntity>> GetAll(Expression<Func<TEntity, bool>>? filter)
        {
            return GetAll(filter, false);
        }

        public IReturnModel<IEnumerable<TEntity>> GetAll(Expression<Func<TEntity, bool>>? filter, bool reserve = false) // buralarda hata varsa null filter koduna bak
        {
#pragma warning disable CS8604 // Olası null başvuru bağımsız değişkeni.
            IEnumerable<TEntity>? result = (filter == null, reserve) switch
            {
                (true, true) => context.Set<TEntity>().AsNoTracking().Reverse(),
                (true, false) => context.Set<TEntity>().AsNoTracking(),
                (false, true) => context.Set<TEntity>().AsNoTracking().Where(filter).Reverse(),
                (false, false) => context.Set<TEntity>().AsNoTracking().Where(filter)
            };
#pragma warning restore CS8604 // Olası null başvuru bağımsız değişkeni.
            return CheckIsNull(result);
        }

        public IReturnModel<IEnumerable<TEntity>> GetAll(Expression<Func<TEntity, bool>>? filter = null, Expression<Func<TEntity, bool>>? order = null, bool reserve = false)
        {
            return GetAll<bool>(filter, order, reserve);            
        }

        public IReturnModel<IEnumerable<TEntity>> GetAll<Tout>(Expression<Func<TEntity, bool>>? filter = null, Expression<Func<TEntity, Tout>>? order = null, bool reserve = false)
        {
#pragma warning disable CS8604 // Olası null başvuru bağımsız değişkeni.
            IEnumerable<TEntity>? result = (filter == null, order == null, reserve) switch
            {
                (true, true, true) => context.Set<TEntity>().AsNoTracking().Reverse(),
                (true, true, false) => context.Set<TEntity>().AsNoTracking(),
                (true, false, true) => context.Set<TEntity>().AsNoTracking().OrderBy(order).Reverse(),
                (true, false, false) => context.Set<TEntity>().AsNoTracking().OrderBy(order),
                (false, true, true) => context.Set<TEntity>().AsNoTracking().Where(filter).Reverse(),
                (false, true, false) => context.Set<TEntity>().AsNoTracking().Where(filter),
                (false, false, true) => context.Set<TEntity>().AsNoTracking().Where(filter).OrderBy(order).Reverse(),
                (false, false, false) => context.Set<TEntity>().AsNoTracking().Where(filter).OrderBy(order)
            };
#pragma warning restore CS8604 // Olası null başvuru bağımsız değişkeni.
            return CheckIsNull(result);
        }

        public async Task<IReturnModel<IEnumerable<TEntity>>> GetAllAsync()
        {
            return await GetAllAsync(null, false);
        }

        public async Task<IReturnModel<IEnumerable<TEntity>>> GetAllAsync(Expression<Func<TEntity, bool>>? filter)
        {
            return await GetAllAsync(filter, false);
        }

        public async Task<IReturnModel<IEnumerable<TEntity>>> GetAllAsync(Expression<Func<TEntity, bool>>? filter, bool reserve = false)
        {
#pragma warning disable CS8604 // Olası null başvuru bağımsız değişkeni.
            IEnumerable<TEntity>? result =  await Task.FromResult((filter == null, reserve) switch
            {
                (true, true) => context.Set<TEntity>().AsNoTracking().Reverse(),
                (true, false) => context.Set<TEntity>().AsNoTracking(),
                (false, true) => context.Set<TEntity>().AsNoTracking().Where(filter).Reverse(),
                (false, false) => context.Set<TEntity>().AsNoTracking().Where(filter)
            });
#pragma warning restore CS8604 // Olası null başvuru bağımsız değişkeni.
            return CheckIsNull(result);
        }

        public async Task<IReturnModel<IEnumerable<TEntity>>> GetAllAsync(Expression<Func<TEntity, bool>>? filter = null, Expression<Func<TEntity, bool>>? order = null, bool reserve = false)
        {
            return await GetAllAsync<bool>(filter, order, reserve);
        }

        public async Task<IReturnModel<IEnumerable<TEntity>>> GetAllAsync<Tout>(Expression<Func<TEntity, bool>>? filter = null, Expression<Func<TEntity, Tout>>? order = null, bool reserve = false)
        {
#pragma warning disable CS8604 // Olası null başvuru bağımsız değişkeni. switch içinde kontrol ediliyor zaten ondan kapadım bir yanlışım yoksa burada null gidemez istenmeyen yerlere
            IEnumerable<TEntity>? result = await Task.FromResult((filter == null, order == null, reserve) switch
            {
                (true, true, true) => context.Set<TEntity>().AsNoTracking().Reverse(),
                (true, true, false) => context.Set<TEntity>().AsNoTracking(),
                (true, false, true) => context.Set<TEntity>().AsNoTracking().OrderBy(order).Reverse(),
                (true, false, false) => context.Set<TEntity>().AsNoTracking().OrderBy(order),
                (false, true, true) => context.Set<TEntity>().AsNoTracking().Where(filter).Reverse(),
                (false, true, false) => context.Set<TEntity>().AsNoTracking().Where(filter),
                (false, false, true) => context.Set<TEntity>().AsNoTracking().Where(filter).OrderBy(order).Reverse(),
                (false, false, false) => context.Set<TEntity>().AsNoTracking().Where(filter).OrderBy(order)
            });
#pragma warning restore CS8604 // Olası null başvuru bağımsız değişkeni.
            return CheckIsNull(result);
        }

        public IReturnModel<TEntity> Update(TEntity entity)
        {
            context.Set<TEntity>().Update(entity);
            return Save(entity);
        }

        public async Task<IReturnModel<TEntity>> UpdateAsync(TEntity entity)
        {
            context.Set<TEntity>().Update(entity);
            return await SaveAsync(entity);
        }

        public IReturnModel<IEnumerable<TEntity>> UpdateMultiple(IEnumerable<TEntity> entity)
        {
            context.Set<TEntity>().UpdateRange(entity);
            return Save(entity);
        }

        public async Task<IReturnModel<IEnumerable<TEntity>>> UpdateMultipleAsync(IEnumerable<TEntity> entity)
        {
            context.Set<TEntity>().UpdateRange(entity);
            return await SaveAsync(entity);
        }

        public IReturnModel<bool> IsExist(Expression<Func<TEntity, bool>> filter)
        {
            try
            {
                return new SuccessReturnModel<bool>(context.Set<TEntity>().Any(filter));
            }
            catch (Exception e)
            {
                return new ErrorReturnModel<bool>(e);
            }
        }

        public async Task<IReturnModel<bool>> IsExistAsync(Expression<Func<TEntity, bool>> filter)
        {
            try
            {
                return new SuccessReturnModel<bool>(await context.Set<TEntity>().AnyAsync(filter));
            }
            catch (Exception e)
            {
                return new ErrorReturnModel<bool>(e);
            }
        }
        public IReturnModel<int> Count(Expression<Func<TEntity, bool>>? filter = null)
        {
            try
            {
                return new SuccessReturnModel<int>(filter == null ? context.Set<TEntity>().Count() : context.Set<TEntity>().Count(filter));
            }
            catch (Exception e)
            {
                return new ErrorReturnModel<int>(e);
            }
        }
        public async Task<IReturnModel<int>> CountAsync(Expression<Func<TEntity, bool>>? filter = null)
        {
            try
            {
                return new SuccessReturnModel<int>(filter == null ? await context.Set<TEntity>().CountAsync() : await context.Set<TEntity>().CountAsync(filter));
            }
            catch (Exception e)
            {
                return new ErrorReturnModel<int>(e);
            }
        }

        //private IReturnModel<TEntity> Save(TEntity entity)
        //{
        //    try
        //    {
        //        if (context.SaveChanges() > 0)
        //        {
        //            return new SuccessReturnModel<TEntity>(entity);
        //        }
        //        return new ErrorReturnModel<TEntity>(entity);
        //    }
        //    catch (Exception e)
        //    {
        //        return new ErrorReturnModel<TEntity>(entity, e);
        //    }
        //}

        //private IReturnModel<IEnumerable<TEntity>> Save(IEnumerable<TEntity> entity)
        //{
        //    try
        //    {
        //        if (context.SaveChanges() > 0)
        //        {
        //            return new SuccessReturnModel<IEnumerable<TEntity>>(entity);
        //        }
        //        return new ErrorReturnModel<IEnumerable<TEntity>>(entity);
        //    }
        //    catch (Exception e)
        //    {
        //        return new ErrorReturnModel<IEnumerable<TEntity>>(entity, e);
        //    }
        //}
        //private async Task<IReturnModel<TEntity>> SaveAsync(TEntity entity)
        //{
        //    try
        //    {
        //        if (await context.SaveChangesAsync() > 0)
        //        {
        //            return new SuccessReturnModel<TEntity>(entity);
        //        }
        //        return new ErrorReturnModel<TEntity>(entity);
        //    }
        //    catch (Exception e)
        //    {
        //        return new ErrorReturnModel<TEntity>(entity, e);
        //    }
        //}

        //private async Task<IReturnModel<IEnumerable<TEntity>>> SaveAsync(IEnumerable<TEntity> entity)
        //{
        //    try
        //    {
        //        if (await context.SaveChangesAsync() > 0)
        //        {
        //            return new SuccessReturnModel<IEnumerable<TEntity>>(entity);
        //        }
        //        return new ErrorReturnModel<IEnumerable<TEntity>>(entity);
        //    }
        //    catch (Exception e)
        //    {
        //        return new ErrorReturnModel<IEnumerable<TEntity>>(entity, e);
        //    }
        //}

        //private IReturnModel<TNull> CheckIsNull<TNull>(TNull? result) => (result == null) ? new ErrorReturnModel<TNull>() : new SuccessReturnModel<TNull>(result);

    }
}
