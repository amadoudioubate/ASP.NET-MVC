using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace _04_TagHelpers.Models
{
    public class Employe
    {
        public int Id { get; set; }

        [Display(Name ="Nom")]
        public string Name { get; set; } = string.Empty;

        [DisplayName("Salaire")]
        public double Salary { get; set; }

        [Display(Name = "Actif ?")]
        public bool IsActif { get; set; }

        
        public string Email { get; set; }

        public EmployeType Type { get; set; } = EmployeType.DEBUTANT;

        [Display(Name = "Département")]
        public int DepartmentId { get; set; }
    }

    public enum EmployeType
    {
        DEBUTANT = 1,
        JUNIOR = 2,
        SENIOR = 3
    }
}
