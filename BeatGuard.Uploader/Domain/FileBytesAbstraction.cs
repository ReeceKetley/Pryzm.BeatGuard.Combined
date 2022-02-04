using System.IO;

namespace BeatGuard.Uploader.Domain
{
    public class FileBytesAbstraction : TagLib.File.IFileAbstraction
    {
        public FileBytesAbstraction(string name, Stream inputStream)
        {
            Name = name;
            ReadStream = inputStream;
            WriteStream = inputStream;
        }

        public void CloseStream(Stream stream)
        {
            stream.Dispose();
        }

        public string Name { get; private set; }

        public Stream ReadStream { get; private set; }

        public Stream WriteStream { get; private set; }
    }
}
