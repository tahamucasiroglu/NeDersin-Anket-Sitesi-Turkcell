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
        public HateoasModel GetResponseControllerHateoas
        {
            get =>
                HateoasModel.Create(
                    GetResponseControllerGetMethodsHateoas,
                    GetResponseControllerCurrentInfoModel, 
                    GetResponseControllerGetLinksHateoas
                    );
        }
        internal List<LinkModel> GetResponseControllerGetLinksHateoas { get; } = new List<LinkModel>() {
            LinkModel.Create("/Response/Id", "Get", "Json"),
            LinkModel.Create("/Response/UserId", "Get", "Json"),
            LinkModel.Create("/Response/QuestionId", "Get", "Json"),
            LinkModel.Create("/Response/", "Update", "Json"),
            LinkModel.Create("/Response/", "Delete", "Json"),
            LinkModel.Create("/Response/", "Post", "Json"), };
        internal Dictionary<string, Dictionary<string, string>> GetResponseControllerGetMethodsHateoas
        {
            get => new Dictionary<string, Dictionary<string, string>>()
            {
                {"Add", StaticHelperMethods.GetPropertyDict(typeof(AddResponseRequestDTO)) },
                {"Update", StaticHelperMethods.GetPropertyDict(typeof(UpdateResponseRequestDTO)) },
                {"Delete",  StaticHelperMethods.GetPropertyDict(typeof(DeleteResponseRequestDTO)) },
            };
        }
        internal CurrentInfoModel GetResponseControllerCurrentInfoModel { get; } = CurrentInfoModel.Create("https://localhost:7162/{Response}", "/help/Response", "/help/all");
    }
}
