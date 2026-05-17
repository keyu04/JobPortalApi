using JobPortalAPI.Models;
using Microsoft.EntityFrameworkCore;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<User> User { set; get; }
    public DbSet<Jobs> Jobs { set; get; }
    public DbSet<JobApplicant> JobApplicants { set; get; }
}