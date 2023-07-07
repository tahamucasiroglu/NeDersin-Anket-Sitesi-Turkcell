using NeDersin.DTOs.Abstract;
using NeDersin.DTOs.Concrete.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeDersin.DTOs.Extensions
{
    static public class ToTextExtensions
    {
        //static public string ToText(this GetQuestionResponseDTO entity)
        //    => $"Id = {entity.Id} SurveyId = {entity.SurveyId} ResponseTypeId = {entity.ResponseTypeId} QuestionText = {entity.QuestionText}";

        static public string ToText(this IResponseDTO entity)
        {
            string text = "";
            var properties = entity.GetType().GetProperties();
            foreach (var property in properties)
            {
                string propertyName = property.Name;
                object? propertyValue = property.GetValue(entity);

                text += $"{propertyName}: {propertyValue}   ";
            }
            text += "\n";
            return text;
        }
        static public string ToText(this IEnumerable<IResponseDTO> entity)
        {
            string text = "";
            foreach (var item in entity)
            {
                var properties = entity.GetType().GetProperties();
                foreach (var property in properties)
                {
                    string propertyName = property.Name;
                    object? propertyValue = property.GetValue(entity);

                    text += $"{propertyName}: {propertyValue}  ";
                }
                text += "\n";
            }
            return text;
        }
    }
}
