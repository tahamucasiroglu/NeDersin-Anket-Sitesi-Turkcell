using AutoMapper;
using NeDersin.DTOs.Concrete.Request.Add;
using NeDersin.DTOs.Concrete.Request.Delete;
using NeDersin.DTOs.Concrete.Request.Update;
using NeDersin.DTOs.Concrete.Response.Get;
using NeDersin.Entities.Concrete.Entities;
using NeDersin.Infrastructure.Repositoryies.Abstract;
using NeDersin.Infrastructure.Repositoryies.Concrete;
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
    public sealed class ResponseService : ServiceBase<Response, GetResponseResponseDTO, AddResponseRequestDTO, UpdateResponseRequestDTO, DeleteResponseRequestDTO>, IResponseService
    {
        public ResponseService(IResponseRepository repository, IMapper mapper) : base (repository, mapper) { }

        public IReturnModel<GetResponseResponseDTO> GetById(int id)
        {
            IReturnModel<Response> result = repository.Get(r => r.Id == id);
            return ConvertToReturn<GetResponseResponseDTO, Response>(result, mapper);
        }

        public async Task<IReturnModel<GetResponseResponseDTO>> GetByIdAsync(int id)
        {
            IReturnModel<Response> result = await repository.GetAsync(r => r.Id == id);
            return ConvertToReturn<GetResponseResponseDTO, Response>(result, mapper);
        }

        public IReturnModel<IEnumerable<GetResponseResponseDTO>> GetByQuestionId(int questionId)
        {
            IReturnModel<IEnumerable<Response>> result = repository.GetAll(r => r.QuestionId == questionId);
            return ConvertToReturn<GetResponseResponseDTO, Response>(result, mapper);
        }

        public async Task<IReturnModel<IEnumerable<GetResponseResponseDTO>>> GetByQuestionIdAsync(int questionId)
        {
            IReturnModel<IEnumerable<Response>> result = await repository.GetAllAsync(r => r.QuestionId == questionId);
            return ConvertToReturn<GetResponseResponseDTO, Response>(result, mapper);
        }

        public IReturnModel<IEnumerable<GetResponseResponseDTO>> GetByUserId(int userId)
        {
            IReturnModel<IEnumerable<Response>> result = repository.GetAll(r => r.UserId == userId);
            return ConvertToReturn<GetResponseResponseDTO, Response>(result, mapper);
        }

        public async Task<IReturnModel<IEnumerable<GetResponseResponseDTO>>> GetByUserIdAsync(int userId)
        {
            IReturnModel<IEnumerable<Response>> result = await repository.GetAllAsync(r => r.UserId == userId);
            return ConvertToReturn<GetResponseResponseDTO, Response>(result, mapper);
        }
    }
}
