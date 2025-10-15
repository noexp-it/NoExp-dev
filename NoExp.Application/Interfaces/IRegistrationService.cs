using NoExp.Domain.Entities.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoExp.Application.Interfaces
{
    public interface IRegistrationService
    {
        public Task<UserProfile> SaveProfileAsync(UserProfile userProfile);
    }
}
