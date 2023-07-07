using NeDersin.DTOs.Concrete.Models;
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
    public interface IAnswerValueService : IService<GetAnswerValueResponseDTO, AddAnswerValueRequestDTO, UpdateAnswerValueRequestDTO, DeleteAnswerValueRequestDTO>
    {
        public IReturnModel<GetAnswerValueResponseDTO> GetById(int id);
        public Task<IReturnModel<GetAnswerValueResponseDTO>> GetByIdAsync(int id);
        public IReturnModel<GetAnswerValueResponseDTO> GetByName(string name);
        public Task<IReturnModel<GetAnswerValueResponseDTO>> GetByNameAsync(string name);
        public IReturnModel<bool> IsExist(string name);
        public Task<IReturnModel<bool>> IsExistAsync(string name);
        public IReturnModel<GetAnswerValueResponseDTO> Add(AnswerValueModel entity);
        public Task<IReturnModel<GetAnswerValueResponseDTO>> AddAsync(AnswerValueModel entity);

    }
}
