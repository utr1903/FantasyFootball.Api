using System;
using System.Collections.Generic;

#nullable disable

namespace FantasyFootball.Entity.Models
{
    public partial class Position : URF.Core.EF.Trackable.Entity
    {
        public Position()
        {
            PlayerPositions = new HashSet<PlayerPosition>();
            UserTeamPlayers = new HashSet<UserTeamPlayer>();
        }

        public int Id { get; set; }
        public int? PId { get; set; }
        public string Code { get; set; }

        public virtual ICollection<PlayerPosition> PlayerPositions { get; set; }
        public virtual ICollection<UserTeamPlayer> UserTeamPlayers { get; set; }
    }
}
