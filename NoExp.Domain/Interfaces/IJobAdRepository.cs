using NoExp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoExp.Domain.Interfaces
{
    public interface IJobAdRepository
    {
        Task<JobAd> AddJobAdAsync(JobAd jobAd);

        Task<List<JobAd>> GetAllJobAdsAsync();

        Task<List<JobAd>> GetJobAdsByEmployerProfileIdAsync(string employerProfileId);

        Task<JobAd> GetJobAdByIdAsync(Guid jobAdId);
    }
}
