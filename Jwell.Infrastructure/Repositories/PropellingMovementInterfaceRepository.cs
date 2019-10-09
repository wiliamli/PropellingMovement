using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jwell.Domain.Entities;
using Jwell.Modules.EntityFramework.Repositories;
using Jwell.Modules.EntityFramework.Uow;
using Jwell.Repository.Context;

namespace Jwell.Repository.Repositories
{
    public class PropellingMovementInterfaceRepository : RepositoryBase<PropellingMovementInterface, JwellDbContext, long>, IPropellingMovementInterfaceRepository
    {
        public PropellingMovementInterfaceRepository(IDbContextResolver dbContextResolver) : base(dbContextResolver)
        {
        }

        public override int Add(PropellingMovementInterface entity)
        {
            int result = 0;
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append("INSERT INTO \"JWELL_PROPELLINGMOVEMENT\".\"PropellingMovementInterface\" ");
                sql.Append(" (\"PropeMoveID\",");
                sql.Append(" \"Channel\",");
                sql.Append(" \"InterfaceUrl\",");
                sql.Append(" \"Environment\") ");
                sql.Append(" VALUES ");
                sql.Append("(");
                sql.Append(":PropeMoveID,");
                sql.Append(":Channel,");
                sql.Append(":InterfaceUrl,");
                sql.Append(":Environment");
                sql.Append(")");
                result = base.ExecuteSqlCommand(sql.ToString(), new object[] {
                 entity.PropeMoveID,
                 entity.Channel,
                 entity.InterfaceUrl,
                 entity.Environment
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }
    }
}
