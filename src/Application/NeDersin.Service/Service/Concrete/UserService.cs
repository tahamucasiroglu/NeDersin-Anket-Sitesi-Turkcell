using AutoMapper;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using NeDersin.DTOs.Concrete.Request.Add;
using NeDersin.DTOs.Concrete.Request.Delete;
using NeDersin.DTOs.Concrete.Request.Update;
using NeDersin.DTOs.Concrete.Response.Get;
using NeDersin.DTOs.Extensions;
using NeDersin.Entities.Concrete.Entities;
using NeDersin.Infrastructure.Repositoryies.Abstract;
using NeDersin.ReturnModel.Abstract;
using NeDersin.ReturnModel.Concrete;
using NeDersin.Services.Extensions;
using NeDersin.Services.Service.Abstract;
using NeDersin.Services.Service.Concrete.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace NeDersin.Services.Service.Concrete
{
    public sealed class UserService : ServiceBase<User, GetUserResponseDTO, AddUserRequestDTO, UpdateUserRequestDTO, DeleteUserRequestDTO>, IUserService
    {
        public UserService(IUserRepository repository, IMapper mapper) : base(repository, mapper) { }



        public IReturnModel<bool> CheckPassword(int id, string password)
        {
            IReturnModel<User> result = repository.Get(r => r.Id == id);
            Console.WriteLine($"status = {result.Status} data = {result.Data?.ToJson()} mesage = {result.Message}");
            if (!result.Status || result.Data == null) { return new ErrorReturnModel<bool>(result.Message,result.Exception); }
            return new SuccessReturnModel<bool>
                (
                    result.Data.Password == password
                );
        }

        public IReturnModel<bool> CheckPassword(string email, string password)
        {
            IReturnModel<User> result = repository.Get(r => r.Email == email);
            if (!result.Status || result.Data == null) { return new ErrorReturnModel<bool>(result.Message, result.Exception); }
            return new SuccessReturnModel<bool>
                (
                    result.Data.Password == password
                );
        }

        public IReturnModel<bool> CheckPassword(GetUserResponseDTO user, string password)
        {
            IReturnModel<User> result = repository.Get(r => r.Id == user.Id);
            if (!result.Status || result.Data == null) { result = repository.Get(r => r.Email == user.Email); }
            if (!result.Status || result.Data == null) { return new ErrorReturnModel<bool>(result.Message, result.Exception); }
            return new SuccessReturnModel<bool>
                (
                    result.Data.Password == password
                );
        }

        public async Task<IReturnModel<bool>> CheckPasswordAsync(int id, string password)
        {
            IReturnModel<User> result = await repository.GetAsync(r => r.Id == id);
            if (!result.Status || result.Data == null) { return new ErrorReturnModel<bool>(result.Message, result.Exception); }
            return new SuccessReturnModel<bool>
                (
                    result.Data.Password == password
                );
        }

        public async Task<IReturnModel<bool>> CheckPasswordAsync(string email, string password)
        {
            IReturnModel<User> result = await repository.GetAsync(r => r.Email == email);
            if (!result.Status || result.Data == null) { return new ErrorReturnModel<bool>(result.Message, result.Exception); }
            return new SuccessReturnModel<bool>
                (
                    result.Data.Password == password
                );
        }

        public async Task<IReturnModel<bool>> CheckPasswordAsync(GetUserResponseDTO user, string password)
        {
            IReturnModel<User> result = await repository.GetAsync(r => r.Id == user.Id);
            if (!result.Status || result.Data == null) { result = await repository.GetAsync(r => r.Email == user.Email); }
            if (!result.Status || result.Data == null) { return new ErrorReturnModel<bool>(); }
            return new SuccessReturnModel<bool>
                (
                    result.Data.Password == password
                );
        }

        public IReturnModel<GetUserResponseDTO> GetByEmail(string email)
        {
            IReturnModel<User> result = repository.Get(r => r.Email == email);
            return ConvertToReturn<GetUserResponseDTO, User>(result, mapper);
        }

        public async Task<IReturnModel<GetUserResponseDTO>> GetByEmailAsync(string email)
        {
            IReturnModel<User> result = await repository.GetAsync(r => r.Email == email);
            return ConvertToReturn<GetUserResponseDTO, User>(result, mapper);
        }

        public IReturnModel<GetUserResponseDTO> GetById(int id)
        {
            IReturnModel<User> result = repository.Get(r => r.Id == id);
            return ConvertToReturn<GetUserResponseDTO, User>(result, mapper);
        }

        public async Task<IReturnModel<GetUserResponseDTO>> GetByIdAsync(int id)
        {
            IReturnModel<User> result = await repository.GetAsync(r => r.Id == id);
            return ConvertToReturn<GetUserResponseDTO, User>(result, mapper);
        }

        public IReturnModel<IEnumerable<GetUserResponseDTO>> GetByName(string name)
        {
            IReturnModel<IEnumerable<User>> result = repository.GetAll(r => r.Name.Contains(name));
            return ConvertToReturn<GetUserResponseDTO, User>(result, mapper);
        }

        public async Task<IReturnModel<IEnumerable<GetUserResponseDTO>>> GetByNameAsync(string name)
        {
            IReturnModel<IEnumerable<User>> result = await repository.GetAllAsync(r => r.Name.Contains(name));
            return ConvertToReturn<GetUserResponseDTO, User>(result, mapper);
        }

        public IReturnModel<GetUserResponseDTO> GetByPhone(string phone)
        {
            IReturnModel<User> result = repository.Get(r => r.Phone == phone);
            return ConvertToReturn<GetUserResponseDTO, User>(result, mapper);
        }

        public async Task<IReturnModel<GetUserResponseDTO>> GetByPhoneAsync(string phone)
        {
            IReturnModel<User> result = await repository.GetAsync(r => r.Phone == phone);
            return ConvertToReturn<GetUserResponseDTO, User>(result, mapper);
        }

        public IReturnModel<IEnumerable<GetUserResponseDTO>> GetByStatusId(int id)
        {
            IReturnModel<IEnumerable<User>> result = repository.GetAll(r => r.UserStatusId == id);
            return ConvertToReturn<GetUserResponseDTO, User>(result, mapper);
        }

        public async Task<IReturnModel<IEnumerable<GetUserResponseDTO>>> GetByStatusIdAsync(int id)
        {
            IReturnModel<IEnumerable<User>> result = await repository.GetAllAsync(r => r.UserStatusId == id);
            return ConvertToReturn<GetUserResponseDTO, User>(result, mapper);
        }
    }
}
