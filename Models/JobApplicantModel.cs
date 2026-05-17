namespace JobPortalAPI.Models;

public class JobApplicant
{
    public int Id { set; get; }
    public int UserId { set; get; }
    public int JobId { set; get; }
    public DateTime DateTime { set; get; }
}