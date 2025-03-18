using System.ComponentModel.DataAnnotations;

namespace IKEA.PL.Models.Departmrnt
{
    public class DepartmentEditViewModel
    {
        [Required(ErrorMessage ="The Code is Required!!")]
        public string Code { get; set; }=null!;

        public string Name { get; set; } = null!;

        public DateOnly CreationDate { get; set; }
    }
}
