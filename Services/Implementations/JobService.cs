using JobPortalAPI.DTOs;
// using JobPortalAPI.Migrations;
using JobPortalAPI.Models;
using JobPortalAPI.Repositories.Interfaces;
using JobPortalAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc.Diagnostics;

namespace JobPortalAPI.Services.Implementations;

public class JobService(IJobRepositories JobRepositories, AppDbContext appDbContext, ILogger<JobService> logger) : IJobService
{
    private readonly IJobRepositories _JobRepositories = JobRepositories;
    private readonly AppDbContext _appDbContext = appDbContext;
    private readonly ILogger<JobService> _logger = logger;
    public async Task<string> JobInsert(Job job)
    {
        _logger.LogInformation("Enter JobService JobInsert");
        var newJobs = new Jobs()
        {
            Id = 0,
            Title = job.Title,
            Skills = job.Skills,
            Location = job.Location,
            Experience = job.Experience,
            Vacancy = job.Vacancy
        };
        var resutl = await _JobRepositories.AddJob(newJobs);
        await _appDbContext.SaveChangesAsync();

        _logger.LogInformation("Exit JobService JobInsert");
        return resutl;

    }
    public async Task<string> JobUpdate(int id, Job job)
    {
        _logger.LogInformation("Enter JobService JobUpdate");
        var UpdateJob = new Jobs()
        {
            Title = job.Title,
            Skills = job.Skills,
            Experience = job.Experience,
            Location = job.Location,
            Vacancy = job.Vacancy
        };
        var result = await _JobRepositories.UpdateJob(id, UpdateJob);
        await _appDbContext.SaveChangesAsync();

        _logger.LogInformation("Exit JobService JobUpdate");
        return result;
    }
    public async Task<string> JobDelete(int id)
    {
        _logger.LogInformation("Enter JobService JobDelete");
        var result = await _JobRepositories.DeleteJob(id);
        await _appDbContext.SaveChangesAsync();
        _logger.LogInformation("Exit JobService JobDelete");
        return result;
    }
    public async Task<Pagination<Job>> JobDisplay(int pageNumber, int pageSize, string searchTerm)
    {
        _logger.LogInformation("Enter JobService JobDisplay");

        var result = await _JobRepositories.GetAllJobs(pageNumber, pageSize, searchTerm);
        _logger.LogInformation("Exit JobService JobDisplay");
        return result;
    }
    public async Task<Job> JobDisplayById(int id)
    {
        _logger.LogInformation("Enter JobService JobDisplayById");
        var result = await _JobRepositories.GetJobById(id);
        _logger.LogInformation("Exit JobService JobDisplayById");
        return result;
    }
    public async Task<string> JobApply(JobApply jobApply)
    {
        var JobApply = new JobApplicant()
        {
            JobId = jobApply.JobId,
            UserId = jobApply.UserId,
            DateTime = DateTime.UtcNow
        };
        _logger.LogInformation("Enter JobService JobApply");
        var result = await _JobRepositories.JobApply(JobApply);
        await _appDbContext.SaveChangesAsync();
        _logger.LogInformation("Exit JobService JobApply");
        return result;
    }
    public async Task<Pagination<ApplicateList>> JobApplicate(int pageNumber, int pageSize, string searchTerm)
    {
        _logger.LogInformation("Enter JobService JobApplicate");
        var result = await _JobRepositories.JobApplicate(pageNumber, pageSize, searchTerm);
        _logger.LogInformation("Exit JobService JobApplicate");
        return result;
    }
}