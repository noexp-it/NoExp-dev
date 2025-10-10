using NoExp.Domain.Entities.Abstracts;
using NoExp.Domain.Enums;

namespace NoExp.Domain.Entities
{
    public class CandidateProfile : UserProfile
    {
        public override UserType UserType => UserType.Candidate;


        public string? Skills { get; set; }

        public string? Experience { get; set; }

        public string? Education { get; set; }

        public string? ResumeFileName { get; set; }

        public bool IsOpenToWork { get; set; }

        public decimal? ExpectedSalary { get; set; }

        public string? PreferredLocation { get; set; }
    }
}
