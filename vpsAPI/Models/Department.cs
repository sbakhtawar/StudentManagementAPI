using System.ComponentModel.DataAnnotations;

namespace vpsAPI.Models
{
    public class Department
    {
        [Key]
        public int DepartmentID { get; set; }
        public string? DepartmentName { get; set; }
        public string? DepartmentDescription { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? CreatedBy { get; set; }
        public virtual List<Groups> Groups { get; set; }
    }
    
}
