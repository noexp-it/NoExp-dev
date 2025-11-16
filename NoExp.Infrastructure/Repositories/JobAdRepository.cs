using Microsoft.EntityFrameworkCore;
using NoExp.Domain.Entities;
using NoExp.Domain.Interfaces;
using NoExp.Infrastructure.Persistence;

namespace NoExp.Infrastructure.Repositories;

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
        var jobAds = await context.JobAds.ToListAsync();
        return jobAds;
    }

    public async Task<List<JobAd>> GetJobAdsByEmployerProfileIdAsync(string employerProfileId)
    {
        var jobAds = await context.JobAds
            .Where(j => j.EmployerProfileId == employerProfileId)
            .ToListAsync();
        return jobAds;
    }

    public async Task<JobAd?> GetJobAdByIdAsync(Guid jobAdId)
    {
        return await context.JobAds
            .Include(i => i.EmployerProfile)
            .FirstOrDefaultAsync(j => j.Id == jobAdId)!;
    }
}