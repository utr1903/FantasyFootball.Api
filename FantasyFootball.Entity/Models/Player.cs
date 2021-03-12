using System;
using System.Collections.Generic;

#nullable disable

namespace FantasyFootball.Entity.Models
{
    public partial class Player : URF.Core.EF.Trackable.Entity
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int PositionId { get; set; }
        public Guid ClubId { get; set; }
        public int CountryId { get; set; }

        public virtual Club Club { get; set; }
        public virtual Country Country { get; set; }
        public virtual Position Position { get; set; }
    }
}
