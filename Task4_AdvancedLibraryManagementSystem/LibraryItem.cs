
namespace Task4_AdvancedLibraryManagementSystem
{
    public abstract class LibraryItem : IBorrowable
    {
        public string Title { get; set; }
        public bool IsBorrowed { get; set; }
        public string Borrower { get; set; }
        public DateTime DueDate { get; set; }

        public void CheckStatus()
        {
            if (IsBorrowed)
            {
                Console.WriteLine($"Title: {Title}, Borrowed by {Borrower}, Due on {DueDate}");
            }
            else
            {
                Console.WriteLine($"Title: {Title}, Available for borrowing.");
            }
        }

        public void ExtendDueDate(int days)
        {
            if (IsBorrowed)
            {
                DueDate.AddDays(days);
            }
            else
            {
                Console.WriteLine($"Cannot extend due date for '{Title}' because it is not borrowed.");
            }
        }

        public abstract void Borrow(string borrower, DateTime dueDate);
        public abstract void Return();
    }
}
