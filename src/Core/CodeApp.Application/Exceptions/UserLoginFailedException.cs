namespace CodeApp.Application.Exceptions
{
    public class UserLoginFailedException : Exception
    {
        public UserLoginFailedException()
        {
        }

        public UserLoginFailedException(string? message) : base(message)
        {
        }

        public UserLoginFailedException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
