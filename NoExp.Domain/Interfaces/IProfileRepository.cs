using NoExp.Domain.Entities.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoExp.Domain.Interfaces
{
    public interface IProfileRepository
    {
        public void AddProfileAsync(UserProfile profile);
    }
}
