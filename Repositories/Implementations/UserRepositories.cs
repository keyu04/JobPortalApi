
using JobPortalAPI.DTOs;
using JobPortalAPI.Models;
using JobPortalAPI.Repositories.Interfaces;
using JobPortalAPI.Services.Implementations;
using Microsoft.EntityFrameworkCore;

public class UserRepositories(AppDbContext appDbContext) : IUserRepositories
{
    private readonly AppDbContext _appDbContext = appDbContext;
    public async Task<string> RegisterUser(User userRegister)
    {
        try
        {
            if (userRegister.Email != null)
            {
                var emailExists = await _appDbContext.User.AnyAsync(user => user.Email == userRegister.Email);
                if (emailExists)
                {
                    return "Email already exists.";
                }
            }
            await _appDbContext.User.AddAsync(userRegister);
            return "User registered successfully.";
        }
        catch (System.Exception)
        {
            throw new Exception("Error while registering user.");
        }
    }

    public async Task<AuthCred> LoginUser(User userLogin)
    {
        var result = await _appDbContext.User.FirstOrDefaultAsync(user => (user.Email == userLogin.Email || user.Phone == userLogin.Phone) && user.Password == UserService.HashPassword(userLogin.Password!));
        if (result == null)
        {
            return null!;
        }
        var LoginCred = new AuthCred()
        {
            Id = result.Id,
            Role = result.Role
        };
        return LoginCred;
    }
}