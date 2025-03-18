using IKEA.DAL.common.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IKEA.BLL.Models.Departments;

namespace IKEA.BLL.Models.Employee
{
    public class EmployeeDto
    {//to Get All Employees
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public int? Age { get; set; }
    
        [DataType(DataType.Currency)]
        public decimal? Salary { get; set; }
        [Display(Name="Is Active")]
        public bool ISActive { get; set; }

        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string? Phone { get; set; }
        public string Gender { get; set; } 
        public string EmployeeType { get; set; }

        public string? Department { get; set; }
        #region Adminstration
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }

        public int lastModifiedBy { get; set; }
        public DateTime LastModifiedOn { get; set; }

        #endregion
    }
}
