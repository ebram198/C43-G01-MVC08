using IKEA.BLL.Models.Departments;
using IKEA.DAL.Models.Departments;
using IKEA.DAL.presistance.Repository.Departments;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKEA.BLL.Services
{
    public class DepartmentServices : IDepartmentServices
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentServices(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        int IDepartmentServices.CreatedDepartment(CreatedDepartmentDTO departmentDTO)
        {
            var Createdepartment = new Department
            {
                code = departmentDTO.code,
                Description = departmentDTO.Description,
                Name = departmentDTO.Name,
                CreationDate = departmentDTO.CreationDate,
                Createdby = 1,
                LastModificationBy=1,
                LastModificationOn=DateTime.UtcNow,
               // Createon=DateTime.UtcNow,

            };

            return _departmentRepository.Add(Createdepartment);

        }

        bool IDepartmentServices.DeleteDepartment(int id)
        {
            var department=_departmentRepository.GetbyID(id);
            if (department != null)
            {
               return _departmentRepository.Delete(department) >0;
            }
            return false;
        }

        IEnumerable<DepartmentToReturnDTO> IDepartmentServices.GetALLDepartment()
        {
           var Department=_departmentRepository.GetAllAsQueryable().Select(department=>new DepartmentToReturnDTO {
               //Manual Mapping
               Id = department.Id,
               Name = department.Name,
               code = department.code,

               Description = department.Description,
               CreationDate = department.CreationDate,

           }).AsTracking().ToList();
            return Department;
        }


        DepartmentDetailsReturnDTO? IDepartmentServices.GetDepartmentbyId(int id)
        {

            var department = _departmentRepository.GetbyID(id);
            if (department is not null)
            {
                return new DepartmentDetailsReturnDTO
                {
                    //Manual Mapping
                    Id = department.Id,
                    Name = department.Name,
                    code = department.code,
                    Description = department.Description,
                    CreationDate = department.CreationDate,
                    Createdby = department.Createdby,
                    Createon = department.Createon,
                    LastModificationBy = department.LastModificationBy,
                    LastModificationOn = department.LastModificationOn,
                    IsDeleted = department.IsDeleted,
                };
            }
            return null;


        }

        int IDepartmentServices.UpdateDepartment(UpdateDepartmentDTO departmentDTO)
        {
            var UpdateDepartment = new Department()
            {
                Id = departmentDTO.Id,
                Name = departmentDTO.Name,
                code = departmentDTO.code,
                Description = departmentDTO.Description,
                CreationDate = departmentDTO.CreationDate,
                LastModificationBy = 1,
                LastModificationOn=DateTime.UtcNow,
                
            };
             
            return _departmentRepository.Update(UpdateDepartment);

        }
    }
}
