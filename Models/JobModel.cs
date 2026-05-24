namespace JobPortalAPI.Models;

public class Jobs
{
    public int Id { set; get; }
    public string? Title { set; get; }
    public int Vacancy { set; get; }
    public int Experience { set; get; }
    public string? Location { set; get; }
    public string? Skills { set; get; }
}