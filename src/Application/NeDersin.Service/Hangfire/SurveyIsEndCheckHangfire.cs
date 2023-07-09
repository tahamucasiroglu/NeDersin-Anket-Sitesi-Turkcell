using Hangfire;
using Microsoft.EntityFrameworkCore;
using NeDersin.Infrastructure.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeDersin.Services.Hangfire
{
    public  class SurveyIsEndCheckHangfire  //ISurveyService ile getirilmeli context karıştırılmamalı ayrıca min max responsede hesaba katılmalı ama yapmak için yaptım
    {
        private readonly NeDersinDbContext context;
        public SurveyIsEndCheckHangfire(NeDersinDbContext context)
        {
            this.context = context;
        }

        [AutomaticRetry(Attempts = 0)] // Görevin hatalı durumda tekrarlanmasını engeller
        public void CheckSurveys()
        {
            while (true) //while olmadan yapmayı çok isterdim ama bulamadım yarımsaatte bu kadar oldu. ram sürekli artar uzun süre açık kalmamalı
            {
                Console.WriteLine("Çalıştı");
                var surveys = context.Surveys
                    .Where(s => !s.IsEnd)
                    .ToList();

                foreach (var survey in surveys)
                {
                    if (DateTime.Now >= survey.EndDate)
                    {
                        survey.IsEnd = true;
                    }
                }
                context.SaveChanges();
                Thread.Sleep(1000);
            } 
        }
    }
}
