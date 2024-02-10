using AutoMapper;
using vpsAPI.Models;
using vpsAPI.DTOs;
using vpsAPI.DTOs.DTOsVM;
using vpsAPI.Models.ViewModels;
namespace vpsAPI.Helpers
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Department, DepartmentDto>();
            CreateMap<DepartmentVM, DepartmentDto>();
            CreateMap<Groups, GroupsDto>().ReverseMap();
            CreateMap<GroupsVM, GroupsVMDto>();

            CreateMap<CreateGroupDto, Groups>();
            CreateMap<EditGroupDto, Groups>();
            CreateMap<Students, StudentDto>().ReverseMap();
            CreateMap<CreateStudentDto, Students>();
            CreateMap<EditStudentDto, Students>();
            CreateMap<StudentsVM, StudentByGroupDto>();
            CreateMap<StudentsVM, StudentByDeptDto>();
        }
    }
}
