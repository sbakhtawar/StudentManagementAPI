namespace vpsAPI.DTOs.DTOsVM
{
    public class CreateGroupDto
    {
        public string? GroupName { get; set; }
        public string? GroupDescription { get; set; }
        public int DepartmentId { get; set; }
    }
}
