using FantasyFootball.Entity.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FantasyFootball.Data
{
    public class FantasyFootballContext : DbContext
    {
        public FantasyFootballContext(DbContextOptions options) : base(options)
        {
        }

        public virtual DbSet<Users> Users { get; set; }
    }
}
