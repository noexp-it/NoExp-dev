using NoExp.Application.Interfaces;
using NoExp.Domain.Entities;
using NoExp.Domain.Interfaces;

namespace NoExp.Application.Services;

public class JobAdService(IJobAdRepository jobAdRepository) : IJobAdService
{
    public async Task<JobAd> SaveJobAdAsync(JobAd jobAd)
    {
        return await jobAdRepository.AddJobAdAsync(jobAd);
    }

    public async Task<List<JobAd>> GetAllJobAdsAsync()
    {
        return await jobAdRepository.GetAllJobAdsAsync();
    }

    public async Task<List<JobAd>> GetAllEmployerJobAdsAsync(string employerProfileId)
    {
        return await jobAdRepository.GetJobAdsByEmployerProfileIdAsync(employerProfileId);
    }

    public async Task<JobAd> GetJobAdByIdAsync(Guid jobAdId)
    {
        return await jobAdRepository.GetJobAdByIdAsync(jobAdId);
    }
}