using AutoMapper;
using NeDersin.DTOs.Abstract;
using NeDersin.Entities.Abstract;
using NeDersin.Infrastructure.Repositoryies.Abstract.Base;
using NeDersin.Services.Service.Abstract.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NeDersin.Services.Extensions;
using NeDersin.ReturnModel.Abstract;
using NeDersin.ReturnModel.Concrete;

namespace NeDersin.Services.Service.Concrete.Base
{
    abstract public class ServiceBase<Entity, Response, AddRequest, UpdateRequest, DeleteRequest> : ServiceConvertToReturn, IService<Response, AddRequest, UpdateRequest, DeleteRequest>
        where Entity : class, IEntity, new()
        where Response : class, IResponseDTO
        where AddRequest : class, IRequestDTO
        where UpdateRequest : class, IRequestDTO
        where DeleteRequest : class, IRequestDTO
    {
        internal readonly IRepository<Entity> repository;
        internal readonly IMapper mapper;

        public ServiceBase(IRepository<Entity> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public virtual IReturnModel<Response> Add(AddRequest entity)
        {
            IReturnModel<Entity> result = repository.Add(entity.ConvertToEntityCustom<Entity>(mapper));
            return ConvertToReturn<Response, Entity>(result, mapper);
        }

        public virtual async Task<IReturnModel<Response>> AddAsync(AddRequest entity)
        {
            IReturnModel<Entity> result = await repository.AddAsync(entity.ConvertToEntityCustom<Entity>(mapper));
            return ConvertToReturn<Response, Entity>(result, mapper);
        }

        public virtual IReturnModel<Response> Delete(DeleteRequest entity)
        {
            IReturnModel<Entity> result = repository.Delete(entity.ConvertToEntityCustom<Entity>(mapper));
            return ConvertToReturn<Response, Entity>(result, mapper);
        }

        public virtual async Task<IReturnModel<Response>> DeleteAsync(DeleteRequest entity)
        {
            IReturnModel<Entity> result = await repository.DeleteAsync(entity.ConvertToEntityCustom<Entity>(mapper));
            return ConvertToReturn<Response, Entity>(result, mapper);
        }

        public virtual IReturnModel<IEnumerable<Response>> GetAll()
        {
            IReturnModel<IEnumerable<Entity>> result = repository.GetAll();
            return ConvertToReturn<Response, Entity>(result, mapper);
        }

        public virtual async Task<IReturnModel<IEnumerable<Response>>> GetAllAsync()
        {
            IReturnModel<IEnumerable<Entity>> result = await repository.GetAllAsync();
            return ConvertToReturn<Response, Entity>(result, mapper);
        }

        public virtual IReturnModel<Response> Update(UpdateRequest entity)
        {
            IReturnModel<Entity> result = repository.Update(entity.ConvertToEntityCustom<Entity>(mapper));
            return ConvertToReturn<Response, Entity>(result, mapper);
        }

        public virtual async Task<IReturnModel<Response>> UpdateAsync(UpdateRequest entity)
        {
            IReturnModel<Entity> result = await repository.UpdateAsync(entity.ConvertToEntityCustom<Entity>(mapper));
            return ConvertToReturn<Response, Entity>(result, mapper);
        }
    }
    abstract public class ServiceBase : ServiceConvertToReturn, IService
    {
    }
}
