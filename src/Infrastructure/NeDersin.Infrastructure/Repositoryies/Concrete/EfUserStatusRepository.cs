using NeDersin.Entities.Concrete.Entities;
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
    public sealed class EfUserStatusRepository : EfEntityRepositoryBase<UserStatus, NeDersinDbContext>, IUserStatusRepository
    {
        public EfUserStatusRepository(NeDersinDbContext context) : base(context) { }
    }
}
