
namespace LibraryManagementSystem
{
    internal class StaffMember : Member
    {
        public StaffMember (string name, string memberId)
        : base(name, memberId, "Staff")
        {
            BorrowLimit = 10;
        }
    }
}
