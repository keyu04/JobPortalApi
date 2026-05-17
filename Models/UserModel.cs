namespace JobPortalAPI.Models;

public class User
{
    public int Id { set; get; }
    public string? Fname { set; get; }
    public string? Lname { set; get; }
    public string? Email { set; get; }
    public int? Phone { set; get; }
    public string? Address { set; get; }
    public string? Password { set; get; }
    public string? Resume { set; get; }
    public string? Role { set; get; } = "User";

}