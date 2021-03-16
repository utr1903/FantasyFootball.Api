using System.Threading;
using Microsoft.EntityFrameworkCore;
using TrackableEntities.Common.Core;
using URF.Core.EF.Trackable;

namespace FantasyFootball.Repositories.SocialLeagueMemberRepository
{
    public class SocialLeagueMemberRepository<TEntity> : TrackableRepository<TEntity>, ISocialLeagueMemberRepository<TEntity> where TEntity : class, ITrackable
    {
        public SocialLeagueMemberRepository(DbContext context) : base(context)
        {

        }

        public TEntity Find(object[] keyValues, CancellationToken cancellationToken = default)
        {
            return this.Context.Find<TEntity>(keyValues) as TEntity;
        }
    }
}