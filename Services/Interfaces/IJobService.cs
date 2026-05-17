using JobPortalAPI.DTOs;
using JobPortalAPI.Models;

namespace JobPortalAPI.Services.Interfaces;

public interface IJobService
{
    public Task<string> JobInsert(Job job);
    public Task<string> JobUpdate(int id, Job job);
    public Task<string> JobDelete(int id);
    public Task<Pagination<Job>> JobDisplay(int pageNumber, int pageSize, string searchTerm);
    public Task<Job> JobDisplayById(int id);
    public Task<string> JobApply(JobApply jobApply);
    public Task<Pagination<ApplicateList>> JobApplicate(int pageNumber, int pageSize, string searchTerm);
}