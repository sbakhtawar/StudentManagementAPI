namespace vpsAPI.DTOs
{
    public class GroupsDto
    {
        public int GroupId { get; set; }
        public string? GroupName { get; set; }
        public string? GroupDescription { get; set; }
        public int DepartmentId { get; set; }
    }
}
