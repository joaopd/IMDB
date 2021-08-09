using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace CrossCutting.Configs.Security
{
    public class JwtSecurityKey
    {
        public static SymmetricSecurityKey Create(string secret)
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secret));
        }
    }
}
