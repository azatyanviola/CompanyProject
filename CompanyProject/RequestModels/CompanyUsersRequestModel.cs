namespace CompanyProject.RequestModels
{
    public class CompanyUsersRequestModel
    {
        
            public int CompanyId { get; set; }
            public string? SearchText { get; set; }
            public int? BranchId { get; set; }
            public int? DepartmentId { get; set; }
            public int? PositionId { get; set; }
        
    }
}
