using vpsAPI.Models;
using vpsAPI.Models.ViewModels;
namespace vpsAPI.IRepositories
{
    public interface IGroupsRepository
    {
        Task<GroupsVM> GetById(int Id);
        IEnumerable<GroupsVM> GetAll();
        Groups Create(Groups group);
        Task<Groups> Edit(Groups groupChanges);
        Groups Delete(int Id);
    }
}
