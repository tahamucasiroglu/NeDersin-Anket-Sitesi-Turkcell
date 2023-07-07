using NeDersin.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeDersin.Entities.Extensions
{
    static public class EntityExtensions
    {
        static public bool IsNull(this IEntity? entity) => entity == null || entity == default;
        static public bool IsNotNull(this IEntity? entity) => entity != null && entity != default;
    }
}
