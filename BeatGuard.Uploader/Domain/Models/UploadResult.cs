namespace BeatGuard.Uploader.Domain.Models
{
    public class UploadResult
    {
        public int TrackId { get; set; }

        public UploadResult(int trackId)
        {
            TrackId = trackId;
        }
    }
}
