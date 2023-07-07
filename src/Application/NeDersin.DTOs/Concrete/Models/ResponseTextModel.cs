using NeDersin.DTOs.Abstract;
using NeDersin.DTOs.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace NeDersin.DTOs.Concrete.Models
{
    public class ResponseTextModel : ModelBase<ResponseTextModel>
    {

        List<string> Values { get; set; } = new List<string>();
        public ResponseTextModel(List<string> values)
        {
            Values = values;
        }
        public ResponseTextModel()
        {
            
        }
    }
}