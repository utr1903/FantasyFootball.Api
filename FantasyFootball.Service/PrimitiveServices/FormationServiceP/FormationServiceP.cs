using URF.Core.Services;
using System.Linq;
using System.Linq.Expressions;
using System;
using FantasyFootball.Entity.Models;
using FantasyFootball.Repositories.FormationRepository;

namespace FantasyFootball.Service.PrimitiveServices.FormationServiceP
{
    public class FormationServiceP : Service<Formation>, IFormationServiceP
    {
        public FormationServiceP(IFormationRepository<Formation> repository) : base(repository)
        {
        }

        public Formation Get(Guid formationId) => Repository.FindAsync(formationId).Result;

        public new void Insert(Formation formation) => Repository.Insert(formation);

        public new void Update(Formation formation) => Repository.Update(formation);

        public Formation Single(Expression<Func<Formation, bool>> predicate)
        {
            return Repository.Queryable().Single(predicate);
        }
    }
}
