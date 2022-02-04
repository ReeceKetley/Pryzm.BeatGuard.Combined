using Amazon.Runtime;

namespace BeatGuard.Uploader.Domain
{
    public static class CredentialsProvider
    {
        public static BasicAWSCredentials GetAwsCredentials()
        {
            return new BasicAWSCredentials("AKIAZ2DZWIDO7IADIQ47", "c95Pe5wwEbI0NDwivjMtOh3AoxKpjAUXSQkN5vUb");
        }
    }
}
