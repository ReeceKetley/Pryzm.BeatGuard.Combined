using System.Security.Authentication;
using BeatGuard.Uploader.Domain.Entities;
using BeatGuard.Uploader.Infrastructure.Data;

namespace BeatGuard.Uploader.Infrastructure.Services
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
