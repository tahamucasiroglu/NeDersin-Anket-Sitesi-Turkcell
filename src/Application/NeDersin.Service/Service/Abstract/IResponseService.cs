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
    public interface IResponseService : IService<GetResponseResponseDTO, AddResponseRequestDTO, UpdateResponseRequestDTO, DeleteResponseRequestDTO>
    {
        public IReturnModel<GetResponseResponseDTO> GetById(int id);
        public Task<IReturnModel<GetResponseResponseDTO>> GetByIdAsync(int id);
        public IReturnModel<IEnumerable<GetResponseResponseDTO>> GetByUserId(int userId);
        public Task<IReturnModel<IEnumerable<GetResponseResponseDTO>>> GetByUserIdAsync(int userId);
        public IReturnModel<IEnumerable<GetResponseResponseDTO>> GetByQuestionId(int questionId);
        public Task<IReturnModel<IEnumerable<GetResponseResponseDTO>>> GetByQuestionIdAsync(int questionId);
    }
}
