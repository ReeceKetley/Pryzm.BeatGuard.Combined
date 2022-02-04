using System;
using System.Globalization;
using Amazon.Runtime.CredentialManagement;
using BeatGuard.UploadManager.Domain;
using BeatGuard.UploadManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BeatGuard.UploadManager.Infrastructure.Data
{
    public class TrackRepository
    {
        private readonly BeatGuardContext _dbContext;

        public TrackRepository(BeatGuardContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(Track track)
        {
            _dbContext.Tracks.Add(track);
            _dbContext.SaveChanges();
        }
    }

    public class BeatGuardContext : DbContext
    {
        public DbSet<Track> Tracks { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
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
