using Finance.Core.Entities;

namespace Finance.Application.Models
{
    public class UserViewModel
    {
        public UserViewModel(int idUser,string name, bool isDeleted, List<string> incomes, List<string> expenses)
        {
            IdUser = idUser;
            Name = name;
            IsDeleted = isDeleted;
            Incomes = incomes;
            Expenses = expenses;
        }

        public int IdUser { get; private set; }
        public string Name { get; private set; }
        public bool IsDeleted { get; private set; }
        public List<string> Incomes { get; private set; }
        public List<string> Expenses { get; private set; }

        public static UserViewModel FromEntity(User user)
        {
            var incomes = user.Incomes.Select(u => u.Description).ToList();

            var expenses = user.Expenses.Select(u => u.Description).ToList();

            return new UserViewModel(user.Id,user.Name, user.IsDeleted,incomes, expenses);
        }
    }
}
