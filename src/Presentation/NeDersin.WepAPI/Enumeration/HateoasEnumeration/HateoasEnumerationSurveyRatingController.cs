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
        public HateoasModel GetSurveyRatingControllerHateoas
        {
            get =>
                HateoasModel.Create(
                    SurveyRatingControllerGetMethodsHateoas,
                    GetSurveyRatingControllerCurrentInfoModel,
                    SurveyRatingControllerGetLinksHateoas
                    );
        }
        public List<LinkModel> SurveyRatingControllerGetLinksHateoas { get; } = new List<LinkModel>()
        {
            new LinkModel("/", "Post", "Json"),
            new LinkModel("/", "Delete", "Json"),
            new LinkModel("/", "Put", "Json"),
            new LinkModel("/GetBySurveyId", "Get", "Json"),
            new LinkModel("/GetByUserId", "Get", "Json"),
            new LinkModel("/GetByRating", "Get", "Json"),

        };

        public Dictionary<string, Dictionary<string, string>> SurveyRatingControllerGetMethodsHateoas
        {
            get => new Dictionary<string, Dictionary<string, string>>()
            {
                {"Get", StaticHelperMethods.GetPropertyDict(typeof(GetSurveyRatingResponseDTO)) },
                {"Add", StaticHelperMethods.GetPropertyDict(typeof(AddSurveyRatingRequestDTO)) },
                {"Update", StaticHelperMethods.GetPropertyDict(typeof(UpdateSurveyRatingRequestDTO)) },
                {"Delete", StaticHelperMethods.GetPropertyDict(typeof(DeleteSurveyRatingRequestDTO)) },
            };
        }

        internal CurrentInfoModel GetSurveyRatingControllerCurrentInfoModel { get; } = CurrentInfoModel.Create("https://localhost:7162/{SurveyRating}", "/help/SurveyRating", "/help/all");
    }
}
