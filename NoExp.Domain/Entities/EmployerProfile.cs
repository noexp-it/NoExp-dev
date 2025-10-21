using NoExp.Domain.Entities.Abstracts;
using NoExp.Domain.Enums;

namespace NoExp.Domain.Entities
{
    public class EmployerProfile : UserProfile
    {
        public override UserType UserType => UserType.Employer;

        public string CompanyName { get; set; } = string.Empty;
        public string IdentificationNumber { get; set; } = "0000000000";
        public string? CompanyDescription { get; set; }
        public int? CompanySize { get; set; }
        public string? CompanyAddress { get; set; }
        public bool IsVerified { get; set; } = false;
    }
}
