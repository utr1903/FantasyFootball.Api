using System;
using URF.Core.EF.Trackable;

namespace FantasyFootball.Entity.Models
{
    public partial class Users : URF.Core.EF.Trackable.Entity
    {
        public Guid UserId { get; set; }
    }
}
