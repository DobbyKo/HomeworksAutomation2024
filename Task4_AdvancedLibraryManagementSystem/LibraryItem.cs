namespace Task4_AdvancedLibraryManagementSystem
{
    public abstract class LibraryItem : IBorrowable
    {
        protected LibraryItem(string title)
        {
            Title = title;
            IsBorrowed = false;
            Borrower = string.Empty;
            DueDate = DateTime.MinValue; 
        }

        public string Title { get; private set; }
        public bool IsBorrowed { get; protected set; }
        public string Borrower { get; protected set; }
        public DateTime DueDate { get; protected set; }

        public void CheckStatus()
        {
            if (IsBorrowed)
            {
                Console.WriteLine($"Title: {Title}, Borrowed by {Borrower}, Due on {DueDate.ToShortDateString()}");
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
                DueDate = DueDate.AddDays(days);
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
