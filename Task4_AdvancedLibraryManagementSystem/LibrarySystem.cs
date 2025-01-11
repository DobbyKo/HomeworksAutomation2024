
namespace Task4_AdvancedLibraryManagementSystem
{
    public class LibrarySystem
    {
        private List<LibraryItem> items;
        private Dictionary<string, int> borrowerItemCount;

        public LibrarySystem()
        {
            items = new List<LibraryItem>();
            borrowerItemCount = new Dictionary<string, int>();
        }

        public void AddItem(LibraryItem item)
        {
            items.Add(item);
        }

        public void BorrowItem(string borrower, string title)
        {
            if (borrowerItemCount.ContainsKey(borrower) && borrowerItemCount[borrower] >= 3)
            {
                Console.WriteLine($"{borrower} has exceeded the borrowing limit of 3 items.");
                return;
            }

            var item = items.FirstOrDefault(i => i.Title.Equals(title, StringComparison.OrdinalIgnoreCase) && !i.IsBorrowed);
            if (item != null)
            {
                DateTime dueDate = DateTime.Now.AddDays(14);
                item.Borrow(borrower, dueDate);

                if (borrowerItemCount.ContainsKey(borrower))
                {
                    borrowerItemCount[borrower]++;
                }
                else
                {
                    borrowerItemCount[borrower] = 1;
                }
            }
            else
            {
                Console.WriteLine($"'{title}' is either not available or already borrowed.");
            }
        }

        public void ReturnItem(string borrower, string title)
        {
            var item = items.FirstOrDefault(i => i.Title.Equals(title, StringComparison.OrdinalIgnoreCase) && i.Borrower == borrower);
            if (item != null)
            {
                item.Return();
                borrowerItemCount[borrower]--;
            }
            else
            {
                Console.WriteLine($"{borrower} has not borrowed '{title}'.");
            }
        }

        public void ShowLibraryStatus()
        {
            Console.WriteLine("\nLibrary Status:");
            foreach (var item in items)
            {
                item.CheckStatus();
            }
        }
    }

}
