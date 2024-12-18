
namespace LibraryManagementSystem
{
    public class Book
    {
        private int copies;

        public Book(string title, string author, string isbn, int availableCopies)
        {
            Title = title;
            Author = author;
            ISBN = isbn;
            AvailableCopies = availableCopies;
        }

        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public int AvailableCopies
        {
            get { return copies; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "Value cannot be negative.");
                }
                copies = value;
            }
        }

        public bool BorrowBook()
        {
            if (AvailableCopies > 0)
            {
                AvailableCopies--;
                return true;
            }
            return false;
        }

        public void ReturnBook()
        {
            AvailableCopies++;
        }
    }
}
