using System.ComponentModel.DataAnnotations;

namespace JobPortalAPI.DTOs;

public class Job
{
    [Required]
    public string? Title { set; get; }
    [Required]
    public int Vacancy { set; get; }
    [Required]
    public int Experience { set; get; }
    [Required]
    public string? Location { set; get; }
    [Required]
    public string? Skills { set; get; }
}

public class JobApply
{
    [Required]
    public int UserId { set; get; }
    [Required]
    public int JobId { set; get; }
}

public class ApplicateList
{
    public string? Name { set; get; }
    public string? JobTitle { set; get; }
    public string? Skills { set; get; }
}

public class Pagination<Job>
{
    public List<Job>? Result { set; get; }
    public int TotalCount { set; get; }
    public int PageNumber { set; get; }
    public int PageSize { set; get; }
    public int TotalPages => (int)Math.Ceiling((double)TotalCount / PageSize);
    public bool HasPrevPage => PageNumber > 1;
    public bool HasNextPage => PageNumber < TotalPages;
}