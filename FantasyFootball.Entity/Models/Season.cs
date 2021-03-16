using System;
using System.Collections.Generic;

#nullable disable

namespace FantasyFootball.Entity.Models
{
    public partial class Season : URF.Core.EF.Trackable.Entity
    {
        public Season()
        {
            SocialLeagues = new HashSet<SocialLeague>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<SocialLeague> SocialLeagues { get; set; }
    }
}
