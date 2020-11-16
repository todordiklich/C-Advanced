﻿using P03.Detail_Printer;
using System.Collections.Generic;

namespace P03.DetailPrinter
{
    public class DetailsPrinter
    {
        private IList<IWorker> employees;

        public DetailsPrinter(IList<IWorker> employees)
        {
            this.employees = employees;
        }

        public void PrintDetails()
        {
            foreach (IWorker employee in this.employees)
            {
                employee.PrintEmployee();
            }
        }
    }
}
