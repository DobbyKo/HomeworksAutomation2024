
namespace _4.CustomException
{
    public class InvalidAgeException : Exception
    {
        public static string ErrorMessage = "Age must be between 0 and 150.";

        public InvalidAgeException() : base(ErrorMessage) { }
    }
}
