using IKEA.BLL.Models.Departments;
using IKEA.DAL.Models.Departments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKEA.BLL.Services
{
    public interface IDepartmentServices
    {
        IEnumerable<DepartmentToReturnDTO> GetALLDepartment();
        DepartmentDetailsReturnDTO? GetDepartmentbyId(int id);

        public int CreatedDepartment(CreatedDepartmentDTO departmentDTO);

        public int UpdateDepartment(UpdateDepartmentDTO departmentDTO);
        bool DeleteDepartment(int id);

    }
}
