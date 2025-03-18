using IKEA.DAL.Models.Departments;
using IKEA.DAL.Models.Employees;
using IKEA.DAL.presistance.Data;
using IKEA.DAL.presistance.Repository._Generic;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKEA.DAL.presistance.Repository.Employees
{
    public class EmployeeReposatory : GenericRepository<Employee> ,IEmployeeRepository
    {
        public EmployeeReposatory(ApplicationDbContext context) : base(context) 
        {

        }
    }
}
