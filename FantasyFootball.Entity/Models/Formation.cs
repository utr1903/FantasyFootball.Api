using System;
using System.Collections.Generic;

#nullable disable

namespace FantasyFootball.Entity.Models
{
    public partial class Formation : URF.Core.EF.Trackable.Entity
    {
        public Formation()
        {
            UserTeams = new HashSet<UserTeam>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<UserTeam> UserTeams { get; set; }
    }
}
