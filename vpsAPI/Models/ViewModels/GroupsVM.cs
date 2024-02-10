namespace vpsAPI.Models.ViewModels
{
    public class GroupsVM:Groups
    {
        public string? DepartmentName { get; set; }
        public double AvgPerformance { get; set; }
    }
}
