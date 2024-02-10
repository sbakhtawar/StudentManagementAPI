using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IRepositories
{
    public interface IDepartmentRepository
    {
        Department GetById(int DepartmentID);
        IEnumerable<Department> GetAll();
    }
}
