namespace vpsAPI.DTOs.DTOsVM
{
    public class GroupsVMDto
    {
        public int GroupId { get; set; }
        public string? GroupName { get; set; }
        public string? GroupDescription { get; set; }
        public string? DepartmentName { get; set; }
        public double AvgPerformance { get; set; }
    }
}
