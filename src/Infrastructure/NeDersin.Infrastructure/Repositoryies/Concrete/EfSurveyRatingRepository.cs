﻿using NeDersin.Entities.Concrete.Entities;
using NeDersin.Infrastructure.Contexts;
using NeDersin.Infrastructure.Repositoryies.Abstract;
using NeDersin.Infrastructure.Repositoryies.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeDersin.Infrastructure.Repositoryies.Concrete
{
    public sealed class EfSurveyRatingRepository : EfEntityRepositoryBase<SurveyRating, NeDersinDbContext>, ISurveyRatingRepository
    {
        public EfSurveyRatingRepository(NeDersinDbContext context) : base(context) { }

    }
}
