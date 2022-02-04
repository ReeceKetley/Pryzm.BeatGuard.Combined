namespace BeatGuard.Uploader.Domain.Entities
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

        public int Id { get; set; }
        public string AccessToken { get; set; }
    }
}