using System;
using System.Collections.Generic;

#nullable disable

namespace FantasyFootball.Entity.Models
{
    public partial class Formation : URF.Core.EF.Trackable.Entity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
