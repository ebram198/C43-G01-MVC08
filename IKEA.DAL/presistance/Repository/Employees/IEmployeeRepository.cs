using IKEA.DAL.Models.Employees;
using IKEA.DAL.presistance.Repository._Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKEA.DAL.presistance.Repository.Employees
{
    public interface IEmployeeRepository:IGenericRepository<Employee>
    {
        
    }
}
