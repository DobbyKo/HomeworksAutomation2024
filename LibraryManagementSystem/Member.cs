
namespace LibraryManagementSystem
{
    public abstract class Member
    {
        public string Name { get; set; }
        public string MemberID { get; set; }
        public string MembershipType { get; set; }
        public int BorrowLimit { get; protected set; }
        public int BorrowedBooksCount { get; protected set; }

        public Member(string name, string memberId, string membershipType)
        {
            Name = name;
            MemberID = memberId;
            MembershipType = membershipType;
            BorrowedBooksCount = 0;
        }

        public bool CanBorrow()
        {
            return BorrowedBooksCount < BorrowLimit;
        }

        public void BorrowBook(Book book)
        {
            if (CanBorrow() && book.BorrowBook())
            {
                BorrowedBooksCount++;
                Console.WriteLine($"{Name} borrowed '{book.Title}' successfully.");
            }
            else
            {
                Console.WriteLine($"{Name} cannot borrow '{book.Title}'. " +
                                  (CanBorrow() ? "No copies available." : "Borrowing limit reached."));
            }
        }

        public void ReturnBook(Book book)
        {
            if (BorrowedBooksCount > 0)
            {
                book.ReturnBook();
                BorrowedBooksCount--;
                Console.WriteLine($"{Name} returned '{book.Title}'.");
            }
            else
            {
                Console.WriteLine($"{Name} has no books to return.");
            }
        }
    }
}
