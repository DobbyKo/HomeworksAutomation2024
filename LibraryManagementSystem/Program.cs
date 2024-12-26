namespace LibraryManagementSystem
{
    public class Program
    {
        static void Main()
        {
            var library = new Library();

            var book1 = new Book("C# in Depth", "Jon Skeet", "9781617294532", 3);
            var book2 = new Book("Clean Code", "Robert C. Martin", "9780132350884", 2);
            library.AddBook(book1);
            library.AddBook(book2);

            var alice = new StudentMember("Alice", "S001");
            var bob = new StaffMember("Bob", "T001");

            library.BorrowBook(alice, book1); 
            library.BorrowBook(alice, book2); 

            library.BorrowBook(bob, book2);

            library.BorrowBook(alice, book2); 

            library.ReturnBook(alice, book1); 
            library.ReturnBook(bob, book2);   

            library.RemoveBook("9781617294532"); 
        }
    }
}