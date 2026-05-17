using JobPortalAPI.DTOs;

namespace JobPortalAPI.Services.Interfaces;

public interface IUserService
{
    public Task<string> RegisterUser(UserRegister userRegister);
    public Task<string> LoginUser(UserLogin userLogin);
}