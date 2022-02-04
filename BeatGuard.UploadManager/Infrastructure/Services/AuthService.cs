using System.Security.Authentication;
using BeatGuard.UploadManager.Domain.Entities;
using BeatGuard.UploadManager.Infrastructure.Data;

namespace BeatGuard.UploadManager.Infrastructure.Services
{
    public class AuthService
    {
        private readonly UserRepository _userRepository;

        public AuthService(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User Authenticate(string accessToken)
        {
            var user = _userRepository.GetByAccessToken(accessToken);
            if (user == null)
            {
                throw new AuthenticationException("Access token invalid.");
            }

            return user;
        }
    }
}
