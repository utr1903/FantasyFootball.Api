using System;
using FantasyFootball.Entity.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace FantasyFootball.Data
{
    public partial class FantasyFootballContext : DbContext
    {
        public FantasyFootballContext()
        {
        }

        public FantasyFootballContext(DbContextOptions<FantasyFootballContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Club> Clubs { get; set; }
        public virtual DbSet<Country> Countrys { get; set; }
        public virtual DbSet<Formation> Formations { get; set; }
        public virtual DbSet<Language> Languages { get; set; }
        public virtual DbSet<League> Leagues { get; set; }
        public virtual DbSet<MatchWeek> MatchWeeks { get; set; }
        public virtual DbSet<Player> Players { get; set; }
        public virtual DbSet<PlayerHistory> PlayerHistorys { get; set; }
        public virtual DbSet<PlayerPosition> PlayerPositions { get; set; }
        public virtual DbSet<Position> Positions { get; set; }
        public virtual DbSet<Season> Seasons { get; set; }
        public virtual DbSet<SocialLeague> SocialLeagues { get; set; }
        public virtual DbSet<SocialLeagueMember> SocialLeagueMembers { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserTeam> UserTeams { get; set; }
        public virtual DbSet<UserTeamPlayer> UserTeamPlayers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost;Database=FantasyFootball;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Club>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.League)
                    .WithMany(p => p.Clubs)
                    .HasForeignKey(d => d.LeagueId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Clubs__LeagueId__4BAC3F29");
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Formation>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Language>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<League>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Leagues)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Leagues__Country__45F365D3");
            });

            modelBuilder.Entity<MatchWeek>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Date).HasColumnType("datetime");
            });

            modelBuilder.Entity<Player>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Players)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Players__Country__5629CD9C");
            });

            modelBuilder.Entity<PlayerHistory>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.Club)
                    .WithMany(p => p.PlayerHistories)
                    .HasForeignKey(d => d.ClubId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PlayerHis__ClubI__6C190EBB");

                entity.HasOne(d => d.MatchWeek)
                    .WithMany(p => p.PlayerHistories)
                    .HasForeignKey(d => d.MatchWeekId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PlayerHis__Match__6D0D32F4");

                entity.HasOne(d => d.Player)
                    .WithMany(p => p.PlayerHistories)
                    .HasForeignKey(d => d.PlayerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PlayerHis__Playe__6B24EA82");
            });

            modelBuilder.Entity<PlayerPosition>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.Player)
                    .WithMany(p => p.PlayerPositions)
                    .HasForeignKey(d => d.PlayerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PlayerPos__Playe__7D439ABD");

                entity.HasOne(d => d.Position)
                    .WithMany(p => p.PlayerPositions)
                    .HasForeignKey(d => d.PositionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PlayerPos__Posit__7E37BEF6");
            });

            modelBuilder.Entity<Position>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Code)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PId).HasColumnName("pId");
            });

            modelBuilder.Entity<Season>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SocialLeague>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.League)
                    .WithMany(p => p.SocialLeagues)
                    .HasForeignKey(d => d.LeagueId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__SocialLea__Leagu__60A75C0F");

                entity.HasOne(d => d.Season)
                    .WithMany(p => p.SocialLeagues)
                    .HasForeignKey(d => d.SeasonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__SocialLea__Seaso__619B8048");
            });

            modelBuilder.Entity<SocialLeagueMember>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.SocialLeague)
                    .WithMany(p => p.SocialLeagueMembers)
                    .HasForeignKey(d => d.SocialLeagueId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__SocialLea__Socia__6FE99F9F");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.SocialLeagueMembers)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__SocialLea__UserI__70DDC3D8");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.Language)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.LanguageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Users__LanguageI__59FA5E80");
            });

            modelBuilder.Entity<UserTeam>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.Formation)
                    .WithMany(p => p.UserTeams)
                    .HasForeignKey(d => d.FormationId)
                    .HasConstraintName("FK__UserTeams__Forma__7A672E12");

                entity.HasOne(d => d.MatchWeek)
                    .WithMany(p => p.UserTeams)
                    .HasForeignKey(d => d.MatchWeekId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__UserTeams__Match__75A278F5");

                entity.HasOne(d => d.SocialLeague)
                    .WithMany(p => p.UserTeams)
                    .HasForeignKey(d => d.SocialLeagueId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__UserTeams__Socia__74AE54BC");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserTeams)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__UserTeams__UserI__73BA3083");
            });

            modelBuilder.Entity<UserTeamPlayer>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.PlayerHistory)
                    .WithMany(p => p.UserTeamPlayers)
                    .HasForeignKey(d => d.PlayerHistoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__UserTeamP__Playe__787EE5A0");

                entity.HasOne(d => d.Position)
                    .WithMany(p => p.UserTeamPlayers)
                    .HasForeignKey(d => d.PositionId)
                    .HasConstraintName("FK__UserTeamP__Posit__01142BA1");

                entity.HasOne(d => d.UserTeam)
                    .WithMany(p => p.UserTeamPlayers)
                    .HasForeignKey(d => d.UserTeamId)
                    .HasConstraintName("FK__UserTeamP__UserT__00200768");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
