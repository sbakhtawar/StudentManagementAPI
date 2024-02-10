using vpsAPI.IRepositories;
using vpsAPI.Models;
using vpsAPI.Models.ViewModels;
using vpsAPI.Services;
namespace vpsAPI.SQLRepositories
{
    public class GroupsRepository : IGroupsRepository
    {
        private readonly VPSContext _dbContext;
        public GroupsRepository(VPSContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Groups Create(Groups group)
        {
             _dbContext.Groups.Add(group);
             _dbContext.SaveChanges();
             return group;
        }

        public Groups Delete(int Id)
        {
            Groups groupInfo = _dbContext.Groups.Find(Id);
            if (groupInfo != null)
            {
                _dbContext.Groups.Remove(groupInfo);
                _dbContext.SaveChanges();
            }
            return groupInfo;
        }

        public async Task<Groups> Edit(Groups groupChanges)
        {
            
            var GroupInfo = await _dbContext.Groups.FindAsync(groupChanges.GroupId);
            groupChanges.DepartmentId = GroupInfo.DepartmentId;
            groupChanges.CreatedDate = GroupInfo.CreatedDate;
            groupChanges.CreatedBy = GroupInfo.CreatedBy;
            _dbContext.ChangeTracker.Clear();
            var group=  _dbContext.Groups.Update(groupChanges);
            //group.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return groupChanges;

        }

        public IEnumerable<GroupsVM> GetAll()
        {
            
            var groups = (
                from g in _dbContext.Groups
                join s in _dbContext.Students
                on g.GroupId equals s.GroupId into tblgs
                from gs in tblgs.DefaultIfEmpty()
                join d in _dbContext.Department
                on g.DepartmentId equals d.DepartmentID
                group new { gs,d } by new
                {
                    g.GroupId,
                    g.GroupName,
                    g.GroupDescription,
                    d.DepartmentName
                }
                into grow
                select new GroupsVM
                {
                    GroupId=grow.Key.GroupId,
                    GroupName=grow.Key.GroupName,
                    GroupDescription=grow.Key.GroupDescription,
                    DepartmentName=grow.Key.DepartmentName,
                    AvgPerformance= grow.Average(x => x.gs.AcademicPerformance) != null ? 
                                        grow.Average(x => x.gs.AcademicPerformance) : 0.0
                }).ToList();
            return groups;
        }

        public async Task<GroupsVM> GetById(int Id)
        {
            var group = (
                from g in _dbContext.Groups
                join s in _dbContext.Students
                on g.GroupId equals s.GroupId into tblgs
                from gs in tblgs.DefaultIfEmpty()
                join d in _dbContext.Department
                on g.DepartmentId equals d.DepartmentID
                where g.GroupId == Id
                group new { gs, d } by new
                {
                    g.GroupId,
                    g.GroupName,
                    g.GroupDescription,
                    d.DepartmentName
                }
                into grow
                select new GroupsVM
                {
                    GroupId = grow.Key.GroupId,
                    GroupName = grow.Key.GroupName,
                    GroupDescription = grow.Key.GroupDescription,
                    DepartmentName = grow.Key.DepartmentName,
                    AvgPerformance = grow.Average(x => x.gs.AcademicPerformance) != null ?
                                        grow.Average(x => x.gs.AcademicPerformance) : 0.0
                }).FirstOrDefault();
            return group;
        }
    }
}
