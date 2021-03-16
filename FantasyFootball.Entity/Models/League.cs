using System;
using System.Collections.Generic;

#nullable disable

namespace FantasyFootball.Entity.Models
{
    public partial class League : URF.Core.EF.Trackable.Entity
    {
        public League()
        {
            Clubs = new HashSet<Club>();
            SocialLeagues = new HashSet<SocialLeague>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public int CountryId { get; set; }
        public int Hierarchy { get; set; }

        public virtual Country Country { get; set; }
        public virtual ICollection<Club> Clubs { get; set; }
        public virtual ICollection<SocialLeague> SocialLeagues { get; set; }
    }
}
