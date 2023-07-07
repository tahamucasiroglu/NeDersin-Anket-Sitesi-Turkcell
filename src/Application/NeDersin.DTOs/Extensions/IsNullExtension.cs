using NeDersin.DTOs.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeDersin.DTOs.Extensions
{
    static public class IsNullExtension
    {
        static public bool IsNull(this IResponseDTO response) => response == null;
        static public bool IsNull(this IEnumerable<IResponseDTO> response) => response == null || response.Count() == 0;
    }
}
