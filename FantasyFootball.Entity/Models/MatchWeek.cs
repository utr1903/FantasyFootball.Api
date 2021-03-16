using System;
using System.Collections.Generic;

#nullable disable

namespace FantasyFootball.Entity.Models
{
    public partial class MatchWeek : URF.Core.EF.Trackable.Entity
    {
        public MatchWeek()
        {
            PlayerHistories = new HashSet<PlayerHistory>();
            UserTeams = new HashSet<UserTeam>();
        }

        public Guid Id { get; set; }
        public DateTime? Date { get; set; }

        public virtual ICollection<PlayerHistory> PlayerHistories { get; set; }
        public virtual ICollection<UserTeam> UserTeams { get; set; }
    }
}
