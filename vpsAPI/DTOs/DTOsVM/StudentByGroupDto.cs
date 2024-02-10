namespace vpsAPI.DTOs.DTOsVM
{
    public class StudentByGroupDto
    {
        public int StudentId { get; set; }
        public string? StudentFirstName { get; set; }
        public string? StudentLastName { get; set; }
        public int StudentAge { get; set; }
        public int AcademicPerformance { get; set; }
        public string? GroupName { get; set; }
    }
}
