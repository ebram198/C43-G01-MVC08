using IKEA.BLL.Models.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKEA.BLL.Services.Employees
{
    public interface IEmployeeService
    {

        IEnumerable<EmployeeDto> GetAllEmployees(string search );

        EmployeeDetailsDto? GetEmployeeById(int id);

        int CreateEmployee(CreatedEmployeeDto employeeDto);
        int updateEmployee(UpdatedEmployeeDto employeeDto02);

        bool DeleteEmployee(int id);




    }
}
