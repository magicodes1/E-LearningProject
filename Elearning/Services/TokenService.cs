using ElearningApplication.Interfaces.Services;
using Microsoft.AspNetCore.Identity;

namespace ElearningApplication.Services;

public class TokenService : ITokenService
{
    public TokenService()
    {
        
    }
    public string tokenGeneration(string userName, string id, List<IdentityRole> roles)
    {
        throw new NotImplementedException();
    }
}