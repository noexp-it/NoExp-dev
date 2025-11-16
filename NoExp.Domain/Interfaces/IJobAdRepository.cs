using NoExp.Domain.Entities;

namespace NoExp.Domain.Interfaces;

public interface IJobAdRepository
{
    Task<JobAd> AddJobAdAsync(JobAd jobAd);

    Task<List<JobAd>> GetAllJobAdsAsync();

    Task<List<JobAd>> GetJobAdsByEmployerProfileIdAsync(string employerProfileId);

    Task<JobAd?> GetJobAdByIdAsync(Guid jobAdId);
}