using JobPortalAPI.DTOs;
using JobPortalAPI.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("JobPortal/[controller]")]
public class JobController(IJobService jobService) : ControllerBase
{
    private readonly IJobService _jobService = jobService;
    [Authorize(Roles = "Admin")]
    [HttpPost("")]
    public async Task<IActionResult> JobInsert(Job job)
    {
        var result = await _jobService.JobInsert(job);
        return Ok(result);
    }

    [Authorize(Roles = "Admin")]
    [HttpPut("")]
    public async Task<IActionResult> JobUpdate(int id, Job job)
    {
        var result = await _jobService.JobUpdate(id, job);
        return Ok(result);
    }

    [Authorize(Roles = "Admin")]
    [HttpDelete("{id}")]
    public async Task<IActionResult> JobDelete(int id)
    {
        var result = await _jobService.JobDelete(id);
        return Ok(result);
    }

    [Authorize]
    [HttpGet("Details")]
    public async Task<IActionResult> JobDisplay(int pageNumber, int pageSize, string searchTerm = null!)
    {
        var result = await _jobService.JobDisplay(pageNumber, pageSize, searchTerm);
        return Ok(result);
    }

    [Authorize]
    [HttpGet("{id}/Detail")]
    public async Task<IActionResult> JobDisplayById(int id)
    {
        var result = await _jobService.JobDisplayById(id);
        return Ok(result);
    }

    [Authorize(Roles = "User")]
    [HttpPost("JobApply")]
    public async Task<IActionResult> JobApply(JobApply jobApply)
    {
        var result = await _jobService.JobApply(jobApply);
        return Ok(result);
    }

    [Authorize(Roles = "Admin")]
    [HttpGet("JobApplicate")]
    public async Task<IActionResult> JobApplicate(int pageNumber, int pageSize, string searchTerm)
    {
        var result = await _jobService.JobApplicate(pageNumber, pageSize, searchTerm);
        return Ok(result);
    }
}