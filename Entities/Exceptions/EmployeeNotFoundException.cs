namespace Entities.Exceptions
{
    public sealed class EmployeeNotFoundException : NotFoundException
    {
        public EmployeeNotFoundException(Guid empId) : base($"Employee with Id: '{empId}' doesn't exist in the databse.")
        { }
    }
}
