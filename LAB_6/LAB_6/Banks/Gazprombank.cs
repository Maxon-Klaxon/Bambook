using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB_6.Banks
{
    public class Gazprombank : IBankService
    {
        public string Name => "Газпромбанк";
        public double CalculateSalary(double baseSalary) => baseSalary * 0.985;
        
    }
}
