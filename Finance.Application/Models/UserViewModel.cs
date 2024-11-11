using Finance.Core.Entities;

namespace Finance.Application.Models
{
    public class UserViewModel
    {
        public UserViewModel(string name, List<string> incomes, List<string> expenses)
        {
            Name = name;
            Incomes = incomes;
            Expenses = expenses;
        }

        public string Name { get; private set; }
        public List<string> Incomes { get; private set; }
        public List<string> Expenses { get; private set; }

        public static UserViewModel FromEntity(User user)
        {
            var incomes = user.Incomes.Select(u => u.Description).ToList();

            var expenses = user.Expenses.Select(u => u.Description).ToList();

            return new UserViewModel(user.Name, incomes, expenses);
        }
    }
}
