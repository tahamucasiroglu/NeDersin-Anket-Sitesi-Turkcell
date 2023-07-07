using NeDersin.DTOs.Concrete.Request.Add;
using NeDersin.DTOs.Concrete.Request.Delete;
using NeDersin.DTOs.Concrete.Request.Update;
using NeDersin.DTOs.Concrete.Response.Models.HateoasModels;
using NeDersin.WepAPI.StaticMethods;

namespace NeDersin.WepAPI.Enumeration.HateoasEnumeration
{
    public partial record class HateoasEnumeration
    {

        public HateoasModel GetUserControllerHateoas
        {
            get =>
                HateoasModel.Create(
                    GetUserControllerGetMethodsHateoas,
                    GetUserControllerCurrentInfoModel, GetUserControllerGetLinksHateoas
                    );
        }
        internal List<LinkModel> GetUserControllerGetLinksHateoas { get; } = new List<LinkModel>() {
            LinkModel.Create("/User/id", "Get", "Json"),
            LinkModel.Create("/User/", "Update", "Json"),
            LinkModel.Create("/User/", "Delete", "Json"),
            LinkModel.Create("/User/", "Post", "Json"), };
        internal Dictionary<string, Dictionary<string, string>> GetUserControllerGetMethodsHateoas
        {
            get => new Dictionary<string, Dictionary<string, string>>()
            {
                {"Add", StaticHelperMethods.GetPropertyDict(typeof(AddUserRequestDTO)) },
                {"Update", StaticHelperMethods.GetPropertyDict(typeof(UpdateUserRequestDTO)) },
                {"Delete", StaticHelperMethods.GetPropertyDict(typeof(DeleteUserRequestDTO)) },
            };
        }
        internal CurrentInfoModel GetUserControllerCurrentInfoModel { get; } = CurrentInfoModel.Create("https://localhost:7162/{User}", "/help/User", "/help/all");
    }
}
