
namespace _5.FileReaderWithCleanup
{
    public class FileReader
    {
        public static void ReadFile(string filePath)
        {
            FileStream fileStream = null;

            try
            {
                if (!File.Exists(filePath))
                {
                    Console.WriteLine("Error: The file does not exist.");
                    return;
                }

                fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                Console.WriteLine("File opened successfully.");

                using (StreamReader reader = new StreamReader(fileStream))
                {
                    string content = reader.ReadToEnd();
                    Console.WriteLine("File content:\n" + content);
                }
            }
            catch (FileNotFoundException fnfEx)
            {
                Console.WriteLine($"Error: File not found. {fnfEx.Message}");
            }
            catch (UnauthorizedAccessException uaEx)
            {
                Console.WriteLine($"Error: Access to the file is denied. {uaEx.Message}");
            }
            catch (IOException ioEx)
            {
                Console.WriteLine($"Error: An I/O exception occurred. {ioEx.Message}");
            }
            finally
            {
                if (fileStream != null)
                {
                    fileStream.Close();
                    Console.WriteLine("File stream closed.");
                }
            }
        }

        public static void TestFileReading()
        {
            Console.Write("Please enter the file path to test: ");
            string filePath = Console.ReadLine();

            ReadFile(filePath);
        }
    }
}
