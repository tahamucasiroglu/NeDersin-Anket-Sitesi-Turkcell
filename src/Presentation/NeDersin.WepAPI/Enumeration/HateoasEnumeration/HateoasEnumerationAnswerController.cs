using NeDersin.DTOs.Concrete.Request.Add;
using NeDersin.DTOs.Concrete.Request.Delete;
using NeDersin.DTOs.Concrete.Request.Update;
using NeDersin.DTOs.Concrete.Response.Models.HateoasModels;
using NeDersin.WepAPI.StaticMethods;

namespace NeDersin.WepAPI.Enumeration.HateoasEnumeration
{
    public partial record class HateoasEnumeration
    {

        public HateoasModel GetAnswerControllerHateoas 
        { get => 
                HateoasModel.Create(
                    GetAnswerControllerGetMethodsHateoas, 
                    GetAnswerControllerCurrentInfoModel, GetAnswerControllerGetLinksHateoas
                    ); 
        }
        internal List<LinkModel> GetAnswerControllerGetLinksHateoas { get; } = new List<LinkModel>() {
            LinkModel.Create("/Answer/id", "Get", "Json"),
            LinkModel.Create("/Answer/", "Update", "Json"),
            LinkModel.Create("/Answer/", "Delete", "Json"),
            LinkModel.Create("/Answer/", "Post", "Json"), };
        internal Dictionary<string, Dictionary<string, string>> GetAnswerControllerGetMethodsHateoas
        {
            get => new Dictionary<string, Dictionary<string, string>>()
            {
                {"Add", StaticHelperMethods.GetPropertyDict(typeof(AddAnswerRequestDTO)) },
                {"Update", StaticHelperMethods.GetPropertyDict(typeof(UpdateAnswerRequestDTO)) },
                {"Delete", StaticHelperMethods.GetPropertyDict(typeof(DeleteAnswerRequestDTO)) },
            };
        }
        internal CurrentInfoModel GetAnswerControllerCurrentInfoModel { get; } = CurrentInfoModel.Create("https://localhost:7162/{Answer}", "/help/answer", "/help/all");
    }
}
