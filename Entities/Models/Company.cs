using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class Company
    {
        [Column("CompanyId")]
        public Guid Id{ get; set; }

        [Required(ErrorMessage = "Company name is required field.")]
        [MaxLength(60, ErrorMessage = "Maximum langth for company name is 60 Characters.")]
        public string? Name{ get; set; }

        [Required(ErrorMessage = "Company address is required field.")]
        [MaxLength(60, ErrorMessage = "Maximum langth for company address is 60 Characters.")]
        public string? Address { get; set; }

        public string? Country { get; set; }

        public ICollection<Employee>? Employees { get; set; }
    }
}
