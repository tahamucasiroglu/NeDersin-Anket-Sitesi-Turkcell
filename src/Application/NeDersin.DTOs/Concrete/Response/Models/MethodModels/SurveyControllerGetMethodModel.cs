using NeDersin.Utils.Attributes;

namespace NeDersin.DTOs.Concrete.Response.Models.MethodModels
{
    public sealed class SurveyControllerGetMethodModel
    {
        [GuidValidation]
        public Guid Address { get; set; }
    }
}
