using NeDersin.DTOs.Concrete.Request.Add;
using NeDersin.DTOs.Concrete.Request.Delete;
using NeDersin.DTOs.Concrete.Request.Update;
using NeDersin.DTOs.Concrete.Response.Models.HateoasModels;
using NeDersin.WepAPI.StaticMethods;

namespace NeDersin.WepAPI.Enumeration.HateoasEnumeration
{
    public partial record class HateoasEnumeration
    {

        public HateoasModel GetUserStatusControllerHateoas
        {
            get =>
                HateoasModel.Create(
                    GetUserStatusControllerGetMethodsHateoas,
                    GetUserStatusControllerCurrentInfoModel, GetUserStatusControllerGetLinksHateoas
                    );
        }
        internal List<LinkModel> GetUserStatusControllerGetLinksHateoas { get; } = new List<LinkModel>() {
            LinkModel.Create("/UserStatus/Id", "Get", "Json"),
            LinkModel.Create("/UserStatus/", "Update", "Json"),
            LinkModel.Create("/UserStatus/", "Delete", "Json"),
            LinkModel.Create("/UserStatus/", "Post", "Json"), };
        internal Dictionary<string, Dictionary<string, string>> GetUserStatusControllerGetMethodsHateoas
        {
            get => new Dictionary<string, Dictionary<string, string>>()
            {
                {"Add", StaticHelperMethods.GetPropertyDict(typeof(AddUserRequestDTO)) },
                {"Update", StaticHelperMethods.GetPropertyDict(typeof(UpdateUserRequestDTO)) },
                {"Delete", StaticHelperMethods.GetPropertyDict(typeof(DeleteUserRequestDTO)) },
            };
        }
        internal CurrentInfoModel GetUserStatusControllerCurrentInfoModel { get; } = CurrentInfoModel.Create("https://localhost:7162/{User}", "/help/User", "/help/all");
    }
}
