using vpsAPI.IRepositories;
using vpsAPI.Models;
using vpsAPI.Models.ViewModels;
using vpsAPI.Services;
namespace vpsAPI.SQLRepositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly VPSContext _dbContext;
        public StudentRepository(VPSContext _dbContext)
        {
           this._dbContext = _dbContext;
        }
        public Students Create(Students student)
        {
           
            _dbContext.Students.Add(student);
            _dbContext.SaveChanges();
            return student;
        }

        public Students Delete(int Id)
        {
            Students studentInfo = _dbContext.Students.Find(Id);
            if (studentInfo != null)
            {
                _dbContext.Students.Remove(studentInfo);
                _dbContext.SaveChanges();
            }
            return studentInfo;
        }

        public async Task<Students> Edit(Students studentChanges)
        {
            _dbContext.ChangeTracker.Clear();
            var student = _dbContext.Students.Update(studentChanges);
            await _dbContext.SaveChangesAsync();
            return studentChanges;
        }

        public IEnumerable<Students> GetAll()
        {
            var studentsAll = (
              from stu in _dbContext.Students
              select new Students
              {
                  StudentId=stu.StudentId,
                  StudentFirstName=stu.StudentFirstName,
                  StudentLastName=stu.StudentLastName,
                  StudentAge=stu.StudentAge,
                  AcademicPerformance=stu.AcademicPerformance,
                  GroupId=stu.GroupId,
                  CreatedBy=stu.CreatedBy,
                  CreatedDate=stu.CreatedDate
                 
              }).ToList();
            return studentsAll;
        }

        public IEnumerable<StudentsVM> GetByDepartmentId(int DepartmentId)
        {

            var studentsByDept = (
             from stu in _dbContext.Students
             join g in _dbContext.Groups
             on stu.GroupId equals g.GroupId
             join d in _dbContext.Department
             on g.DepartmentId equals d.DepartmentID
             where d.DepartmentID == DepartmentId
             select new StudentsVM
             {
                 StudentId = stu.StudentId,
                 StudentFirstName = stu.StudentFirstName,
                 StudentLastName = stu.StudentLastName,
                 StudentAge = stu.StudentAge,
                 AcademicPerformance = stu.AcademicPerformance,
                 GroupName = g.GroupName,
                 DepartmentName=d.DepartmentName,
                 CreatedBy = stu.CreatedBy,
                 CreatedDate = stu.CreatedDate

             }).ToList();
            return studentsByDept;
        }

        public IEnumerable<StudentsVM> GetByGroupId(int groupId)
        {
            var studentsByGroup = (
             from stu in _dbContext.Students
             join g in _dbContext.Groups
             on stu.GroupId equals g.GroupId
             where g.GroupId == groupId
             select new StudentsVM
             {
                 StudentId = stu.StudentId,
                 StudentFirstName = stu.StudentFirstName,
                 StudentLastName = stu.StudentLastName,
                 StudentAge = stu.StudentAge,
                 AcademicPerformance = stu.AcademicPerformance,
                 GroupName = g.GroupName,
                 CreatedBy = stu.CreatedBy,
                 CreatedDate = stu.CreatedDate

             }).ToList();
            return studentsByGroup;
        }

        public async Task<Students> GetById(int Id)
        {
            var student = await _dbContext.Students.FindAsync(Id);
            return student;
        }

        
    }
}
