using System;
using System.IO;
using BeatGuard.Uploader.Api.Models;
using BeatGuard.Uploader.Domain;

namespace BeatGuard.Uploader.Infrastructure.Services
{
    public class TrackMetaService
    {
        public TrackMeta Read(Stream stream, string fileName)
        {
            var file = Guid.NewGuid();
            TrackType type;
            var fileTypeString = Path.GetExtension(fileName);
            SaveFileStream(file.ToString(), stream);
            var tag = TagLib.File.Create(fileTypeString);
            switch (fileTypeString)
            {
                case ".wav":
                    type = TrackType.Wav;
                    break;
                case ".mp3":
                    type = TrackType.Mp3;
                    break;
                default:
                    throw new NotSupportedException("File type not supported.");
            }

            var trackMeta = new TrackMeta(fileName, tag.Properties.BitsPerSample, tag.Properties.Duration.Seconds, type);
            tag.Dispose();
            File.Delete(file.ToString());
            return trackMeta;
        }



        private void SaveFileStream(String path, Stream stream)
        {
            var fileStream = new FileStream(path, FileMode.Create, FileAccess.Write);
            stream.CopyTo(fileStream);
            fileStream.Dispose();
        }


    }
}
