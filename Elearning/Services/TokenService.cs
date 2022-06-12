using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ElearningApplication.Interfaces.Services;
using ElearningApplication.Models.Jwt;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace ElearningApplication.Services;

public class TokenService : ITokenService
{

    private readonly JwtConfiguration _jwtConfig;

    public TokenService(IOptions<JwtConfiguration> options)
    {
        _jwtConfig=options.Value;
    }

    public string tokenGeneration(string userName, string id, List<string> roles)
    {
       var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtConfig.SecretKey));

        var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier,id),
            new Claim(ClaimTypes.Name,userName),
        };

        foreach (var role in roles)
        {
            claims.Add(new Claim(ClaimTypes.Role, role));
        }

        var tokeOptions = new JwtSecurityToken(
           claims: claims,
           expires: DateTime.Now.AddMinutes(5),
           signingCredentials: signinCredentials
       );
        var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);

        return tokenString;
    }
}