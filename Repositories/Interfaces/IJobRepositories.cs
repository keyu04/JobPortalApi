using JobPortalAPI.DTOs;
using JobPortalAPI.Models;

namespace JobPortalAPI.Repositories.Interfaces;

public interface IJobRepositories
{
    Task<Pagination<Job>> GetAllJobs(int pageNumber, int pageSize, string searchTerm);
    Task<Job> GetJobById(int id);
    Task<string> AddJob(Jobs job);
    Task<string> UpdateJob(int id, Jobs job);
    Task<string> DeleteJob(int id);
    Task<string> JobApply(JobApplicant jobApply);
    Task<Pagination<ApplicateList>> JobApplicate(int pageNumber, int pageSize, string searchTerm);
}