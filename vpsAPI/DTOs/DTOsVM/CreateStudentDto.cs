namespace vpsAPI.DTOs.DTOsVM
{
    public class CreateStudentDto
    {
        public string? StudentFirstName { get; set; }
        public string? StudentLastName { get; set; }
        public int StudentAge { get; set; }
        public int AcademicPerformance { get; set; }
        public int GroupId { get; set; }

    }
}
