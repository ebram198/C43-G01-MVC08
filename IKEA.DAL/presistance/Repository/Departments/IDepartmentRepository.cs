using IKEA.DAL.Models.Departments;
using IKEA.DAL.presistance.Repository._Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKEA.DAL.presistance.Repository.Departments
{
    public interface IDepartmentRepository:IGenericRepository<Department>
    {
      
    }
}
