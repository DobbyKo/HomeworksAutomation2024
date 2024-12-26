
namespace LibraryManagementSystem
{
    internal class StudentMember : Member
    {
        public StudentMember(string name, string memberId)
         : base(name, memberId, "Student")
        {
            BorrowLimit = 5;
        }
    }
}
