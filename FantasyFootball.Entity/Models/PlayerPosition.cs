using System;
using System.Collections.Generic;

#nullable disable

namespace FantasyFootball.Entity.Models
{
    public partial class PlayerPosition : URF.Core.EF.Trackable.Entity
    {
        public Guid Id { get; set; }
        public Guid PlayerId { get; set; }
        public int PositionId { get; set; }
        public float? PositionWeight { get; set; }

        public virtual Player Player { get; set; }
        public virtual Position Position { get; set; }
    }
}
