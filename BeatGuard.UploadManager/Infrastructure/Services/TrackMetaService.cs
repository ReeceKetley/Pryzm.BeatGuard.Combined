using System;
using System.Collections.Generic;
using System.IO;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Threading.Tasks;
using BeatGuard.UploadManager.Api.Models;
using BeatGuard.UploadManager.Domain;

namespace BeatGuard.UploadManager.Infrastructure.Services
{
    public class TrackMetaService
    {
        public TrackMeta Read(Stream stream, string fileName)
        {
            var file = TagLib.File.Create(new FileBytesAbstraction("input.wav", stream));
            TrackType type;
            var fileTypeString = Path.GetExtension(fileName);
            switch (fileTypeString)
            {
                case "wav":
                    type = TrackType.Wav;
                    break;
                case "mp3":
                    type = TrackType.Mp3;
                    break;
                default:
                    throw new NotSupportedException("File type not supported.");
            }

            var trackMeta = new TrackMeta(fileName, file.Properties.AudioBitrate, (int)file.Properties.Duration.TotalSeconds, type);
            return trackMeta;
        }
    }
}
