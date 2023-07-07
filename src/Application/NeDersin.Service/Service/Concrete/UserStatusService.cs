using AutoMapper;
using NeDersin.DTOs.Concrete.Request.Add;
using NeDersin.DTOs.Concrete.Request.Delete;
using NeDersin.DTOs.Concrete.Request.Update;
using NeDersin.DTOs.Concrete.Response.Get;
using NeDersin.Entities.Concrete.Entities;
using NeDersin.Infrastructure.Repositoryies.Abstract;
using NeDersin.Infrastructure.Repositoryies.Abstract.Base;
using NeDersin.ReturnModel.Abstract;
using NeDersin.Services.Extensions;
using NeDersin.Services.Service.Abstract;
using NeDersin.Services.Service.Concrete.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeDersin.Services.Service.Concrete
{
    public sealed class UserStatusService : ServiceBase<UserStatus, GetUserStatusResponseDTO, AddUserStatusRequestDTO, UpdateUserStatusRequestDTO, DeleteUserStatusRequestDTO>, IUserStatusService
    {
        public UserStatusService(IUserStatusRepository repository, IMapper mapper) : base(repository, mapper) { }
        public IReturnModel<GetUserStatusResponseDTO> GetById(int id)
        {
            IReturnModel<UserStatus> result = repository.Get(r => r.Id == id);
            return ConvertToReturn<GetUserStatusResponseDTO, UserStatus>(result, mapper);
        }

        public async Task<IReturnModel<GetUserStatusResponseDTO>> GetByIdAsync(int id)
        {
            IReturnModel<UserStatus> result = await repository.GetAsync(r => r.Id == id);
            return ConvertToReturn<GetUserStatusResponseDTO, UserStatus>(result, mapper);
        }
    }
}
