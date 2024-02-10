namespace vpsAPI.DTOs.DTOsVM
{
    public class EditGroupDto
    {
        public int GroupId { get; set; }
        public string? GroupName { get; set; }
        public string? GroupDescription { get; set; }
        public int DepartmentId { get; set; }
    }
}
