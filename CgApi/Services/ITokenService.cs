using JWTAuthentication.Models;

namespace CgApi.Services
{
    namespace JWTAuthentication.Services
    {
        public interface ITokenService
        {
            UserToken BuildToken(UserInfo user);
        }
    }
}