using System;
using System.Collections.Generic;

#nullable disable

namespace FantasyFootball.Entity.Models
{
    public partial class Club : URF.Core.EF.Trackable.Entity
    {
        public Club()
        {
            Players = new HashSet<Player>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid LeagueId { get; set; }

        public virtual League League { get; set; }
        public virtual ICollection<Player> Players { get; set; }
    }
}
