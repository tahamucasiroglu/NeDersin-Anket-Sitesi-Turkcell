using AutoMapper;
using NeDersin.DTOs.Concrete.Request.Add;
using NeDersin.DTOs.Concrete.Request.Delete;
using NeDersin.DTOs.Concrete.Request.Update;
using NeDersin.DTOs.Concrete.Response.Get;
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
    public sealed class AnswerService : ServiceBase<Answer, GetAnswerResponseDTO, AddAnswerRequestDTO, UpdateAnswerRequestDTO, DeleteAnswerRequestDTO>, IAnswerService
    {
        public AnswerService(IAnswerRepository repository, IMapper mapper) : base(repository, mapper) { }

        public IReturnModel<IEnumerable<GetAnswerResponseDTO>> GetByQuestionId(int id)
        {
            IReturnModel<IEnumerable<Answer>> result = repository.GetAll(r => r.QuestionId == id);
            return ConvertToReturn<GetAnswerResponseDTO, Answer>(result, mapper);

        }

        public async Task<IReturnModel<IEnumerable<GetAnswerResponseDTO>>> GetByQuestionIdAsync(int id)
        {
            IReturnModel<IEnumerable<Answer>> result = await repository.GetAllAsync(r => r.QuestionId == id);
            return ConvertToReturn<GetAnswerResponseDTO, Answer>(result, mapper);
        }
    }
}
