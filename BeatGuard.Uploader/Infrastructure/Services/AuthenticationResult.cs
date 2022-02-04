namespace BeatGuard.Uploader.Infrastructure.Services
{
    public class AuthenticationResult
    {
        public bool IsValid { get; private set; }
        public int UserId { get; private set; }


        public AuthenticationResult(int userId)
        {
            IsValid = true;
            UserId = userId;
        }

        public AuthenticationResult()
        {
            IsValid = false;
        }
    }
}