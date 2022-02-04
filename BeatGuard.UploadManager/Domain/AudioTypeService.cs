namespace BeatGuard.UploadManager.Domain
{
    public class AudioTypeService
    {
        public static TrackType Detect(byte[] data)
        {
            if (data[0] == 0x49 & data[1] == 0x44 & data[2] == 0x33)
            {
                return TrackType.Mp3;
            }

            if (data[0] == 0x52 & data[1] == 0x49 & data[2] == 0x46 & data[3] == 0x46)
            {
                return TrackType.Wav;
            }

            return TrackType.Invalid;
        }
    }
}
