using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB_6.Domain
{
    public class Manager : Employee
    {
        public Manager(string name, double salary) : base(name, salary) { }
        public override string GetInfo() => $"Должность: Менеджер, ФИО: {Name}";
    }
}
