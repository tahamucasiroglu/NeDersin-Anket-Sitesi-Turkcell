using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeDersin.DTOs.Abstract
{
    public interface IHashable
    {
        public string GetSHA1HashCode();
    }
}
