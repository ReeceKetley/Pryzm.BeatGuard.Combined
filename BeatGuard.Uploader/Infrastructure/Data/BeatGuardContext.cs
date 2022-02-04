using System;
using System.Globalization;
using BeatGuard.Uploader.Domain;
using BeatGuard.Uploader.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BeatGuard.Uploader.Infrastructure.Data
{
    public class BeatGuardContext : DbContext
    {
        public BeatGuardContext(DbContextOptions<BeatGuardContext> options) : base(options)
        {
        }

        public DbSet<Track> Tracks { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().ToTable("users");
            modelBuilder.Entity<Track>().ToTable("tracks");
            modelBuilder.Entity<User>().Property(x => x.AccessToken).HasColumnName("access_token");
            modelBuilder.Entity<Track>().Property(x => x.BitRate).HasColumnName("bit_rate");
            modelBuilder.Entity<Track>().Property(x => x.Duration).HasColumnName("duration");
            modelBuilder.Entity<Track>().Property(x => x.Id).HasColumnName("id");
            modelBuilder.Entity<Track>().Property(x => x.Name).HasColumnName("name");
            modelBuilder.Entity<Track>().Property(x => x.UploadKey).HasColumnName("upload_key");
            modelBuilder.Entity<Track>().Property(x => x.Type).HasColumnName("type");
            modelBuilder.Entity<Track>().Property(x => x.UploadedOn).HasColumnName("uploaded_on");
            modelBuilder.Entity<Track>().Property(x => x.UserId).HasColumnName("user_id");
            modelBuilder
                .Entity<Track>()
                .Property(e => e.Type)
                .HasConversion(
                    v => v.ToString().ToLower(),
                    v => (TrackType)Enum.Parse(typeof(TrackType),
                        CultureInfo.CurrentCulture.TextInfo.ToTitleCase(v.ToLower())));
        }
    }
}