using JobPortalAPI.DTOs;

namespace JobPortalAPI.Services.Interfaces;

public interface IAuthService
{
    public string TokenGenerator(AuthCred authCred);
}