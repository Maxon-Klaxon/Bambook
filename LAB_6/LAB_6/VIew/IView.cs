using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB_6.VIew
{
    public interface IView
    {
        void ShowMenu();
        void ShowMessage(string message);
        void ShowError(string error);
        void ShowEmpoyeeStats(string info, double baseSalary, string salaryResult);
        string GetInput(string prompt);
        void Clear();
    }
}
