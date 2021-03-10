using System.Threading;
using TrackableEntities.Common.Core;
using URF.Core.Abstractions.Trackable;

namespace FantasyFootball.Repositories.UserRepository
{
    public interface IUsersRepository<TEntity> : ITrackableRepository<TEntity> where TEntity : class, ITrackable
    {
        TEntity Find(object[] keyValues, CancellationToken cancellationToken = default);
    }
}