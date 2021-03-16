using System.Threading;
using Microsoft.EntityFrameworkCore;
using TrackableEntities.Common.Core;
using URF.Core.EF.Trackable;

namespace FantasyFootball.Repositories.PlayerPositionRepository
{
    public class PlayerPositionRepository<TEntity> : TrackableRepository<TEntity>, IPlayerPositionRepository<TEntity> where TEntity : class, ITrackable
    {
        public PlayerPositionRepository(DbContext context) : base(context)
        {

        }

        public TEntity Find(object[] keyValues, CancellationToken cancellationToken = default)
        {
            return this.Context.Find<TEntity>(keyValues) as TEntity;
        }
    }
}