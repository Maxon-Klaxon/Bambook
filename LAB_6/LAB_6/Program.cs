using LAB_6.Presenter;
using LAB_6.VIew;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB_6
{
    internal class Program
    {
        static void Main(string[] args)
        {  
            
            IView view = new ConsoleView();

            // Презентер связывает View и Модель
            EmployeePresenter presenter = new EmployeePresenter(view);

            presenter.Run();
        }
    }
}
