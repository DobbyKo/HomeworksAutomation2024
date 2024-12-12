
namespace Task4_AdvancedLibraryManagementSystem
{
    public class Program
    {
        static void Main()
        {
            List<LibraryItem> items = new List<LibraryItem>
            {
                new Book { Title = "Harry Potter", Author = "J.K. Rowling" },
                new Book { Title = "Percy Jackson & The Olympians", Author = "Rick Riordan" },
                new Book { Title = "Moby Dick", Author = "Herman Melville" },
                new Magazine { Title = "National Geographic", IssueNumber = 101 },
                new Magazine { Title = "Vogue", IssueNumber = 202 },
                new Magazine { Title = "Elle", IssueNumber = 303 }
            };

            Dictionary<string, int> borrowerItemCount = new Dictionary<string, int>();

            void BorrowItem(string borrower, string title)
            {
                if (borrowerItemCount.ContainsKey(borrower) && borrowerItemCount[borrower] >= 3)
                {
                    Console.WriteLine($"{borrower} has exceeded the borrowing limit of 3 items.");
                    return;
                }

                var item = items.FirstOrDefault(i => i.Title == title && !i.IsBorrowed);
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

            void ReturnItem(string borrower, string title)
            {
                var item = items.FirstOrDefault(i => i.Title == title && i.Borrower == borrower);
                if (item != null)
                {
                    item.Return();
                    borrowerItemCount[borrower]--;
                }
                else
                {
                    Console.WriteLine($"{borrower} did not borrow '{title}'.");
                }
            }

            void ShowLibraryStatus()
            {
                Console.WriteLine("\nLibrary Status:");
                foreach (var item in items)
                {
                    item.CheckStatus();
                }
            }

            BorrowItem("Dobby", "Percy Jackson & The Olympians");
            BorrowItem("Dobby", "Harry Potter");
            BorrowItem("Dobby", "Moby Dick"); 
            BorrowItem("Dobby", "National Geographic"); 

            ReturnItem("Dobby", "Harry Potter");

            ShowLibraryStatus();

            BorrowItem("Dobby", "National Geographic"); 

            ShowLibraryStatus();
        }
    }
}
