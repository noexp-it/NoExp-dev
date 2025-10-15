using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using NoExp.Application.Interfaces;
using NoExp.Domain.Entities.Abstracts;
using NoExp.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoExp.Application.Services
{
    public class RegistrationService(IProfileRepository profileRepository) : IRegistrationService
    {
        public async Task<UserProfile> SaveProfileAsync(UserProfile userProfile)
        {
            UserProfile savedProfile = await profileRepository.AddProfileAsync(userProfile);
            return savedProfile;
        }
    }
}
