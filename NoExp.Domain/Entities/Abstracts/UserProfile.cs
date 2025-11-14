using NoExp.Domain.Enums;

namespace NoExp.Domain.Entities.Abstracts;

public abstract class UserProfile
{
    public string Id { get; set; } = string.Empty;
    public string UserId { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }


    public string? Bio { get; set; }
    public string? Website { get; set; }
    public string? Location { get; set; }


    public abstract UserType UserType { get; }
}