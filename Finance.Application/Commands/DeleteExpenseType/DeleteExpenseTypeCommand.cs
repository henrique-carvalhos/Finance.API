using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Application.Commands.DeleteExpenseType
{
    public class DeleteExpenseTypeCommand
    {
        public DeleteExpenseTypeCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
