using System.Threading;
using Microsoft.EntityFrameworkCore;
using TrackableEntities.Common.Core;
using URF.Core.EF.Trackable;

namespace FantasyFootball.Repositories.MatchWeekRepository
{
    public class MatchWeekRepository<TEntity> : TrackableRepository<TEntity>, IMatchWeekRepository<TEntity> where TEntity : class, ITrackable
    {
        public MatchWeekRepository(DbContext context) : base(context)
        {

        }

        public TEntity Find(object[] keyValues, CancellationToken cancellationToken = default)
        {
            return this.Context.Find<TEntity>(keyValues) as TEntity;
        }
    }
}