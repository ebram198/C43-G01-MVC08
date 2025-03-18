using IKEA.BLL.Models.Departments;
using IKEA.BLL.Models.Employee;
using IKEA.DAL.Models.Employees;
using IKEA.DAL.presistance.Repository.Employees;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKEA.BLL.Services.Employees
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
           _employeeRepository = employeeRepository;
        }
       
        
        public int CreateEmployee(CreatedEmployeeDto employeeDto)
        {
           var Employee=new Employee() 
           {
               Name = employeeDto.Name,
               Age = employeeDto.Age,
               Address = employeeDto.Address,
               IsActive = employeeDto.IsActive,
               salary = employeeDto.Salary,
               Email = employeeDto.Email,
               PhoneNumber=employeeDto.Phone,
              HiringDate=employeeDto.HiringDate,
               Gender=employeeDto.Gender,
               EmployeeType=employeeDto.EmployeeType,
               DepartmentId=employeeDto.DepartmentId,
               Createdby=1,
               LastModificationBy=1,
               LastModificationOn= DateTime.UtcNow,

           };
            return _employeeRepository.Add(Employee);

           
        }

        public int updateEmployee(UpdatedEmployeeDto employeeDto)
        {
            var employee = new Employee()
            {

                Id = employeeDto.Id,  
                Name = employeeDto.Name,
                Age = employeeDto.Age,
                Address = employeeDto.Address,
                IsActive = employeeDto.IsActive,
                salary=employeeDto.Salary,
                Email = employeeDto.Email,
                PhoneNumber = employeeDto.Phone,
                HiringDate = employeeDto.HiringDate,
                Gender = employeeDto.Gender,
                EmployeeType = employeeDto.EmployeeType,
                DepartmentId = employeeDto.DepartmentId,
                Createdby = 1,
                LastModificationBy = 1,
                LastModificationOn = DateTime.UtcNow,
                
            };
            return _employeeRepository.Update(employee);
        }

        public bool DeleteEmployee(int id)
        {
            var employee=_employeeRepository.GetbyID(id);
            if (employee is { })
            {
                return _employeeRepository.Delete(employee) > 0;  
             }
            return false;
        }

        public IEnumerable<EmployeeDto> GetAllEmployees()
        {
          return _employeeRepository.GetAllAsQueryable()
                .Where(E=>!E.IsDeleted)
                .Include(E=>E.Department)
                .Select(employee=> new EmployeeDto 
          {
              Id = employee.Id,
              Name = employee.Name,
              Age = employee.Age,
              Salary=employee.salary,
              Email=employee.Email,              
              ISActive=employee.IsActive,
              Gender= employee.Gender.ToString(),
              EmployeeType =employee.EmployeeType.ToString(),
                    Department = employee.Department != null ? employee.Department.Name : "No Department"

                });
        }

        public EmployeeDetailsDto? GetEmployeeById(int id)
        {
            var employee=_employeeRepository.GetbyID(id);
            if (employee is { })
                return new EmployeeDetailsDto()
                {
                    Id = employee.Id,
                    Name = employee.Name,
                    Age = employee.Age,
                    Address = employee.Address,
                    ISActive = employee.IsActive,
                    Salary = employee.salary,
                    Email = employee.Email,
                    Phone = employee.PhoneNumber,
                    HiringDate = employee.HiringDate,
                    Gender=employee.Gender, 
                    EmployeeType=employee.EmployeeType,
                    

                };
            return null;
        }


       
    }
}
