using Microsoft.AspNetCore.Mvc;
using NeDersin.DTOs.Abstract;
using NeDersin.DTOs.Concrete.Request.Add;

namespace NeDersin.WepAPI.Controllers.Base
{
    public interface IBasePostController<TAdd, TUpdate, TDelete>
        where TAdd : class, IRequestDTO, new()
        where TUpdate : class, IRequestDTO, new()
        where TDelete : class, IRequestDTO, new()
    {
        public IActionResult Add([FromBody] TAdd survey);
        public IActionResult Update([FromBody] TUpdate survey);
        public IActionResult Delete([FromBody] TDelete survey);
    }
}
