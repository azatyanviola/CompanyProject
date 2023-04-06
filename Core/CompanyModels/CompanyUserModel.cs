using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CompanyModels
{
    public class CompanyUserModel : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Branch { get; set; }
        public string Department { get; set; }
        public string Position { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime? BirthDate { get; set; }
    }
}
