using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using JobPortalAPI.Common.Setting;
using JobPortalAPI.DTOs;
using JobPortalAPI.Services.Interfaces;
using Microsoft.IdentityModel.Tokens;

namespace JobPortalAPI.Services.Implementations;

public class AuthService : IAuthService
{

    public string TokenGenerator(AuthCred authCred)
    {
        var claims = new[]
        {
        new Claim(ClaimTypes.NameIdentifier, authCred.Id.ToString()!),
        new Claim(ClaimTypes.Role, authCred.Role!)
    };

        var key = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(AppSetting.JwtSecreteKey!));

        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: AppSetting.JwtIssuer,
            audience: AppSetting.JwtAudience,
            claims: claims,
            expires: DateTime.UtcNow.AddHours(1),
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
