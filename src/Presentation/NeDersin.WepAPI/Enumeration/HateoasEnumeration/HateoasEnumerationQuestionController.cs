using NeDersin.DTOs.Concrete.Request.Add;
using NeDersin.DTOs.Concrete.Request.Delete;
using NeDersin.DTOs.Concrete.Request.Update;
using NeDersin.DTOs.Concrete.Response.Models.HateoasModels;
using NeDersin.WepAPI.StaticMethods;
using System.Reflection;

namespace NeDersin.WepAPI.Enumeration.HateoasEnumeration
{
    public partial record class HateoasEnumeration
    {
        public HateoasModel QuestionControllerHateoas { get => HateoasModel.Create(QuestionControllerAddMethodsHateoas, QuestionControllerHateoasCurrentInfoModel, QuestionControllerAddLinksHateoas); }
        internal List<LinkModel> QuestionControllerAddLinksHateoas { get; } = new List<LinkModel>() {
            LinkModel.Create("/question/", "Post", "Json"),
            LinkModel.Create("/question/", "Update", "Json"),
            LinkModel.Create("/question/", "Delete", "Json") };

        internal Dictionary<string, Dictionary<string, string>> QuestionControllerAddMethodsHateoas
        {
            get => new Dictionary<string, Dictionary<string, string>>()
            {
                {"Get", StaticHelperMethods.GetPropertyDict(typeof(AddQuestionRequestDTO)) },
                {"Update", StaticHelperMethods.GetPropertyDict(typeof(UpdateQuestionRequestDTO)) },
                {"Delete",  StaticHelperMethods.GetPropertyDict(typeof(DeleteQuestionRequestDTO)) },
            };
        }

        internal CurrentInfoModel QuestionControllerHateoasCurrentInfoModel { get; } = CurrentInfoModel.Create("https://localhost:7162/{Question}", "/help/question", "/help/all");
    }
}
