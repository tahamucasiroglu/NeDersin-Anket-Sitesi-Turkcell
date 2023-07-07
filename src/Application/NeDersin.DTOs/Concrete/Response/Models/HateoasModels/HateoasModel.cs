using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeDersin.DTOs.Concrete.Response.Models.HateoasModels
{
    public sealed record class HateoasModel
    {
        public Dictionary<string, Dictionary<string, string>>? Methods { get; init; }
        public CurrentInfoModel CurrentInfo { get; init; }
        public IEnumerable<LinkModel> LinkModel { get; init; }
        public HateoasModel(Dictionary<string, Dictionary<string, string>>? methods, CurrentInfoModel currentInfo, IEnumerable<LinkModel> linkModel)
        {
            Methods = methods;
            CurrentInfo = currentInfo;
            LinkModel = linkModel;
        }
        static public HateoasModel Create(Dictionary<string, Dictionary<string, string>>? Methods, CurrentInfoModel CurrentInfo, IEnumerable<LinkModel> LinkModel) => new HateoasModel(Methods, CurrentInfo, LinkModel);
    }
}
