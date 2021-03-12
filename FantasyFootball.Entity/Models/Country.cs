using System;
using System.Collections.Generic;

#nullable disable

namespace FantasyFootball.Entity.Models
{
    public partial class Country : URF.Core.EF.Trackable.Entity
    {
        public Country()
        {
            Leagues = new HashSet<League>();
            Players = new HashSet<Player>();
        }

        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }

        public virtual ICollection<League> Leagues { get; set; }
        public virtual ICollection<Player> Players { get; set; }
    }
}
