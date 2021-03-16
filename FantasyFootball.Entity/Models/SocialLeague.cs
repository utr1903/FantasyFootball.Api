using System;
using System.Collections.Generic;

#nullable disable

namespace FantasyFootball.Entity.Models
{
    public partial class SocialLeague : URF.Core.EF.Trackable.Entity
    {
        public SocialLeague()
        {
            SocialLeagueMembers = new HashSet<SocialLeagueMember>();
            UserTeams = new HashSet<UserTeam>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid LeagueId { get; set; }
        public int SeasonId { get; set; }

        public virtual League League { get; set; }
        public virtual Season Season { get; set; }
        public virtual ICollection<SocialLeagueMember> SocialLeagueMembers { get; set; }
        public virtual ICollection<UserTeam> UserTeams { get; set; }
    }
}
