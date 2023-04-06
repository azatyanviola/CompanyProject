using AutoMapper;
using CompanyProject.RequestModels;
using Core.Models;
using Core.ResponsModels;

namespace CompanyProject.MappingProfile
{
    public class AutoMapper : Profile
    {
        public AutoMapper()

        {

            CreateMap<Department, DepartmentResponsModel>();
            CreateMap<Position, PositionResponseModel>();
            CreateMap<Branch, BranchResponsModel>();
            CreateMap<CompanyUserAddModel, UserCompany>();
            CreateMap<CompanyUserAddModel, User>();
            CreateMap<CompanyUserAddModel, Position>();
            CreateMap<CompanyUserUpdateModel, User>();
            CreateMap<CompanyUserUpdateModel, UserCompany>();
           
            CreateMap<CompanyUserUpdateModel, Position>()
              .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.PositionName))
              
              .ForMember(dest => dest.Id, opt => opt.Ignore());


            
        }
    }
}
