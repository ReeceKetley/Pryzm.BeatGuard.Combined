using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BeatGuard.UploadManager.Domain.Entities;

namespace BeatGuard.UploadManager.Infrastructure.Data
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
