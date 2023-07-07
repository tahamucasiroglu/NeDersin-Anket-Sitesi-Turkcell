using NeDersin.Utils.Attributes;
using System.ComponentModel.DataAnnotations;

namespace NeDersin.DTOs.Concrete.Response.Models.MethodModels
{
    public sealed class PageControllerGetMethodModel
    {
        [Required(ErrorMessage = "Sayfa Numarası Boş olamaz")]
        [NumberBiggerThan(0, nameof(pageNum))]
        public int pageNum { get; set; }
        [Required]
        public string order { get; set; } = null!;
        [Required]
        [NumberRange(10, 100, nameof(pageSize))]
        public int pageSize { get; set; }
    }
}
