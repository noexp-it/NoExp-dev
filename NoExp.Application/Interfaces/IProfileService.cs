using NoExp.Domain.Entities;
using NoExp.Domain.Entities.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoExp.Application.Interfaces
{
    public interface IProfileService
    {
        public Task<UserProfile> SaveProfileAsync(UserProfile userProfile);

        public Task<EmployerProfile> GetEmployerProfileByUserIdAsync(string userId);

        public Task<CandidateProfile> GetCandidateProfileByUserIdAsync(string userId);

        public Task<EmployerProfile> UpdateEmployerProfileAsync(EmployerProfile updatedEmployerProfile);
    }
}
