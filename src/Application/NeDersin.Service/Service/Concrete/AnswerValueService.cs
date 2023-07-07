using AutoMapper;
using NeDersin.DTOs.Concrete.Models;
using NeDersin.DTOs.Concrete.Request.Add;
using NeDersin.DTOs.Concrete.Request.Delete;
using NeDersin.DTOs.Concrete.Request.Update;
using NeDersin.DTOs.Concrete.Response.Get;
using NeDersin.DTOs.Extensions;
using NeDersin.Entities.Abstract;
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
    public sealed class AnswerValueService : ServiceBase<AnswerValue, GetAnswerValueResponseDTO, AddAnswerValueRequestDTO, UpdateAnswerValueRequestDTO, DeleteAnswerValueRequestDTO>, IAnswerValueService
    {
        public AnswerValueService(IAnswerValueRepository repository, IMapper mapper) : base(repository, mapper) { }

        public IReturnModel<GetAnswerValueResponseDTO> Add(AnswerValueModel entity)
        {
            IReturnModel<AnswerValue> result = repository.Add(
                new AddAnswerValueRequestDTO()
                {
                    Name = entity.GetSHA1HashCode(),
                    Value = entity.ToJson()
                }.ConvertToEntity(mapper)
                );
            return ConvertToReturn<GetAnswerValueResponseDTO, AnswerValue>(result, mapper);
        }

        public async Task<IReturnModel<GetAnswerValueResponseDTO>> AddAsync(AnswerValueModel entity)
        {
            IReturnModel<AnswerValue> result = await repository.AddAsync(
                new AddAnswerValueRequestDTO()
                {
                    Name = entity.GetSHA1HashCode(),
                    Value = entity.ToJson()
                }.ConvertToEntity(mapper)
                );
            return ConvertToReturn<GetAnswerValueResponseDTO, AnswerValue>(result, mapper);
        }

        public IReturnModel<GetAnswerValueResponseDTO> GetById(int id)
        {
            IReturnModel<AnswerValue> result = repository.Get(r => r.Id == id);
            return ConvertToReturn<GetAnswerValueResponseDTO, AnswerValue>(result, mapper);
        }

        public async Task<IReturnModel<GetAnswerValueResponseDTO>> GetByIdAsync(int id)
        {
            IReturnModel<AnswerValue> result = await repository.GetAsync(r => r.Id == id);
            return ConvertToReturn<GetAnswerValueResponseDTO, AnswerValue>(result, mapper);
        }

        public IReturnModel<GetAnswerValueResponseDTO> GetByName(string name)
        {
            IReturnModel<AnswerValue> result = repository.Get(r => r.Name == name);
            return ConvertToReturn<GetAnswerValueResponseDTO, AnswerValue>(result, mapper);
        }

        public async Task<IReturnModel<GetAnswerValueResponseDTO>> GetByNameAsync(string name)
        {
            IReturnModel<AnswerValue> result = await repository.GetAsync(r => r.Name == name);
            return ConvertToReturn<GetAnswerValueResponseDTO, AnswerValue>(result, mapper);
        }

        public IReturnModel<bool> IsExist(string name)
        {
            return repository.IsExist(r => r.Name == name);
        }

        public async Task<IReturnModel<bool>> IsExistAsync(string name)
        {
            return await repository.IsExistAsync(r => r.Name == name);
        }
    }
}
