using NeDersin.DTOs.Concrete.Request.Add;
using NeDersin.DTOs.Concrete.Request.Delete;
using NeDersin.DTOs.Concrete.Request.Update;
using NeDersin.DTOs.Concrete.Response.Models.HateoasModels;
using NeDersin.WepAPI.StaticMethods;

namespace NeDersin.WepAPI.Enumeration.HateoasEnumeration
{
    public partial record class HateoasEnumeration
    {

        public HateoasModel GetAnswerTypeControllerHateoas
        {
            get =>
                HateoasModel.Create(
                    GetAnswerTypeControllerGetMethodsHateoas,
                    GetAnswerTypeControllerCurrentInfoModel, GetAnswerTypeControllerGetLinksHateoas
                    );
        }
        internal List<LinkModel> GetAnswerTypeControllerGetLinksHateoas { get; } = new List<LinkModel>() {
            LinkModel.Create("/AnswerType/id", "Get", "Json"),
            LinkModel.Create("/AnswerType/", "Update", "Json"),
            LinkModel.Create("/AnswerType/", "Delete", "Json"),
            LinkModel.Create("/AnswerType/", "Post", "Json"), };
        internal Dictionary<string, Dictionary<string, string>> GetAnswerTypeControllerGetMethodsHateoas
        {
            get => new Dictionary<string, Dictionary<string, string>>()
            {
                {"Add", StaticHelperMethods.GetPropertyDict(typeof(AddAnswerTypeRequestDTO)) },
                {"Update", StaticHelperMethods.GetPropertyDict(typeof(UpdateAnswerTypeRequestDTO)) },
                {"Delete", StaticHelperMethods.GetPropertyDict(typeof(DeleteAnswerTypeRequestDTO)) },
            };
        }
        internal CurrentInfoModel GetAnswerTypeControllerCurrentInfoModel { get; } = CurrentInfoModel.Create("https://localhost:7162/{AnswerType}", "/help/answertype", "/help/all");
    }
}
