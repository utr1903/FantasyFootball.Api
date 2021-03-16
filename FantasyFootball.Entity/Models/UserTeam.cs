using System;
using System.Collections.Generic;

#nullable disable

namespace FantasyFootball.Entity.Models
{
    public partial class UserTeam : URF.Core.EF.Trackable.Entity
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid SocialLeagueId { get; set; }
        public Guid MatchWeekId { get; set; }
        public int? FormationId { get; set; }

        public virtual Formation Formation { get; set; }
        public virtual MatchWeek MatchWeek { get; set; }
        public virtual SocialLeague SocialLeague { get; set; }
        public virtual User User { get; set; }
    }
}
