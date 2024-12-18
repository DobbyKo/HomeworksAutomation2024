
namespace LibraryManagementSystem
{
    internal abstract class LibraryManagement
    {
        public abstract void AddBook(Book book);
        public abstract void RemoveBook(string isbn);
        public abstract void BorrowBook(Member member, Book book);
        public abstract void ReturnBook(Member member, Book book);
    }
}
