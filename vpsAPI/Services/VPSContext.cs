using Microsoft.EntityFrameworkCore;
using vpsAPI.Models;

namespace vpsAPI.Services
{
    public class VPSContext: DbContext
    {
        public VPSContext(DbContextOptions<VPSContext> options) : base(options)
        {

        }
        public DbSet<Students> Students { get; set; }
        public DbSet<Groups>  Groups { get; set; }
        public  DbSet<Department> Department { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>().HasData(
                new Department
                {
                    DepartmentID=1,
                    DepartmentName="Computer Science",
                    DepartmentDescription="All courses related to the computer domain",
                    CreatedDate=DateTime.Now,
                    CreatedBy="1"
                },
                 new Department
                 {
                     DepartmentID=2,
                     DepartmentName = "Physics",
                     DepartmentDescription = "All courses related to the physics domain",
                     CreatedDate = DateTime.Now,
                     CreatedBy = "1"
                 },
                  new Department
                  {
                      DepartmentID=3,
                      DepartmentName = "Mathemathics",
                      DepartmentDescription = "All courses related to the maths domain",
                      CreatedDate = DateTime.Now,
                      CreatedBy = "1"
                  }
                );
            modelBuilder.Entity<Department>().Navigation(x => x.Groups).AutoInclude();
            modelBuilder.Entity<Groups>().Navigation(x => x.Students).AutoInclude();
        }
        

    }
}
