using Microsoft.EntityFrameworkCore;
using NeDersin.DTOs.Concrete.Models;
using NeDersin.DTOs.Extensions;
using NeDersin.Infrastructure.Contexts;
using Newtonsoft.Json;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace NeDersin.WepAPI.Extensions
{
    static public class CheckDbExtension
    {
        public static IServiceProvider CheckDb(this IServiceProvider services)
        {
            using (var context = services.CreateScope().ServiceProvider.GetRequiredService<NeDersinDbContext>())
            {
                if (context.Database.EnsureCreated())
                {
                    AddUserStatuses(context); context.SaveChanges();
                    AddAnswerTypes(context); context.SaveChanges();
                    AddAnswerValues(context); context.SaveChanges();
                    AddUsers(context); context.SaveChanges();
                    AddSurveys(context); context.SaveChanges();
                    AddQuestions(context); context.SaveChanges();
                    AddAnswers(context); context.SaveChanges();
                    AddResponse(context); context.SaveChanges();
                    AddSurveyRating(context); context.SaveChanges();

                    foreach (var surveys in context.Surveys)
                    {
                        Console.WriteLine(surveys.Address);
                    }
                }
            }
            return services;
        }

        static private void AddUserStatuses(NeDersinDbContext context)
        {
            context.UserStatuses.Add(new() { Name = "Admin" });
            context.UserStatuses.Add(new() {  Name = "Anketör" });
            context.UserStatuses.Add(new() {  Name = "Kullanıcı" });
            context.UserStatuses.Add(new() {  Name = "Anonim" });
        }

        static private void AddAnswerTypes(NeDersinDbContext context)
        {
            context.AnswerTypes.Add(new() {  Name = "SingleLineText" });
            context.AnswerTypes.Add(new() {  Name = "MultiLineText" });
            context.AnswerTypes.Add(new() {  Name = "SliderRate" });
            context.AnswerTypes.Add(new() {  Name = "Radio" });
            context.AnswerTypes.Add(new() {  Name = "Checkbox" });
        }

        static private void AddAnswerValues(NeDersinDbContext context)
        {
            AnswerValueModel a1 = new AnswerValueModel(0, 150, 0, false, true, new string[] {});
            AnswerValueModel a2 = new AnswerValueModel(100, 300, 0, false, false, new string[] { });
            AnswerValueModel a3 = new AnswerValueModel(0, 100, 50, false, false, new string[] { });
            AnswerValueModel a4 = new AnswerValueModel(0, 0, 0, false, false, new string[] { });
            AnswerValueModel a5 = new AnswerValueModel(0, 0, 0, false, false, new string[] { });
            AnswerValueModel a6 = new AnswerValueModel(0, 0, 0, false, false, new string[]{ "RTE", "KK", "SO", "Mİ" });
            AnswerValueModel a7 = new AnswerValueModel(0, 0, 0, false, false, new string[]{ "AKP", "CHP", "MHP", "İYİP" });
            AnswerValueModel a8 = new AnswerValueModel(0, 100, 50, false, false, new string[] { });
            AnswerValueModel a9 = new AnswerValueModel(0, 0, 0, false, false, new string[] { "Pilav", "Etli Kuru", "Nohut", "Keşkek", "Sarma", "İskender", "Kebap", "Döner"});
            context.AnswerValues.Add(new() {  Name = a1.GetSHA1HashCode(), Value = a1.ToJson() });
            context.AnswerValues.Add(new() {  Name = a2.GetSHA1HashCode(), Value = a2.ToJson() });
            context.AnswerValues.Add(new() {  Name = a3.GetSHA1HashCode(), Value = a3.ToJson() });
            context.AnswerValues.Add(new() { Name = a4.GetSHA1HashCode(), Value = a4.ToJson() });
            context.AnswerValues.Add(new() { Name = a5.GetSHA1HashCode(), Value = a5.ToJson() });
            context.AnswerValues.Add(new() {  Name = a6.GetSHA1HashCode(), Value = a6.ToJson() });
            context.AnswerValues.Add(new() {  Name = a7.GetSHA1HashCode(), Value = a7.ToJson() });
            context.AnswerValues.Add(new() {  Name = a8.GetSHA1HashCode(), Value = a8.ToJson() });
            context.AnswerValues.Add(new() {  Name = a9.GetSHA1HashCode(), Value = a9.ToJson() });
            //Console.Write("a1 = " + a1.ToJson() + "\n");
            //Console.Write("a2 = " + a2.ToJson() + "\n");
            //Console.Write("a3 = " + a3.ToJson() + "\n");
            //Console.Write("a4 = " + a4.ToJson() + "\n");
            //Console.Write("a5 = " + a5.ToJson() + "\n");
            //Console.Write("a6 = " + a6.ToJson() + "\n");
            //Console.Write("a7 = " + a7.ToJson() + "\n");
            //Console.Write("a8 = " + a8.ToJson() + "\n");
            //Console.Write("a9 = " + a9.ToJson() + "\n");
        }

        static private void AddUsers(NeDersinDbContext context)
        {
            context.Users.Add(new()
            {
                Name = "Ahmet",
                Surname = "Taha",
                Email = "taha@gmail.com",
                Password = "123456".ToSha256(),
                Phone = null,
                IdentityNumber = null,
                UserStatusId = 1,
                Age = 25,
                Birthdate = DateTime.Now.AddYears(-25),
                Country = 48,
                Gender = false,
            });
            context.Users.Add(new()
            {
                Name = "Taha",
                Surname = "Mücas",
                Email = "ahmet@gmail.com",
                Password = "123456".ToSha256(),
                Phone = null,
                IdentityNumber = null,
                UserStatusId = 2,
                Age = 25,
                Birthdate = DateTime.Now.AddYears(-25),
                Country = 34,
                Gender = false,
            });

            context.Users.Add(new()
            {
                Name = "Anonim",
                Surname = "Anonim",
                Email = "Anonim@gmail.com",
                Password = "123456".ToSha256(),
                Phone = null,
                IdentityNumber = null,
                UserStatusId = 4,
                Age = 25,
                Birthdate = DateTime.Now.AddYears(-25),
                Country = 34,
                Gender = false,
            });
            for (int i = 4; i < 100; i++)
            {
                int age = new Random().Next(20, 35);
                context.Users.Add(new()
                {
                    Name = $"Kullanıcı-{i}",
                    Surname = $"Kullanıcı-{i}",
                    Email = $"Kullanıcı-{i}@gmail.com",
                    Password = "123456".ToSha256(),
                    Phone = null,
                    IdentityNumber = null,
                    UserStatusId = 3,
                    Age = age,
                    Birthdate = DateTime.Now.AddYears(-age),
                    Country = new Random().Next(1, 81),
                    Gender = new Random().Next(100) % 2 == 0
                });
            }
        }

        static private void AddSurveys(NeDersinDbContext context)
        {
            context.Surveys.Add(
                new()
                {
                    Address = Guid.NewGuid(),
                    Title = "Siyaset Anketi",
                    Description = "Türkiyedeki siyasetin açıklanmasına yardımcı olmak için yapılan anket",
                    StartDate = DateTime.Now,
                    EndDate = null,
                    IsEnd = false,
                    MaxResponse = null,
                    MinResponse = null,
                    UserId = 1,
                });

            context.Surveys.Add(
                new()
                {
                    Address = Guid.NewGuid(),
                    Title = "Yemek Seçim Anketi",
                    Description = "Türkiyenin mutfak haritası için yapılan anket",
                    StartDate = DateTime.Now,
                    EndDate = null,
                    IsEnd = false,
                    MaxResponse = null,
                    MinResponse = null,
                    UserId = 2,
                });
        }

        static private void AddQuestions(NeDersinDbContext context)
        {
            context.Questions.Add(new()
            {
                QuestionText = "CumhurBaşkanlığı Seçimlerinde oy vermeyi düşündüğünüz aday kim",
                ImageAdress = null,
                SurveyId = 1,
            });

            context.Questions.Add(new()
            {
                QuestionText = "Yerel Seşimlerde hangi partiyi destekleyeceksiniz",
                ImageAdress = null,
                SurveyId = 1,
            });

            context.Questions.Add(new()
            {
                QuestionText = "Şuanki Hükümeti Puanlayınız",
                ImageAdress = null,
                SurveyId = 1,
            });

            context.Questions.Add(new()
            {
                QuestionText = "Yemek zevkinizi tanımlayan bir yazı yazınız.(Tüm yazılar özenle okunacaktır)",
                ImageAdress = null,
                SurveyId = 2,
            });

            context.Questions.Add(new()
            {
                QuestionText = "En sevdiğiniz yemek veya yemekleri belirtiniz",
                ImageAdress = null,
                SurveyId = 2,
            });

            context.Questions.Add(new()
            {
                QuestionText = "Gurmeliğiniz puanlayınız",
                ImageAdress = null,
                SurveyId = 2,
            });

        }

        static private void AddAnswers(NeDersinDbContext context)
        {
            context.Answers.Add(new()
            {
                AnswerValueId = 6,
                QuestionId = 1,
                TypeId = 4,
            });

            context.Answers.Add(new()
            {
                AnswerValueId = 7,
                QuestionId = 2,
                TypeId = 4,
            });

            context.Answers.Add(new()
            {
                AnswerValueId = 8,
                QuestionId = 3,
                TypeId = 3,
            });

            context.Answers.Add(new()
            {
                AnswerValueId = 1,
                QuestionId = 4,
                TypeId = 2,
            });

            context.Answers.Add(new()
            {
                AnswerValueId = 9,
                QuestionId = 5,
                TypeId = 5,
            });
            context.Answers.Add(new()
            {
                AnswerValueId = 8,
                QuestionId = 6,
                TypeId = 3,
            });

        }

        static private void AddResponse(NeDersinDbContext context)
        {
            List<string> a1 = new List<string>() { "RTE", "KK", "SO", "Mİ" };
            List<string> a2 = new List<string>() { "AKP", "CHP", "MHP", "İYİP" };
            List<string> a3 = new List<string>() { "Pilav", "Etli Kuru", "Nohut", "Keşkek", "Sarma", "İskender", "Kebap", "Döner" };

            for (int i = 1; i < 200; i++)
            {
                context.Responses.Add(new()
                {
                    
                    QuestionId = 1,
                    ResponseText = new ResponseTextModel(new() { a1[new Random().Next(4)] }).ToJson(),
                    UserId = i < 90 ? i : 3,
                });
            }

            for (int i = 1; i < 200; i++)
            {
                context.Responses.Add(new()
                {
                    QuestionId = 2,
                    ResponseText = new ResponseTextModel(new() { a2[new Random().Next(4)] }).ToJson(),
                    UserId = i < 90 ? i : 3,
                });
            }

            for (int i = 1; i < 200; i++)
            {
                context.Responses.Add(new()
                {
                    QuestionId = 3,
                    ResponseText = new ResponseTextModel(new() { new Random().Next(100).ToString() }).ToJson(),
                    UserId = i < 90 ? i : 3,
                });
            }

            for (int i = 1; i < 200; i++)
            {
                context.Responses.Add(new()
                {
                    QuestionId = 4,
                    ResponseText = new ResponseTextModel(new() { new Random().Next(100).ToString() + new Random().Next(100).ToString() + new Random().Next(100).ToString() + new Random().Next(100).ToString() }).ToJson(),
                    UserId = i < 90 ? i : 3,
                });
            }

            for (int i = 1; i < 200; i++)
            {
                context.Responses.Add(new()
                {
                    QuestionId = 5,
                    ResponseText = new ResponseTextModel(new() { a3[new Random().Next(8)] , a3[new Random().Next(8)]}).ToJson(),
                    UserId = i < 90 ? i : 3,
                });
            }

            for (int i = 1; i < 200; i++)
            {
                context.Responses.Add(new()
                {
                    QuestionId = 6,
                    ResponseText = new ResponseTextModel(new() { new Random().Next(100).ToString() }).ToJson(),
                    UserId = i < 90 ? i : 3,
                });
            }
        }
        
        static private void AddSurveyRating(NeDersinDbContext context)
        {
            for (int i = 1; i < 200; i++)
            {
                context.SurveyRatings.Add(new() 
                { 
                    SurveyId = new Random().Next(10) % 2 + 1, 
                    UserId = i < 90 ? i : 3,
                    RatingNumber = new Random().Next(10),
                    RatingText = $"iyi {i}"
                });
            }
            
        }
    }
}
