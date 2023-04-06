using Core.Models;

namespace CompanyProject.RequestModels
{
    public class CompanyUserAddModel 
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int CompanyId { get; set; }
        public int PhoneCodeId { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public int DepartmentId { get; set; }
        public int PositionId { get; set; }
        public string PositionName { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
