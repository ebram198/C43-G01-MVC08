using IKEA.DAL.presistance.Data;
using IKEA.DAL.presistance.Repository.Departments;
using IKEA.DAL.presistance.Repository.Employees;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKEA.DAL.presistance.UniteOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _dbContext;

        public IEmployeeRepository EmployeeRepository
        {
            get
            {
               return  new EmployeeReposatory(_dbContext);
            }
        }
        public IDepartmentRepository DepartmentRepository
        { 
          get  
            {
                return new DepartmentRepositry(_dbContext);
            }
        }
        public UnitOfWork(ApplicationDbContext dbContext)
        {
            //Ask Clr For Creating Object From ApplicationDbcontext Implicicty 

            _dbContext = dbContext;
        }
        public int Complete()
        {
           return _dbContext.SaveChanges(); 

        }

        public void Dispose()
        {
     
            _dbContext.Dispose();
        }

    }
}
