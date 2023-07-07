using AutoMapper;
using NeDersin.DTOs.Concrete.Request.Add;
using NeDersin.DTOs.Concrete.Request.Delete;
using NeDersin.DTOs.Concrete.Request.Update;
using NeDersin.DTOs.Concrete.Response.Get;
using NeDersin.Entities.Concrete.Entities;
using NeDersin.Infrastructure.Repositoryies.Abstract;
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
    public sealed class AnswerTypeService : ServiceBase<AnswerType, GetAnswerTypeResponseDTO, AddAnswerTypeRequestDTO, UpdateAnswerTypeRequestDTO, DeleteAnswerTypeRequestDTO>, IAnswerTypeService
    {
        public AnswerTypeService(IAnswerTypeRepository repository, IMapper mapper) : base(repository, mapper) { }

        public IReturnModel<GetAnswerTypeResponseDTO> GetById(int id)
        {
            IReturnModel<AnswerType> result = repository.Get(r => r.Id == id);
            return ConvertToReturn<GetAnswerTypeResponseDTO, AnswerType>(result, mapper);
        }

        public async Task<IReturnModel<GetAnswerTypeResponseDTO>> GetByIdAsync(int id)
        {
            IReturnModel<AnswerType> result = await repository.GetAsync(r => r.Id == id);
            return ConvertToReturn<GetAnswerTypeResponseDTO, AnswerType>(result, mapper);
        }

        public IReturnModel<GetAnswerTypeResponseDTO> GetByName(string name)
        {
            IReturnModel<AnswerType> result = repository.Get(r => r.Name == name);
            return ConvertToReturn<GetAnswerTypeResponseDTO, AnswerType>(result, mapper);
        }

        public async Task<IReturnModel<GetAnswerTypeResponseDTO>> GetByNameAsync(string name)
        {
            IReturnModel<AnswerType> result = await repository.GetAsync(r => r.Name == name);
            return ConvertToReturn<GetAnswerTypeResponseDTO, AnswerType>(result, mapper);
        }
    }
}
