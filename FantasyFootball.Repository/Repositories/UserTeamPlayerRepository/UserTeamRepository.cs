using System.Threading;
using Microsoft.EntityFrameworkCore;
using TrackableEntities.Common.Core;
using URF.Core.EF.Trackable;

namespace FantasyFootball.Repositories.UserTeamPlayerRepository
{
    public class UserTeamPlayerRepository<TEntity> : TrackableRepository<TEntity>, IUserTeamPlayerRepository<TEntity> where TEntity : class, ITrackable
    {
        public UserTeamPlayerRepository(DbContext context) : base(context)
        {

        }

        public TEntity Find(object[] keyValues, CancellationToken cancellationToken = default)
        {
            return this.Context.Find<TEntity>(keyValues) as TEntity;
        }
    }
}