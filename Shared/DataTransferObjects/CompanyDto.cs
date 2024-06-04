using System.ComponentModel.DataAnnotations;

namespace Shared.DataTransferObjects
{
    public record CompanyDto
    {
        public Guid Id { get; init; }
        public string? Name { get; init; }
        public string? FullAddress { get; init; }
    }


    public record EmployeeDto(Guid Id, string Name, int Age, string Position);

    public record EmployeeForCreationDto : EmployeeForManipulationDto;
    public record EmployeeForUpdateDto : EmployeeForManipulationDto;

    public record CompanyForCreationDto 
    {
        [Required(ErrorMessage = "Company name is a required field.")]
        [MaxLength(30, ErrorMessage = "Maximun length for the Name is 50 characters.")]
        public string? Name { get; init; }

        [Required(ErrorMessage = "Address name is a required field.")]
        [MaxLength(60, ErrorMessage = "Maximun length for the Address is 60 characters.")]
        public string? Address { get; init; }

        [Required(ErrorMessage = "Address name is a required field.")]
        [MaxLength(20, ErrorMessage = "Maximun length for the Country is 20 characters.")]
        public string? Country { get; init; }
        public IEnumerable<EmployeeForCreationDto>? Employees { get; init; }
    }


    public record CompanyForUpdateDto(string Name, string Address, string Country, IEnumerable<EmployeeForCreationDto> Employees);


    public abstract record EmployeeForManipulationDto
    {
        [Required(ErrorMessage = "Employee name is a required field.")]
        [MaxLength(30, ErrorMessage = "Maximun length for the Name is 30 characters.")]
        public string? Name { get; init; }

        [Range(18, int.MaxValue, ErrorMessage = "Age is required and can't be lower than 18.")]
        public int Age { get; init; }

        [Required(ErrorMessage = "Position is required field.")]
        [MaxLength(20, ErrorMessage = "Maximum length for the Position is 20 characters.")]
        public string? Position { get; init; }
    }


}
