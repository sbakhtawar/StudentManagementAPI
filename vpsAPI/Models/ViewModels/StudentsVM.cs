namespace vpsAPI.Models.ViewModels
{
    public class StudentsVM:Students
    {
        public string? GroupName { get; set; }
        public string? DepartmentName { get; set; }
        public int StudentCount { get; set; }
        public int AvgPerformance { get; set; }
    }
}
