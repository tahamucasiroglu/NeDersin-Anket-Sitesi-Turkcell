﻿using NeDersin.DTOs.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeDersin.DTOs.Concrete.Response.Get
{
    public sealed class GetQuestionResponseDTO : IResponseDTO
    {
        public int Id { get; set; }

        public string QuestionText { get; set; } = null!;

        public string? ImageAdress { get; set; }

        public int SurveyId { get; set; }
    }
}
