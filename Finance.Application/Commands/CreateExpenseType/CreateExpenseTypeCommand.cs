﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Application.Commands.CreateExpenseType
{
    public class CreateExpenseTypeCommand
    {
        public string Name { get; set; }
        public int IdExpenseCategory { get; set; }
    }
}
