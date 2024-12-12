


namespace Task4_AdvancedLibraryManagementSystem
{
    public class Book : LibraryItem
    {
        public string Author { get; set; }

        public override void Borrow(string borrower, DateTime dueDate)
        {
            if(IsBorrowed)
        {
                Console.WriteLine($"'{Title}' is already borrowed.");
                return;
            }

            IsBorrowed = true;
            Borrower = borrower;
            DueDate = dueDate;

            Console.WriteLine($"Book '{Title}' by {Author} borrowed by {Borrower}, due on {DueDate.ToShortDateString()}.");
        }

        public override void Return()
        {
            if (!IsBorrowed)
            {
                Console.WriteLine($"'{Title}' was not borrowed.");
                return;
            }

            IsBorrowed = false;
            Borrower = string.Empty;
            DueDate = DateTime.MinValue;

            Console.WriteLine($"'{Title}' has been returned.");
        }
    }
}
