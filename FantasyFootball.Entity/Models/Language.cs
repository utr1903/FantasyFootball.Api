using System;
using System.Collections.Generic;

#nullable disable

namespace FantasyFootball.Entity.Models
{
    public partial class Language : URF.Core.EF.Trackable.Entity
    {
        public Language()
        {
            Users = new HashSet<User>();
        }

        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
