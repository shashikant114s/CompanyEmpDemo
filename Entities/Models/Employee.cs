using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class Employee
    {
        [Column("EmployeeId")]
        public  Guid Id { get; set; }

        [Required(ErrorMessage = "Employee name is required.")]
        [MaxLength(30, ErrorMessage = "Maximum length for emplyee name is 30 charaters.")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Age is a required field.")]
        public int Age{ get; set; }

        [Required(ErrorMessage = "Employee position is required.")]
        [MaxLength(30, ErrorMessage = "Maximum length for emplyee position is 30 charaters.")]
        public string? Position { get; set; }

        [ForeignKey(nameof(Company))]
        public Guid CompanyId { get; set; }
        public Company? Company { get; set; }
    }
}
