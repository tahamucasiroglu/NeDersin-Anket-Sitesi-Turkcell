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
    public interface IUserService : IService<GetUserResponseDTO, AddUserRequestDTO, UpdateUserRequestDTO, DeleteUserRequestDTO>
    {
        public IReturnModel<GetUserResponseDTO> GetById(int id);
        public Task<IReturnModel<GetUserResponseDTO>> GetByIdAsync(int id);
        public IReturnModel<IEnumerable<GetUserResponseDTO>> GetByName(string name);
        public Task<IReturnModel<IEnumerable<GetUserResponseDTO>>> GetByNameAsync(string name);
        public IReturnModel<GetUserResponseDTO> GetByEmail(string email);
        public Task<IReturnModel<GetUserResponseDTO>> GetByEmailAsync(string email);
        public IReturnModel<GetUserResponseDTO> GetByPhone(string phone);
        public Task<IReturnModel<GetUserResponseDTO>> GetByPhoneAsync(string phone);
        public IReturnModel<IEnumerable<GetUserResponseDTO>> GetByStatusId(int id);
        public Task<IReturnModel<IEnumerable<GetUserResponseDTO>>> GetByStatusIdAsync(int id);
        public IReturnModel<bool> CheckPassword(int id, string password);
        public IReturnModel<bool> CheckPassword(string email, string password);
        public IReturnModel<bool> CheckPassword(GetUserResponseDTO user, string password);
        public Task<IReturnModel<bool>> CheckPasswordAsync(int id, string password);
        public Task<IReturnModel<bool>> CheckPasswordAsync(string email, string password);
        public Task<IReturnModel<bool>> CheckPasswordAsync(GetUserResponseDTO user, string password);

    }
}
