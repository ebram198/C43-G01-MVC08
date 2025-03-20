using IKEA.BLL.Models.Departments;
using IKEA.DAL.Models.Departments;
using IKEA.DAL.presistance.Repository.Departments;
using IKEA.DAL.presistance.UniteOfWork;
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
        private readonly IUnitOfWork _unitOfWork;

        public DepartmentServices(IUnitOfWork unitOfWork)
        {
           _unitOfWork = unitOfWork;
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

           _unitOfWork.DepartmentRepository.Add(Createdepartment);
            return _unitOfWork.Complete();

        }

        bool IDepartmentServices.DeleteDepartment(int id)
        {
            var department= _unitOfWork.DepartmentRepository.GetbyID(id);
            if (department != null)
            {
                _unitOfWork.DepartmentRepository.Delete(department) ;
            }
            return _unitOfWork.Complete()>0;
        }

        IEnumerable<DepartmentToReturnDTO> IDepartmentServices.GetALLDepartment()
        {
           var Department= _unitOfWork.DepartmentRepository.GetAllAsQueryable().Select(department=>new DepartmentToReturnDTO {
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

            var department = _unitOfWork.DepartmentRepository.GetbyID(id);
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
             
             _unitOfWork.DepartmentRepository.Update(UpdateDepartment);

            return _unitOfWork.Complete();


        }
    }
}
