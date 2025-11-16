using NoExp.Application.Interfaces;
using NoExp.Domain.Entities;
using NoExp.Domain.Entities.Abstracts;
using NoExp.Domain.Interfaces;

namespace NoExp.Application.Services;

public class ProfileService(IProfileRepository profileRepository) : IProfileService
{
    public async Task<UserProfile> SaveProfileAsync(UserProfile userProfile)
    {
        return await profileRepository.AddProfileAsync(userProfile);
    }

    public async Task<EmployerProfile?> GetEmployerProfileByUserIdAsync(string userId)
    {
        return await profileRepository.GetEmployerProfileByUserIdAsync(userId);
    }

    public async Task<CandidateProfile?> GetCandidateProfileByUserIdAsync(string userId)
    {
        return await profileRepository.GetCandidateProfileByUserIdAsync(userId);
    }

    public async Task<EmployerProfile> UpdateEmployerProfileAsync(EmployerProfile updatedEmployerProfile)
    {
        return await profileRepository.UpdateEmployerProfileAsync(updatedEmployerProfile);
    }
}