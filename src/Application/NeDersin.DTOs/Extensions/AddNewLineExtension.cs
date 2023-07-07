using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeDersin.DTOs.Extensions
{
    static public class AddNewLineExtension
    {
        static public string NewLine(this string str) => str + "\n";
    }
}
