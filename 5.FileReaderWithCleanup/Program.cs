using System.Net.Mail;
using _5.FileReaderWithCleanup;

public class Program
{
    static void Main()
    {
        string projectDir = Directory.GetCurrentDirectory();
        string filePath = Path.Combine(projectDir, "Resources", "testfile.txt");

        string directory = Path.GetDirectoryName(filePath);
        if (!Directory.Exists(directory))
        {
            Directory.CreateDirectory(directory);
        }

        if (!File.Exists(filePath))
        {
            try
            {
                File.WriteAllText(filePath, "This is a sample content in the project file.");
                Console.WriteLine($"Mock file created at {filePath}.");
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Error creating test file: {ex.Message}");
            }
        }

        FileReader.TestFileReading();
    }
}