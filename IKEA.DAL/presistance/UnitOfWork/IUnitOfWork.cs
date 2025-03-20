using IKEA.DAL.presistance.Data;
using IKEA.DAL.presistance.Repository.Departments;
using IKEA.DAL.presistance.Repository.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKEA.DAL.presistance.UniteOfWork
{
    public interface IUnitOfWork:IDisposable
    {

        public IEmployeeRepository EmployeeRepository { get;  }
         
        public IDepartmentRepository DepartmentRepository { get;  }

    

        int Complete();



    }
}
