using System.Threading;
using Microsoft.EntityFrameworkCore;
using TrackableEntities.Common.Core;
using URF.Core.EF.Trackable;

namespace FantasyFootball.Repositories.PositionRepository
{
    public class PositionRepository<TEntity> : TrackableRepository<TEntity>, IPositionRepository<TEntity> where TEntity : class, ITrackable
    {
        public PositionRepository(DbContext context) : base(context)
        {

        }

        public TEntity Find(object[] keyValues, CancellationToken cancellationToken = default)
        {
            return this.Context.Find<TEntity>(keyValues) as TEntity;
        }
    }
}