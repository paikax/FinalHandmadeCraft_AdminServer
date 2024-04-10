using HandMadeCraftAdminServer.Models.User;

namespace HandMadeCraftAdminServer.VM
{
    public class AuthenticationResponse
    {
        public User User { get; }
        public string JwtToken { get; }
        public string RefreshToken { get; }

        public AuthenticationResponse(User user, string jwtToken, string refreshToken)
        {
            User = user;
            JwtToken = jwtToken;
            RefreshToken = refreshToken;
        }
    }
}