using System.Linq;
using BeatGuard.Uploader.Domain.Entities;

namespace BeatGuard.Uploader.Infrastructure.Data
{
    public class UserRepository
    {
        private readonly BeatGuardContext _dbContext;

        public UserRepository(BeatGuardContext dbContext)
        {
            _dbContext = dbContext;
        }

        public User GetByAccessToken(string accessToken)
        {
            return _dbContext.Set<User>().FirstOrDefault(x => x.AccessToken == accessToken);
        }
    }
}
