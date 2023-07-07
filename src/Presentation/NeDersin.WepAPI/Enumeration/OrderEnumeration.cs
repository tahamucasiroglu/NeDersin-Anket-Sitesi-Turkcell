using Newtonsoft.Json;
using System.Reflection;

namespace NeDersin.WepAPI.Enumeration
{
    static public class OrderEnumeration
    {
        public const string StartDate = "StartDate";
        public const string StartDateDesc = "StartDateDesc";

        public static Dictionary<string, object> GetParameters()
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            Type orderEnumType = typeof(OrderEnumeration);

            FieldInfo[] fields = orderEnumType.GetFields(BindingFlags.Public | BindingFlags.Static);

            foreach (FieldInfo field in fields)
            {
                string paramName = field.Name;
                object? paramValue = field.GetValue(null);
                if(paramValue != null)
                {
                    parameters.Add(paramName, paramValue);
                }
                
            }

            return parameters;
        }
        static public string ToJson() => JsonConvert.SerializeObject(GetParameters()); 
            
    }
}
