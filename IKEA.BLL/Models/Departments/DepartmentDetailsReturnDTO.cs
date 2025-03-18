using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKEA.BLL.Models.Departments
{
    public class DepartmentDetailsReturnDTO
    {

        public int Id { get; set; }


        public int Createdby { get; set; }

        public DateTime Createon { get; set; }

        public int LastModificationBy { get; set; }
        public DateTime LastModificationOn { get; set; }

        public bool IsDeleted { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }


        public string code { get; set; } = null!;
        [Display(Name = "Creation Date")]
        public DateOnly CreationDate { get; set; }

     
    }
}
