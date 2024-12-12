
namespace Task4_AdvancedLibraryManagementSystem
{
    public interface IBorrowable
    {
        public void Borrow(string borrower, DateTime dueDate);

        public void Return();
    }
}
