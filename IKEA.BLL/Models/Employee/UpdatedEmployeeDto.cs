﻿using IKEA.DAL.common.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKEA.BLL.Models.Employee
{
    public class UpdatedEmployeeDto
    {
        public int Id { get; set; }
        //[Required]
        [MaxLength(50, ErrorMessage = "Max Length of Name Is 50 Chars")]
        [MinLength(5, ErrorMessage = "Min Length of Name Is 5 Chars")]

        public string Name { get; set; } = null!;

        [Range(22, 30)]

        public int? Age { get; set; }

        [RegularExpression(@"^[0-9]{1,3}-[a-zA-Z]{5,10}-[a-zA-Z]{4,10}-[a-zA-Z]{5,10}]$", ErrorMessage = "Address Must Be Like 123-Street-City-country")]

        public string? Address { get; set; }
        public decimal? Salary { get; set; }

        [Display(Name = "Is Active")]
        public bool IsActive { get; set; }
        [EmailAddress]
        public string? Email { get; set; }
        [Display(Name = "Phone Number")]
        [Phone]
        public string? Phone { get; set; }

        [Display(Name = "Hiring Date")]

        public DateTime HiringDate { get; set; }

        public Gender Gender { get; set; }

        public EmployeeType EmployeeType { get; set; }
   
    public int? DepartmentId { get; set; }
    
    
    
    }
}
