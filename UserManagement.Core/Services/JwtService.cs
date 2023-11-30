using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using UserManagement.Core.Entities;
using UserManagement.Core.Interfaces.Service;

namespace UserManagement.Core.Services;

public class JwtService : IJwtService
{
    private readonly AccessTokenConfiguration _options;

    public JwtService(IOptions<AccessTokenConfiguration> options)
    {
        _options = options.Value;
    }

    public string CreateToken(string userName)
    {
        var issuer = _options.Issuer;
        var audience = _options.Audience;
        var key = Encoding.UTF8.GetBytes(_options.Key);
        var expiresMinutes = _options.AccessTokenExpiresMinutes;

        var securityTokenDescriptor = new SecurityTokenDescriptor()
        {
            Subject = new ClaimsIdentity(new[]
            {
                new Claim("Id", Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Name, userName),
                new Claim(JwtRegisteredClaimNames.Email, userName),
            }),

            Expires = DateTime.Now.AddMinutes(expiresMinutes),
            Issuer = issuer,
            Audience = audience,
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256),
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(securityTokenDescriptor);
        var accessToken = tokenHandler.WriteToken(token);

        return accessToken;
    }
}
