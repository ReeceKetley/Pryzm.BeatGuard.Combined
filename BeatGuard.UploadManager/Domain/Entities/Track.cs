using System;

namespace BeatGuard.UploadManager.Domain.Entities
{
    public class Track
    {
        public int Id { get; set;  }
        public string Name { get; set; }
        public int BitRate { get; set; }
        public int Duration { get; set; }
        public TrackType Type { get; set; }
        public string UploadKey { get; set; }
        public int UserId { get; set; }
        public DateTime UploadedOn { get; set; }

        public static Track Create(string name, int bitRate, int duration, TrackType type, int userId)
        {
            var entity = new Track();
            entity.Name = name;
            entity.BitRate = bitRate;
            entity.Duration = duration;
            entity.Type = type;
            entity.UploadKey = Guid.NewGuid().ToString();
            entity.UploadedOn = DateTime.Now;
            entity.UserId = userId;

            return entity;
        }
    }
}