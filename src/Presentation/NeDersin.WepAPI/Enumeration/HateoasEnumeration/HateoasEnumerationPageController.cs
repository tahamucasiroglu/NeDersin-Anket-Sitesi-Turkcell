
using NeDersin.DTOs.Concrete.Models;
using NeDersin.DTOs.Concrete.Request.Add;
using NeDersin.DTOs.Concrete.Request.Delete;
using NeDersin.DTOs.Concrete.Request.Update;
using NeDersin.DTOs.Concrete.Response.Models.HateoasModels;
using NeDersin.DTOs.Concrete.Response.Models.MethodModels;
using NeDersin.WepAPI.Enumeration;
using NeDersin.WepAPI.StaticMethods;

namespace NeDersin.WepAPI.Enumeration.HateoasEnumeration
{
    public partial record class HateoasEnumeration
    {

        public HateoasModel GetSurveyPageControllerHateoas { get => HateoasModel.Create(GetSurveyPageControllerGetMethodsHateoas, GetSurveyPageControllerCurrentInfoModel, GetSurveyPageControllerGetLinksHateoas); }
        internal List<LinkModel> GetSurveyPageControllerGetLinksHateoas { get; } = new List<LinkModel>() {
            LinkModel.Create("/{SurveyId}", "Get", "Json"),
            LinkModel.Create("/{SurveyId}", "Update", "Json"),
            LinkModel.Create("/{SurveyId}", "Delete", "Json"),
            LinkModel.Create("/page/", "Get", "Json") };
        internal Dictionary<string, Dictionary<string, string>> GetSurveyPageControllerGetMethodsHateoas
        {
            get => new Dictionary<string, Dictionary<string, string>>()
            {
                {"Get", StaticHelperMethods.GetPropertyDict(typeof(PageControllerGetMethodModel)) },
                {"Get - Survey", StaticHelperMethods.GetPropertyDict(typeof(SurveyControllerGetMethodModel)) },
                {"Update - Survey", StaticHelperMethods.GetPropertyDict(typeof(UpdateSurveyRequestDTO)) },
                {"Delete - Survey",  StaticHelperMethods.GetPropertyDict(typeof(DeleteSurveyRequestDTO)) },
            };
        }
        internal CurrentInfoModel GetSurveyPageControllerCurrentInfoModel { get; } = CurrentInfoModel.Create("https://localhost:7162/{Page}", "/help/getsurveypage", "/help/all");
    }
}
