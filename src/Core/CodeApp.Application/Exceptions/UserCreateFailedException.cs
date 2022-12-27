namespace CodeApp.Application.Exceptions
{
    public class UserCreateFailedException : Exception
    {
        public UserCreateFailedException()
        {
        }

        public UserCreateFailedException(string? message) : base(message)
        {
        }
    }
}
