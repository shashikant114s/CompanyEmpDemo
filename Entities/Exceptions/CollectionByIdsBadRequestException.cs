namespace Entities.Exceptions
{
    public sealed class CollectionByIdsBadRequestException : BadRequestException
    {
        public CollectionByIdsBadRequestException() : base("Collection count is mismatch comparing to ids")
        {
            
        }
    }
}
