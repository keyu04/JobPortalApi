using JobPortalAPI.DTOs;
using JobPortalAPI.Models;

namespace JobPortalAPI.Repositories.Interfaces;

public interface IUserRepositories
{
    public Task<string> RegisterUser(User userRegister);
    public Task<AuthCred> LoginUser(User userLogin);
}