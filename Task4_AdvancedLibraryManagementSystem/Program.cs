
namespace Task4_AdvancedLibraryManagementSystem
{
    public class Program
    {
        static void Main()
        { 
            LibrarySystem librarySystem = new LibrarySystem();

            librarySystem.AddItem(new Book("Harry Potter", "J.K. Rowling"));
            librarySystem.AddItem(new Book("Percy Jackson & The Olympians", "Rick Riordan"));
            librarySystem.AddItem(new Book("Moby Dick", "Herman Melville"));
            librarySystem.AddItem(new Magazine("National Geographic", 101));
            librarySystem.AddItem(new Magazine("Vogue", 202));
            librarySystem.AddItem(new Magazine("Elle", 303));

            librarySystem.BorrowItem("Dobby", "Percy Jackson & The Olympians");
            librarySystem.BorrowItem("Dobby", "Harry Potter");
            librarySystem.BorrowItem("Dobby", "Moby Dick");
            librarySystem.BorrowItem("Dobby", "National Geographic");

            librarySystem.ReturnItem("Dobby", "Harry Potter");

            librarySystem.ShowLibraryStatus();

            librarySystem.BorrowItem("Dobby", "National Geographic");

            librarySystem.ShowLibraryStatus();
        }
    }

}
