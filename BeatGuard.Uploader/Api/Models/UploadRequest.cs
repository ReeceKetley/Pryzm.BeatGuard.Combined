using System.IO;
using BeatGuard.Uploader.Domain;

namespace BeatGuard.Uploader.Api.Models
{
    public class UploadRequest
    {
        public UploadRequest(string accessToken, Stream stream)
        {
            AccessToken = accessToken;
            Stream = stream;
        }

        public string AccessToken { get; }
        public Stream Stream { get; set; }
    }

    public class TrackMeta
    {
        public string FileName { get; }
        public int BitRate { get; }
        public int Duration { get; }
        public TrackType Type { get; }

        public TrackMeta(string fileName, int bitRate, int duration, TrackType type)
        {
            FileName = fileName;
            Type = type;
            BitRate = bitRate;
            Duration = duration;
        }
    }
}
