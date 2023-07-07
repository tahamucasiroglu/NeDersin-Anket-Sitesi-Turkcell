using NeDersin.DTOs.Abstract;
using NeDersin.DTOs.Base;
using System.Security.Cryptography;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace NeDersin.DTOs.Concrete.Models
{    
    public class AnswerValueModel : ModelBase<AnswerValueModel>, IHashable
    {
        public int MinSize { get; set; } = 0;
        public int MaxSize { get; set; } = 100;
        public int CurrentSize { get; set; } = 0;
        public bool AutoSelect { get; set; } = false;
        public bool OnlyNumber { get; set; } = false;
        public IEnumerable<string> AnswerValues { get; set; } = Enumerable.Empty<string>();
        public AnswerValueModel(int minSize, int maxSize, int currentSize, bool autoSelect, bool onlyNumber, IEnumerable<string> answerValues)
        {
            MinSize = minSize;
            MaxSize = maxSize;
            CurrentSize = currentSize;
            AutoSelect = autoSelect;
            OnlyNumber = onlyNumber;
            AnswerValues = answerValues;
        }
        public AnswerValueModel()
        {
            
        }
        public string GetSHA1HashCode()
        {
            string ValuesString = "";

            foreach (string answerValues in AnswerValues)
            {
                ValuesString += answerValues;
            }

            string ClassText = $"{ValuesString}{MinSize}{MaxSize}{CurrentSize}{AutoSelect}{OnlyNumber}";

            using (SHA1 sha1 = SHA1.Create())
            {
                byte[] dataBytes = Encoding.UTF8.GetBytes(ClassText);
                byte[] hashBytes = sha1.ComputeHash(dataBytes);

                StringBuilder stringBuilder = new StringBuilder();

                for (int i = 0; i < hashBytes.Length; i++)
                {
                    stringBuilder.Append(hashBytes[i].ToString("x2"));
                }

                return stringBuilder.ToString();
            }
        }
    }
}
