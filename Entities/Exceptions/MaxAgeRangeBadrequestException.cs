namespace Entities.Exceptions
{
    public sealed class MaxAgeRangeBadrequestException : BadRequestException
    {
        public MaxAgeRangeBadrequestException() : base($"Max age can't be less than min age.")
        {
        }
    }
}
