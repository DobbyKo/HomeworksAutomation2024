
using Task1_BuildTheSystem.Interfaces;

namespace Task1_BuildTheSystem.Models
{
    public class ConsoleLogger : ILogger
    {
        public void log(string message)
        {
            Console.WriteLine($"[LOG] {message}");
        }
    }
}
