using System;
using System.Collections.Generic;

#nullable disable

namespace FantasyFootball.Entity.Models
{
    public partial class Position : URF.Core.EF.Trackable.Entity
    {
        public Position()
        {
            Players = new HashSet<Player>();
        }

        public int Id { get; set; }
        public int? PId { get; set; }
        public string Code { get; set; }

        public virtual ICollection<Player> Players { get; set; }
    }
}
