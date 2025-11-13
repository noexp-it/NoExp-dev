using Microsoft.EntityFrameworkCore;
using NoExp.Domain.Entities;
using NoExp.Domain.Interfaces;
using NoExp.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoExp.Infrastructure.Repositories
{
    public class JobAdRepository(ApplicationDbContext context) : IJobAdRepository
    {
        public async Task<JobAd> AddJobAdAsync(JobAd jobAd)
        {
            context.JobAds.Add(jobAd);
            await context.SaveChangesAsync();
            return jobAd;
        }

        public async Task<List<JobAd>> GetAllJobAdsAsync()
        {
            List<JobAd> jobAds = await context.JobAds.ToListAsync();
            return jobAds;
        }

        public async Task<List<JobAd>> GetJobAdsByEmployerProfileIdAsync(string employerProfileId)
        {
            List<JobAd> jobAds = await context.JobAds
                .Where(j => j.EmployerProfileId == employerProfileId)
                .ToListAsync();
            return jobAds;
        }

        public async Task<JobAd> GetJobAdByIdAsync(Guid jobAdId)
        {
            return await context.JobAds
                .Include(i => i.EmployerProfile)
                .FirstOrDefaultAsync(j => j.Id == jobAdId)!;
        }
    }
}
