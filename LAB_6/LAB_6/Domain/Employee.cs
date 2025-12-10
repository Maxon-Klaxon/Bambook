using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LAB_6.Banks;

namespace LAB_6.Domain
{
    public abstract class Employee
    {
        public string Name { get; protected set; }
        public double BaseSalary { get; protected set; }
        public IBankService BankService { get; set; }

        protected Employee(string name, double baseSalary)
        {
            Name = name;
            BaseSalary = baseSalary;
            
        }

        public abstract string GetInfo();

        // ЖЕНЯ: Метод virtual. В Декораторе переопредели его и вызывай _employee.CalculateSalary()
        public virtual double CalculateSalary()
        {
            if (BankService == null)
            {
                throw new Exception("Банк не выбран!");
                
            }
            return BankService.CalculateSalary(BaseSalary);
        }
    }
}
