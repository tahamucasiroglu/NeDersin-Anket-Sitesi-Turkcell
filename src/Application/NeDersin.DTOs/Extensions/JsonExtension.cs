using NeDersin.DTOs.Abstract;
using NeDersin.DTOs.Concrete.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NeDersin.DTOs.Extensions
{
    static public class JsonExtension
    {
        static public string ToJson<T>(this T obj) => JsonConvert.SerializeObject(obj);
        static public T FromString<T>(this string str) where T : class, new() => JsonConvert.DeserializeObject<T>(str) ?? new T();

    }
}
