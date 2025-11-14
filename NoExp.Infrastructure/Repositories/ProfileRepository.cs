using Microsoft.EntityFrameworkCore;
using NoExp.Domain.Entities;
using NoExp.Domain.Entities.Abstracts;
using NoExp.Domain.Interfaces;
using NoExp.Infrastructure.Persistence;

namespace NoExp.Infrastructure.Repositories;

public class ProfileRepository(ApplicationDbContext context) : IProfileRepository
{
    public async Task<UserProfile> AddProfileAsync(UserProfile userProfile)
    {
        context.UserProfiles.Add(userProfile);
        await context.SaveChangesAsync();
        return userProfile;
    }

    public async Task<EmployerProfile?> GetEmployerProfileByUserIdAsync(string userId)
    {
        return await context.EmployerProfiles.FirstOrDefaultAsync(p => p.UserId == userId);
    }

    public async Task<CandidateProfile> GetCandidateProfileByUserIdAsync(string userId)
    {
        return await context.CandidateProfiles.FirstOrDefaultAsync(p => p.UserId == userId)!;
    }

    public async Task<EmployerProfile> UpdateEmployerProfileAsync(EmployerProfile updatedProfile)
    {
        var existing = await context.EmployerProfiles
            .FirstOrDefaultAsync(p => p.Id == updatedProfile.Id || p.UserId == updatedProfile.UserId);

        if (existing == null)
            throw new InvalidOperationException("Employer profile not found.");

        existing.CompanyName = updatedProfile.CompanyName;
        existing.IdentificationNumber = updatedProfile.IdentificationNumber;
        existing.CompanySize = updatedProfile.CompanySize;
        existing.CompanyDescription = updatedProfile.CompanyDescription;
        existing.CompanyAddress = updatedProfile.CompanyAddress;
        existing.UpdatedAt = updatedProfile.UpdatedAt ?? DateTime.UtcNow;

        await context.SaveChangesAsync();
        return existing;
    }
}