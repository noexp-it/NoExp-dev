using NoExp.Domain.Entities.Abstracts;
using NoExp.Domain.Interfaces;
using NoExp.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoExp.Infrastructure.Repositories
{
    public class ProfileRepository(ApplicationDbContext context) : IProfileRepository
    {
        public async void AddProfileAsync(UserProfile profile)
        {
            context.UserProfiles.Add(profile);
            await context.SaveChangesAsync();
        }
    }
}
