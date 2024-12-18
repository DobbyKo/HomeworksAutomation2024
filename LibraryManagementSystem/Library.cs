
using System.Linq;

namespace LibraryManagementSystem
{
    internal class Library : LibraryManagement
    {
        private List<Book> books = new List<Book>();

        public override void AddBook(Book book)
        {
            books.Add(book);
            Console.WriteLine($"Added book: '{book.Title}' by {book.Author}. ISBN: {book.ISBN}");
        }

        public override void RemoveBook(string isbn)
        {
            var bookToRemove = books.FirstOrDefault(b => b.ISBN == isbn);
            if (bookToRemove != null)
            {
                books.Remove(bookToRemove);
                Console.WriteLine($"Removed book: '{bookToRemove.Title}' from the library.");
            }
            else
            {
                Console.WriteLine($"Book with ISBN: {isbn} not found.");
            }
        }

        public override void BorrowBook(Member member, Book book)
        {
            member.BorrowBook(book);
        }

        public override void ReturnBook(Member member, Book book)
        {
            member.ReturnBook(book);
        }
    }
}
