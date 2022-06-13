
namespace ElearningApplication.Interfaces.Services;

public interface ITokenService
{
    string tokenGeneration(string userName,string id,List<string> roles);
}