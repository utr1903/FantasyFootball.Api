using System.Threading;
using Microsoft.EntityFrameworkCore;
using TrackableEntities.Common.Core;
using URF.Core.EF.Trackable;

namespace FantasyFootball.Repositories.SocialLeagueRepository
{
    public class SocialLeagueRepository<TEntity> : TrackableRepository<TEntity>, ISocialLeagueRepository<TEntity> where TEntity : class, ITrackable
    {
        public SocialLeagueRepository(DbContext context) : base(context)
        {

        }

        public TEntity Find(object[] keyValues, CancellationToken cancellationToken = default)
        {
            return this.Context.Find<TEntity>(keyValues) as TEntity;
        }
    }
}