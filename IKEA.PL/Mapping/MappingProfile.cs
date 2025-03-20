using AutoMapper;
using IKEA.BLL.Models.Departments;
using IKEA.PL.Models.Departmrnt;

namespace IKEA.PL.Mapping
{
    public class MappingProfile:Profile
    {
        public MappingProfile() 
        {
            #region Department
             CreateMap<DepartmentDetailsReturnDTO,DepartmentEditViewModel>();

            CreateMap<DepartmentEditViewModel, UpdateDepartmentDTO>();

            #endregion
        }

 
    }
}
