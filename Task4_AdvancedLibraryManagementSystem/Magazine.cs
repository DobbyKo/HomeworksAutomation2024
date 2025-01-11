namespace Task4_AdvancedLibraryManagementSystem
{
    public class Magazine : LibraryItem
    {
        public int IssueNumber { get; set; }

        public Magazine(string title, int issueNumber) : base(title)
        {
            IssueNumber = issueNumber;
        }

        public override void Borrow(string borrower, DateTime dueDate)
        {
            if (IsBorrowed)
            {
                Console.WriteLine($"'{Title}' is already borrowed.");
                return;
            }
            IsBorrowed = true;
            Borrower = borrower;
            DueDate = dueDate;
            Console.WriteLine($"Magazine '{Title}' (Issue {IssueNumber}) borrowed by {Borrower}, due on {DueDate.ToShortDateString()}.");
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
