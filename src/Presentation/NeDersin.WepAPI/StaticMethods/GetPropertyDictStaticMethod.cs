using NeDersin.DTOs.Concrete.Request.Add;
using System.Reflection;

namespace NeDersin.WepAPI.StaticMethods
{
    static public partial class StaticHelperMethods
    {
        static public Dictionary<string, string> GetPropertyDict(Type type)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            foreach (PropertyInfo item in type.GetProperties())
            {
                dict.Add(item.Name, item.PropertyType.ToString());
            }
            return dict;
        }
    }
}
