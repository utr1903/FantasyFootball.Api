using System.Threading;
using Microsoft.EntityFrameworkCore;
using TrackableEntities.Common.Core;
using URF.Core.EF.Trackable;

namespace FantasyFootball.Repositories.LanguageRepository
{
    public class LanguageRepository<TEntity> : TrackableRepository<TEntity>, ILanguageRepository<TEntity> where TEntity : class, ITrackable
    {
        public LanguageRepository(DbContext context) : base(context)
        {

        }

        public TEntity Find(object[] keyValues, CancellationToken cancellationToken = default)
        {
            return this.Context.Find<TEntity>(keyValues) as TEntity;
        }
    }
}