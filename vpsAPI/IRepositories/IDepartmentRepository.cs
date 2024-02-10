using vpsAPI.Models;
using vpsAPI.Models.ViewModels;
namespace vpsAPI.IRepositories
{
    public interface IDepartmentRepository
    {
       Task<DepartmentVM> GetById(int DepartmentId);
       IEnumerable<DepartmentVM> GetAll();
    }
}
