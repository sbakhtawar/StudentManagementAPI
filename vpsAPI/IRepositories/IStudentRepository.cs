using vpsAPI.Models;
using vpsAPI.Models.ViewModels;
namespace vpsAPI.IRepositories
{
    public interface IStudentRepository
    {
        Task<Students> GetById(int Id);
        IEnumerable<StudentsVM> GetByGroupId(int groupId);
        IEnumerable<StudentsVM> GetByDepartmentId(int DepartmentId);
        IEnumerable<Students> GetAll();
        Students Create(Students student);
        Task<Students> Edit(Students studentChanges);
        Students Delete(int Id);
    }
}
