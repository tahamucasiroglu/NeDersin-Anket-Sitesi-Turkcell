using NeDersin.DTOs.Concrete.Request.Add;
using NeDersin.DTOs.Concrete.Request.Delete;
using NeDersin.DTOs.Concrete.Request.Update;
using NeDersin.DTOs.Concrete.Response.Models.HateoasModels;
using NeDersin.DTOs.Concrete.Response.Models.MethodModels;
using NeDersin.WepAPI.StaticMethods;

namespace NeDersin.WepAPI.Enumeration.HateoasEnumeration
{
    public partial record class HateoasEnumeration
    {

        public HateoasModel AllControllerHateoas 
        { get => HateoasModel.Create
            (
                AllControllerGetMethodsHateoas,
                AllControllerCurrentInfoModel,
                AllControllerGetLinksHateoas
            ); 
        }

        internal Dictionary<string, Dictionary<string, string>> AllControllerGetMethodsHateoas
        {
            get
            {
                Dictionary<string, Dictionary<string, string>> dict = new Dictionary<string, Dictionary<string, string>>();
                foreach (string key in GetAnswerControllerGetMethodsHateoas.Keys) { dict.Add(key, GetAnswerControllerGetMethodsHateoas[key]); }
                foreach (string key in GetAnswerTypeControllerGetMethodsHateoas.Keys) { dict.Add(key, GetAnswerTypeControllerGetMethodsHateoas[key]); }
                foreach (string key in GetSurveyPageControllerGetMethodsHateoas.Keys) { dict.Add(key, GetSurveyPageControllerGetMethodsHateoas[key]); }
                foreach (string key in QuestionControllerAddMethodsHateoas.Keys) { dict.Add(key, QuestionControllerAddMethodsHateoas[key]); }
                foreach (string key in GetResponseControllerGetMethodsHateoas.Keys) { dict.Add(key, GetResponseControllerGetMethodsHateoas[key]); }
                foreach (string key in SurveyControllerGetMethodsHateoas.Keys) { dict.Add(key, SurveyControllerGetMethodsHateoas[key]); }
                foreach (string key in SurveyRatingControllerGetMethodsHateoas.Keys) { dict.Add(key, SurveyRatingControllerGetMethodsHateoas[key]); }
                foreach (string key in GetUserControllerGetMethodsHateoas.Keys) { dict.Add(key, GetUserControllerGetMethodsHateoas[key]); }
                foreach (string key in GetUserStatusControllerGetMethodsHateoas.Keys) { dict.Add(key, GetUserStatusControllerGetMethodsHateoas[key]); }
                return dict;
            }
        }

        internal List<LinkModel> AllControllerGetLinksHateoas
        {
            get
            {
                List<LinkModel> liste = new List<LinkModel>();
                GetAnswerControllerGetLinksHateoas.ForEach(liste.Add); //direk add kabul etmiyor mecbur bunu yaptım
                GetAnswerTypeControllerGetLinksHateoas.ForEach(liste.Add); //direk add kabul etmiyor mecbur bunu yaptım
                GetSurveyPageControllerGetLinksHateoas.ForEach(liste.Add); //direk add kabul etmiyor mecbur bunu yaptım
                QuestionControllerAddLinksHateoas.ForEach(liste.Add); //direk add kabul etmiyor mecbur bunu yaptım
                GetResponseControllerGetLinksHateoas.ForEach(liste.Add); //direk add kabul etmiyor mecbur bunu yaptım
                SurveyControllerGetLinksHateoas.ForEach(liste.Add); //direk add kabul etmiyor mecbur bunu yaptım
                SurveyRatingControllerGetLinksHateoas.ForEach(liste.Add); //direk add kabul etmiyor mecbur bunu yaptım
                GetUserControllerGetLinksHateoas.ForEach(liste.Add); //direk add kabul etmiyor mecbur bunu yaptım
                GetUserStatusControllerGetLinksHateoas.ForEach(liste.Add); //direk add kabul etmiyor mecbur bunu yaptım
                return liste;
            }
        }

        internal CurrentInfoModel AllControllerCurrentInfoModel { get; } = CurrentInfoModel.Create("https://localhost:7162/", "/help/", "/help/all");



    }
}
