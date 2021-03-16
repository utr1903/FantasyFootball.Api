using System;
using System.Collections.Generic;

#nullable disable

namespace FantasyFootball.Entity.Models
{
    public partial class SocialLeagueMember : URF.Core.EF.Trackable.Entity
    {
        public Guid Id { get; set; }
        public Guid SocialLeagueId { get; set; }
        public Guid UserId { get; set; }

        public virtual SocialLeague SocialLeague { get; set; }
        public virtual User User { get; set; }
    }
}
