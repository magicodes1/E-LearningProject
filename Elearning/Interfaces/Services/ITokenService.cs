using Microsoft.AspNetCore.Identity;

namespace ElearningApplication.Interfaces.Services;

public interface ITokenService
{
    string tokenGeneration(string userName,string id,List<IdentityRole> roles);
}