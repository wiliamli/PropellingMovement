using Jwell.Domain.Entities;
using Jwell.Framework.Domain.Repositories;
using Jwell.Modules.EntityFramework.Repositories;
using Jwell.Modules.EntityFramework.Uow;
using Jwell.Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jwell.Repository.Repositories
{
    public class PropellingMovementLogRepository : RepositoryBase<PropellingMovementLog, JwellDbContext, long>, IRepository<PropellingMovementLog, long>
    {
        public PropellingMovementLogRepository(IDbContextResolver dbContextResolver) : base(dbContextResolver)
        {
        }
    }
}
