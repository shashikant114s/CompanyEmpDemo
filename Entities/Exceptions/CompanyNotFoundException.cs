namespace Entities.Exceptions
{
    public sealed class CompanyNotFoundException : NotFoundException
    {
        public CompanyNotFoundException(Guid companyId) : base($"This company with id: '{companyId}' doen't find in the Database!!")
        { }
    }
}
