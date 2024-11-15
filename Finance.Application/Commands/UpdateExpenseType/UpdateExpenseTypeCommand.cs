using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Application.Commands.UpdateExpenseType
{
    public class UpdateExpenseTypeCommand
    {
        public int IdExpenseType { get; set; }
        public string Name { get; set; }
        public int IdExpenseCategory { get; set; }
    }
}
