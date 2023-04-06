using Core.Models;
using Core.ResponsModels;

namespace CompanyProject.ResponseModels
{

    public class CompanyUsersFilterData
    {
        public IList<PositionResponseModel> Positions { get; set; }
        public IList<DepartmentResponsModel> Departments { get; set; }
        public IList<Branch> Branches { get; set; }


        public CompanyUsersFilterData()
        {
            Positions = new List<PositionResponseModel>();
            Departments = new List<DepartmentResponsModel>();
            Branches = new List<Branch>();
        }
    }
}
