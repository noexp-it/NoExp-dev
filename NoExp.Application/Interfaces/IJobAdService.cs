using NoExp.Domain.Entities;

namespace NoExp.Application.Interfaces
{
    public interface IJobAdService
    {
        Task<JobAd> SaveJobAdAsync(JobAd jobAd);

        Task<List<JobAd>> GetAllJobAdsAsync();
    }
}