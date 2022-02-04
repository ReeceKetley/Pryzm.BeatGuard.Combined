namespace BeatGuard.UploadManager.Domain.Entities
{
    public class User
    {
        public User(int id, string accessToken)
        {
            Id = id;
            AccessToken = accessToken;
        }

        protected User()
        {
        }

        public int Id { get; private set; }
        public string AccessToken { get; private set; }
    }
}