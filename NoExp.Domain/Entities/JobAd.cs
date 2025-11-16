using NoExp.Domain.Enums.JobAd;
using System.ComponentModel.DataAnnotations;

namespace NoExp.Domain.Entities;

public class JobAd
{
    public Guid Id { get; set; }

    [Required][MaxLength(200)] public string Title { get; set; } = string.Empty;

    [Required] public string Description { get; set; } = string.Empty;

    [Required] public WorkType WorkType { get; set; }

    [Required][MaxLength(100)] public string Location { get; set; } = string.Empty;

    [Required] public WorkMode WorkMode { get; set; }

    [Required] public decimal? SalaryMin { get; set; }

    [Required] public decimal? SalaryMax { get; set; }

    [Required] public List<string> TechStack { get; set; } = [];

    public DateTime PublishDate { get; set; } = DateTime.UtcNow.ToUniversalTime();

    public DateTime? ExpirationDate { get; set; }

    public WorkStatus WorkStatus { get; set; } = WorkStatus.Inactive;

    public required string EmployerProfileId { get; set; }

    public required virtual EmployerProfile EmployerProfile { get; set; }
}