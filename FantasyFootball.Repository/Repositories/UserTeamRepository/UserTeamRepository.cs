using System.Threading;
using Microsoft.EntityFrameworkCore;
using TrackableEntities.Common.Core;
using URF.Core.EF.Trackable;

namespace FantasyFootball.Repositories.UserTeamRepository
{
    public class UserTeamRepository<TEntity> : TrackableRepository<TEntity>, IUserTeamRepository<TEntity> where TEntity : class, ITrackable
    {
        public UserTeamRepository(DbContext context) : base(context)
        {

        }

        public TEntity Find(object[] keyValues, CancellationToken cancellationToken = default)
        {
            return this.Context.Find<TEntity>(keyValues) as TEntity;
        }
    }
}