using System.Threading;
using TrackableEntities.Common.Core;
using URF.Core.Abstractions.Trackable;

namespace FantasyFootball.Repositories.SocialLeagueMemberRepository
{
    public interface ISocialLeagueMemberRepository<TEntity> : ITrackableRepository<TEntity> where TEntity : class, ITrackable
    {
        TEntity Find(object[] keyValues, CancellationToken cancellationToken = default);
    }
}