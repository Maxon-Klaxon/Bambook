using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB_6.Banks
{
    public class Sberbank : IBankService
    {
        public string Name => "Сбербанк";
        public double CalculateSalary(double baseSalary) => baseSalary * 0.99;
    
    }
}
