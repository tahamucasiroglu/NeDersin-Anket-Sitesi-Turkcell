using NeDersin.DTOs.Concrete.Request.Add;
using NeDersin.DTOs.Concrete.Request.Delete;
using NeDersin.DTOs.Concrete.Request.Update;
using NeDersin.DTOs.Concrete.Response.Get;
using NeDersin.ReturnModel.Abstract;
using NeDersin.Services.Service.Abstract.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeDersin.Services.Service.Abstract
{
    public interface IUserStatusService : IService<GetUserStatusResponseDTO, AddUserStatusRequestDTO, UpdateUserStatusRequestDTO, DeleteUserStatusRequestDTO>
    {
        public IReturnModel<GetUserStatusResponseDTO> GetById(int id);
        public Task<IReturnModel<GetUserStatusResponseDTO>> GetByIdAsync(int id);

    }
}
