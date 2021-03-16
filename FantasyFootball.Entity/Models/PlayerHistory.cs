using System;
using System.Collections.Generic;

#nullable disable

namespace FantasyFootball.Entity.Models
{
    public partial class PlayerHistory : URF.Core.EF.Trackable.Entity
    {
        public PlayerHistory()
        {
            UserTeamPlayers = new HashSet<UserTeamPlayer>();
        }

        public Guid Id { get; set; }
        public Guid PlayerId { get; set; }
        public Guid ClubId { get; set; }
        public Guid MatchWeekId { get; set; }
        public float? Price { get; set; }

        public virtual Club Club { get; set; }
        public virtual MatchWeek MatchWeek { get; set; }
        public virtual Player Player { get; set; }
        public virtual ICollection<UserTeamPlayer> UserTeamPlayers { get; set; }
    }
}
