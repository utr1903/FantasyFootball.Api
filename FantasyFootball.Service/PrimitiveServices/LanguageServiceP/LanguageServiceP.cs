using URF.Core.Services;
using System.Linq;
using System.Linq.Expressions;
using System;
using FantasyFootball.Entity.Models;
using FantasyFootball.Repositories.LanguageRepository;

namespace FantasyFootball.Service.PrimitiveServices.LanguageServiceP
{
    public class LanguageServiceP : Service<Language>, ILanguageServiceP
    {
        public LanguageServiceP(ILanguageRepository<Language> repository) : base(repository)
        {
        }

        public Language Get(Guid languageId) => Repository.FindAsync(languageId).Result;

        public new void Insert(Language language) => Repository.Insert(language);

        public new void Update(Language language) => Repository.Update(language);

        public Language Single(Expression<Func<Language, bool>> predicate)
        {
            return Repository.Queryable().Single(predicate);
        }
    }
}
