using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Services.Helpers
{
    public class AuthOptions
    {
        public const string ISSUER = "Server";
        public const string AUDIENCE = "Client";
        public const string KEY = "secretkey";
        public const int LIFETIME = 3600;
        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }
    }
}