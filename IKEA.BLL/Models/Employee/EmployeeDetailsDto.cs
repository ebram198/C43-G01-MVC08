using IKEA.DAL.common.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKEA.BLL.Models.Employee
{
    public class EmployeeDetailsDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public int? Age { get; set; }

        public string? Address { get; set; }

        [DataType(DataType.Currency)]
        public decimal? Salary { get; set; }
        [Display(Name = "Is Active")]
        public bool ISActive { get; set; }

        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string? Phone { get; set; }

        public DateTime HiringDate { get; set; }
        public Gender Gender { get; set; }
        public EmployeeType EmployeeType { get; set; }

        public string? DepartmentId { get; set; }

        #region Adminstration
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }

        public int lastModifiedBy { get; set; }
        public DateTime LastModifiedOn { get; set; }

        #endregion
    }
}
