namespace Shared.DataTransferObjects
{
    public record CompanyDto
    {
        public Guid Id { get; init; }
        public string? Name { get; init; }
        public string? FullAddress { get; init; }
    }


    public record EmployeeDto(Guid Id, string Name, int Age, string Position);
    //public record CompanyForCreationDto(string Name, string Address, string Country);
    public record EmployeeForCreationDto(string Name, int Age, string Position);
    public record CompanyForCreationDto(string Name, string Address, string Country, IEnumerable<EmployeeForCreationDto> Employees);
    public record EmployeeForUpdateDto(string Name, int Age, string Position);
    public record CompanyForUpdateDto(string Name, string Address, string Country, IEnumerable<EmployeeForCreationDto> Employees);
}
