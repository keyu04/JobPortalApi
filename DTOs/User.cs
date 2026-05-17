using System.ComponentModel.DataAnnotations;

namespace JobPortalAPI.DTOs;

public class UserRegister
{
    [Required]
    public string? Fname { set; get; }
    [Required]
    public string? Lname { set; get; }
    [Required]
    public string? Role { set; get; } = "User";
    public string? Email { set; get; }

    [Required]
    public int? Phone { set; get; }
    public string? Address { set; get; }
    [Required]
    public string? Password { set; get; }
    [Required]
    public string? Resume { set; get; }
}

public class UserLogin
{
    public string? Email { set; get; }
    public int? Phone { set; get; }
    [Required]
    public string? Password { set; get; }
}
