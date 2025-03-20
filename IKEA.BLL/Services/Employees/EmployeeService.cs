using IKEA.BLL.Models.Departments;
using IKEA.BLL.Models.Employee;
using IKEA.DAL.Models.Employees;
using IKEA.DAL.presistance.Repository.Employees;
using IKEA.DAL.presistance.UniteOfWork;
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
        private readonly IUnitOfWork _unitOfWork;

        public EmployeeService(IUnitOfWork unitOfWork)
        {
            // Ask Clr For Creating Object From Class Implementing IUinteof work
            _unitOfWork = unitOfWork;
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
             _unitOfWork.EmployeeRepository.Add(Employee);

            return _unitOfWork.Complete();
           
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
            _unitOfWork.EmployeeRepository.Update(employee);

            return _unitOfWork.Complete();

        }

        public bool DeleteEmployee(int id)
        {
            var employee=_unitOfWork.EmployeeRepository.GetbyID(id);
            if (employee is { })
            {
                 _unitOfWork.EmployeeRepository.Delete(employee) ;  

             }

            return _unitOfWork.Complete()>0;
        }

        public IEnumerable<EmployeeDto> GetAllEmployees(string search)
        {
            return _unitOfWork.EmployeeRepository.GetAllAsQueryable()
                  .Where(E => !E.IsDeleted && (string.IsNullOrEmpty(search) || E.Name.ToLower().Contains(search.ToLower())))
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
            var employee= _unitOfWork.EmployeeRepository.GetbyID(id);
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
