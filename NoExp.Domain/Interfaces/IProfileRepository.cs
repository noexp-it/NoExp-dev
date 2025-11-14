using NoExp.Domain.Entities;
using NoExp.Domain.Entities.Abstracts;

namespace NoExp.Domain.Interfaces;

public interface IProfileRepository
{
    public Task<UserProfile> AddProfileAsync(UserProfile userProfile);
    public Task<EmployerProfile> GetEmployerProfileByUserIdAsync(string userId);
    public Task<CandidateProfile> GetCandidateProfileByUserIdAsync(string userId);
    public Task<EmployerProfile> UpdateEmployerProfileAsync(EmployerProfile updatedProfile);
}