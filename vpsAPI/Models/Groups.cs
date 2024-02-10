using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FluentValidation;

namespace vpsAPI.Models
{
    public class Groups
    {
        [Key]
        public int GroupId { get; set; }
        public string? GroupName { get; set; }
        public string? GroupDescription { get; set; }
        [ForeignKey("Department")]
        public int DepartmentId { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? CreatedBy { get; set; }
        public virtual Department Department { get; set; }
        public virtual List<Students> Students { get; set; }
    }
   
}
