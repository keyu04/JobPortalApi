using System.Security.Cryptography;
using System.Text;
using JobPortalAPI.DTOs;
using JobPortalAPI.Models;
using JobPortalAPI.Repositories.Interfaces;
using JobPortalAPI.Services.Interfaces;

namespace JobPortalAPI.Services.Implementations;

public class UserService(IUserRepositories userRepositories, AppDbContext appDbContext, IAuthService authService) : IUserService
{
    private readonly IUserRepositories _userRepositories = userRepositories;
    private readonly AppDbContext _appDbContext = appDbContext;
    private readonly IAuthService _authService = authService;
    public async Task<string> RegisterUser(UserRegister userRegister)
    {
        var userReg = new User()
        {
            Fname = userRegister.Fname,
            Lname = userRegister.Lname,
            Role = string.IsNullOrWhiteSpace(userRegister.Role!.ToUpper()) ? "User" : "User",
            Email = userRegister.Email,
            Phone = userRegister.Phone,
            Address = userRegister.Address,
            Password = HashPassword(userRegister.Password!),
            Resume = userRegister.Resume
        };
        var result = await _userRepositories.RegisterUser(userReg);
        await _appDbContext.SaveChangesAsync();
        return result;
    }
    public async Task<string> LoginUser(UserLogin userLogin)
    {
        var userCred = new User()
        {
            Email = userLogin.Email,
            Phone = userLogin.Phone,
            Password = userLogin.Password
        };
        var result = await _userRepositories.LoginUser(userCred);
        var Token = _authService.TokenGenerator(result);
        return Token;
    }

    public static string HashPassword(string password)
    {
        var sha256 = SHA256.Create();
        var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
        return Convert.ToBase64String(bytes);
    }
}