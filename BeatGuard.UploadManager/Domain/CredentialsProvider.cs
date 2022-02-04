using Amazon.Runtime;

namespace BeatGuard.UploadManager.Domain
{
    public static class CredentialsProvider
    {
        public static BasicAWSCredentials GetAwsCredentials()
        {
            return new BasicAWSCredentials("AKIAZ2DZWIDO6OSPWWPO", "mEoe7WiVqnH4qEgfShVOK/hrwMDyIE5wEy+f/SU6");
        }
    }
}
