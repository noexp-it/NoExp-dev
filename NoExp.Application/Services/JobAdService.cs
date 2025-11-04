using NoExp.Application.Interfaces;
using NoExp.Domain.Entities;
using NoExp.Domain.Entities.Abstracts;
using NoExp.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoExp.Application.Services
{
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
    }
}
