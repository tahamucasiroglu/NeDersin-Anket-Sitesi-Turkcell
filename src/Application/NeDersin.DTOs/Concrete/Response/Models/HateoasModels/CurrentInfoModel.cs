using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeDersin.DTOs.Concrete.Response.Models.HateoasModels
{
    public sealed record class CurrentInfoModel
    {
        public string YourResponseLink { get; init; }
        public string ForHelp { get; init; }
        public string ForEverythingYouNeed { get; init; }
        public CurrentInfoModel(string yourResponseLink, string forHelp, string forEverythingYouNeed)
        {
            YourResponseLink = yourResponseLink;
            ForHelp = forHelp;
            ForEverythingYouNeed = forEverythingYouNeed;
        }

        static public CurrentInfoModel Create(string YourResponseLink, string ForHelp, string ForEverythingYouNeed) => new CurrentInfoModel(YourResponseLink, ForHelp, ForEverythingYouNeed);
    }
}
