using System.Threading;
using Microsoft.EntityFrameworkCore;
using TrackableEntities.Common.Core;
using URF.Core.EF.Trackable;

namespace FantasyFootball.Repositories.SeasonRepository
{
    public class SeasonRepository<TEntity> : TrackableRepository<TEntity>, ISeasonRepository<TEntity> where TEntity : class, ITrackable
    {
        public SeasonRepository(DbContext context) : base(context)
        {

        }

        public TEntity Find(object[] keyValues, CancellationToken cancellationToken = default)
        {
            return this.Context.Find<TEntity>(keyValues) as TEntity;
        }
    }
}