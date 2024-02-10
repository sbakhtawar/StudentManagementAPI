namespace vpsAPI.DTOs.DTOsVM
{
    public class EditStudentDto
    {
        public int StudentId { get; set; }
        public string? StudentFirstName { get; set; }
        public string? StudentLastName { get; set; }
        public int StudentAge { get; set; }
        public int AcademicPerformance { get; set; }
        public int GroupId { get; set; }
    }
}
