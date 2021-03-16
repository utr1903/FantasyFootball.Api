using System;
using System.Collections.Generic;

#nullable disable

namespace FantasyFootball.Entity.Models
{
    public partial class Player : URF.Core.EF.Trackable.Entity
    {
        public Player()
        {
            PlayerHistories = new HashSet<PlayerHistory>();
            PlayerPositions = new HashSet<PlayerPosition>();
        }

        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int CountryId { get; set; }

        public virtual Country Country { get; set; }
        public virtual ICollection<PlayerHistory> PlayerHistories { get; set; }
        public virtual ICollection<PlayerPosition> PlayerPositions { get; set; }
    }
}
