namespace MeFit.Data.Exceptions
{
    public class EntityNotFoundException : Exception
    {
        public EntityNotFoundException(string type, Guid id)
            : base($"{type} with Id: {id} could not be found.")
        {
        }
    }
}
