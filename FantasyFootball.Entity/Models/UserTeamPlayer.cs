using System;
using System.Collections.Generic;

#nullable disable

namespace FantasyFootball.Entity.Models
{
    public partial class UserTeamPlayer : URF.Core.EF.Trackable.Entity
    {
        public Guid Id { get; set; }
        public Guid PlayerHistoryId { get; set; }

        public virtual PlayerHistory PlayerHistory { get; set; }
    }
}
