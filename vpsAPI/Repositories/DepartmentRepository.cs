using vpsAPI.Models.ViewModels;
using vpsAPI.IRepositories;
using vpsAPI.Models;
using vpsAPI.Services;

namespace vpsAPI.SQLRepositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private  readonly VPSContext _dbContext;
        public DepartmentRepository(VPSContext _dbContext)
        {
            this._dbContext = _dbContext;
        }
        public IEnumerable<DepartmentVM> GetAll()
        {
            var departments = (
               from d in _dbContext.Department
               join g in _dbContext.Groups
               on d.DepartmentID equals g.DepartmentId into tblgd
               from gd in tblgd.DefaultIfEmpty()
               join s in _dbContext.Students
               on gd.GroupId equals s.GroupId into tblgs
               from gs in tblgs.DefaultIfEmpty()
               group new { gd,gs } by new
               {
                   d.DepartmentID,
                   d.DepartmentName,
                   d.DepartmentDescription
               }
               into drow
               select new DepartmentVM
               {
                   DepartmentID=drow.Key.DepartmentID,
                   DepartmentName=drow.Key.DepartmentName,
                   DepartmentDescription=drow.Key.DepartmentDescription,
                   AvgPerformance = drow.Average(x => x.gs.AcademicPerformance) != null ?
                                       drow.Average(x => x.gs.AcademicPerformance) : 0.0
               }).ToList();
            return departments;
        }

        public async Task<DepartmentVM> GetById(int Id)
        {
            var department = (
              from d in _dbContext.Department
              join g in _dbContext.Groups
              on d.DepartmentID equals g.DepartmentId into tblgd
              from gd in tblgd.DefaultIfEmpty()
              join s in _dbContext.Students
              on gd.GroupId equals s.GroupId into tblgs
              from gs in tblgs.DefaultIfEmpty()
              where d.DepartmentID == Id
              group new { gd, gs } by new
              {
                  d.DepartmentID,
                  d.DepartmentName,
                  d.DepartmentDescription
              }
              into drow
              select new DepartmentVM
              {
                  DepartmentID = drow.Key.DepartmentID,
                  DepartmentName = drow.Key.DepartmentName,
                  DepartmentDescription = drow.Key.DepartmentDescription,
                  AvgPerformance = drow.Average(x => x.gs.AcademicPerformance) != null ?
                                      drow.Average(x => x.gs.AcademicPerformance) : 0.0
              }).FirstOrDefault();
            return department;
        }
    }
}
