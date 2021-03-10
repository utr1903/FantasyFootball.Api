using System;

#nullable disable

namespace FantasyFootball.Entity.Models
{
    public partial class User : URF.Core.EF.Trackable.Entity
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
