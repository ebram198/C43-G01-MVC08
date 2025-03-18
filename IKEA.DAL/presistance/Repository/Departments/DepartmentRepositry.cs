using IKEA.DAL.Models.Departments;
using IKEA.DAL.presistance.Data;
using IKEA.DAL.presistance.Repository._Generic;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKEA.DAL.presistance.Repository.Departments
{
    public class DepartmentRepositry :GenericRepository<Department> ,IDepartmentRepository
    {
        public DepartmentRepositry(ApplicationDbContext context) : base(context) 
        {
            // Ask CLR For Object From ApplicationContext Implicitly

        }


    }
}
