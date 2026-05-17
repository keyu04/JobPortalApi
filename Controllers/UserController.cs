using JobPortalAPI.DTOs;
using JobPortalAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class UserController(IUserService userService) : ControllerBase
{
    private readonly IUserService _userService = userService;

    [HttpPost("UserLogin")]
    public async Task<IActionResult> UserLogin(UserLogin userLogin)
    {
        var result = await _userService.LoginUser(userLogin);
        if (result == string.Empty)
        {
            return NotFound();
        }
        return Ok(result);
    }

    [HttpPost("UserRegister")]
    public async Task<IActionResult> UserRegister(UserRegister userRegister)
    {
        var result = await _userService.RegisterUser(userRegister);
        return Ok(result);
    }
}