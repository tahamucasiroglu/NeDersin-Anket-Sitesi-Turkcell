using NeDersin.DTOs.Concrete.Request.Add;
using NeDersin.DTOs.Concrete.Request.Delete;
using NeDersin.DTOs.Concrete.Request.Update;
using NeDersin.DTOs.Concrete.Response.Get;
using NeDersin.DTOs.Concrete.Response.Models.HateoasModels;
using NeDersin.WepAPI.StaticMethods;

namespace NeDersin.WepAPI.Enumeration.HateoasEnumeration
{
    public partial record class HateoasEnumeration
    {
        public HateoasModel GetSurveyControllerHateoas
        {
            get =>
                HateoasModel.Create(
                    SurveyControllerGetMethodsHateoas,
                    GetSurveyControllerCurrentInfoModel,
                    SurveyControllerGetLinksHateoas
                    );
        }
    public List<LinkModel> SurveyControllerGetLinksHateoas { get; } = new List<LinkModel>() 
        {
            new LinkModel("/", "Get", "Json"),
            new LinkModel("/", "Post", "Json"),
            new LinkModel("/", "Put", "Json"),
            new LinkModel("/", "Delete", "Json")
        };

        public Dictionary<string, Dictionary<string, string>> SurveyControllerGetMethodsHateoas
        {
            get => new Dictionary<string, Dictionary<string, string>>()
            {
                {"Get", StaticHelperMethods.GetPropertyDict(typeof(GetSurveyResponseDTO)) },
                {"Add", StaticHelperMethods.GetPropertyDict(typeof(AddSurveyRequestDTO)) },
                {"Update", StaticHelperMethods.GetPropertyDict(typeof(UpdateSurveyRequestDTO)) },
                {"Delete", StaticHelperMethods.GetPropertyDict(typeof(DeleteSurveyRequestDTO)) },

            };
        }

        internal CurrentInfoModel GetSurveyControllerCurrentInfoModel { get; } = CurrentInfoModel.Create("https://localhost:7162/{Survey}", "/help/Response", "/help/all");
    }
}
