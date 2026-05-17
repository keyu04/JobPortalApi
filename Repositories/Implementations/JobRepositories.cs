using JobPortalAPI.DTOs;
using JobPortalAPI.Models;
using JobPortalAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

public class JobRepositories(AppDbContext appDbContext) : IJobRepositories
{
    private readonly AppDbContext _appDbContext = appDbContext;

    public async Task<Pagination<Job>> GetAllJobs(int pageNumber, int pageSize, string searchTerm)
    {

        var query = _appDbContext.Jobs.AsQueryable();

        if (!string.IsNullOrEmpty(searchTerm))
        {
            query = query.Where(result =>
                result.Title!.Contains(searchTerm) ||
                result.Location!.Contains(searchTerm) ||
                result.Experince.ToString().Contains(searchTerm) ||
                result.Vacancy.ToString().Contains(searchTerm)
            );
        }

        var totalCount = await query.CountAsync();

        var result = await query
        .Skip((pageNumber - 1) * pageSize)
        .Take(pageSize)
        .ToListAsync();

        return new Pagination<Job>()
        {
            Result = result.Select(Job => new Job
            {
                Title = Job.Title,
                Experince = Job.Experince,
                Location = Job.Location,
                Vacancy = Job.Vacancy,
                Skills = Job.Skills
            }).ToList(),
            TotalCount = totalCount,
            PageNumber = pageNumber,
            PageSize = pageSize,
        };
    }
    public async Task<Job> GetJobById(int id)
    {
        var result = await _appDbContext.Jobs.FirstOrDefaultAsync(job => job.Id == id);
        var JobDetails = new Job()
        {
            Title = result!.Title,
            Experince = result!.Experince,
            Location = result!.Location,
            Skills = result!.Skills,
            Vacancy = result!.Vacancy
        };
        return JobDetails;
    }

    public async Task<string> AddJob(Jobs NewJob)
    {
        var check = await _appDbContext.Jobs.FirstOrDefaultAsync(j => j.Title == NewJob.Title);

        if (check != null)
        {
            return "Job Already Existed";
        }
        await _appDbContext.Jobs.AddAsync(NewJob);
        // await _appDbContext.SaveChangesAsync();
        return "Inserted Job Detail Successfully";
    }

    public async Task<string> UpdateJob(int id, Jobs job)
    {
        var result = await _appDbContext.Jobs.FindAsync(id);
        if (result == null)
        {
            return string.Empty;
        }
        _appDbContext.Jobs.Update(job);
        // await _appDbContext.SaveChangesAsync();
        return "Data update Successfully";
    }

    public async Task<string> DeleteJob(int id)
    {
        var result = await _appDbContext.Jobs.FindAsync(id);
        if (result == null)
        {
            return "Job not found";
        }
        _appDbContext.Jobs.Remove(result);
        // await _appDbContext.SaveChangesAsync();
        return "Job Delete Successfully";
    }

    public async Task<string> JobApply(JobApplicant JobApplicant)
    {
        var result = await _appDbContext.JobApplicants.FirstOrDefaultAsync(ja => ja.UserId == JobApplicant.UserId && ja.JobId == JobApplicant.JobId);
        if (result != null)
        {
            return "You Already Applied..";
        }
        await _appDbContext.JobApplicants.AddAsync(JobApplicant);
        // await _appDbContext.SaveChangesAsync();
        return "You applied for Job";
    }
    public async Task<Pagination<ApplicateList>> JobApplicate(int pageNumber, int pageSize, string searchTerm)
    {
        var query = _appDbContext.JobApplicants.AsQueryable();

        var JoinQuery = query.Join(
            _appDbContext.User,
            applicate => applicate.UserId,
            user => user.Id,
            (applicant, user) => new { applicant, user }
        ).Join(
            _appDbContext.Jobs,
            jobApplicant => jobApplicant.applicant.JobId,
            jobs => jobs.Id,
            (jobApplicant, jobs) => new
            {
                jobApplicant.applicant,
                jobApplicant.user,
                jobs
            }
        );

        if (!string.IsNullOrWhiteSpace(searchTerm))
        {
            JoinQuery = JoinQuery.Where(result =>
                result.user.Fname!.Contains(searchTerm) ||
                result.user.Lname!.Contains(searchTerm) ||
                result.jobs.Skills!.Contains(searchTerm)
            );
        }
        int totalCount = await JoinQuery.CountAsync();
        var result = await JoinQuery
        .Skip((pageNumber - 1) * pageSize)
        .Take(pageSize)
        .ToListAsync();

        var item = new List<ApplicateList>();
        foreach (var data in result)
        {
            item.Add(new ApplicateList()
            {
                JobTitle = data.jobs.Title,
                Name = data.user.Fname + " " + data.user.Lname,
                Skills = data.jobs.Skills
            });
        }

        return new Pagination<ApplicateList>()
        {
            Result = item,
            PageNumber = pageNumber,
            PageSize = pageSize,
            TotalCount = totalCount
        };
    }
}