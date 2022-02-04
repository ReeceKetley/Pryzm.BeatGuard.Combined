using BeatGuard.Uploader.Domain.Entities;

namespace BeatGuard.Uploader.Infrastructure.Data
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
}
