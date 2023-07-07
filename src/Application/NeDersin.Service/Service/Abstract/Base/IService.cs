using NeDersin.DTOs.Abstract;
using NeDersin.DTOs.Concrete.Request.Add;
using NeDersin.DTOs.Concrete.Request.Delete;
using NeDersin.DTOs.Concrete.Request.Update;
using NeDersin.ReturnModel.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeDersin.Services.Service.Abstract.Base
{
    public interface IService<Response, AddRequest, UpdateRequest, DeleteRequest>
        where Response : class, IResponseDTO
        where AddRequest : class, IRequestDTO
        where UpdateRequest : class, IRequestDTO
        where DeleteRequest : class, IRequestDTO
    {
        public IReturnModel<IEnumerable<Response>> GetAll();
        public Task<IReturnModel<IEnumerable<Response>>> GetAllAsync();

        public IReturnModel<Response> Add(AddRequest entity);
        public Task<IReturnModel<Response>> AddAsync(AddRequest entity);
        public IReturnModel<Response> Update(UpdateRequest entity);
        public Task<IReturnModel<Response>> UpdateAsync(UpdateRequest entity);
        public IReturnModel<Response> Delete(DeleteRequest entity);
        public Task<IReturnModel<Response>> DeleteAsync(DeleteRequest entity);
    }
    public interface IService
    {
    }
}
