using LAB_6.Banks;
using LAB_6.Domain;
using LAB_6.VIew;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LAB_6.Decorators;

namespace LAB_6.Presenter
{
    public class EmployeePresenter
    {
        private readonly IView _view;
        private Employee _employee;
        public EmployeePresenter(IView view) => _view = view;
        public void Run()
        {
            while (true)
            {
                _view.Clear();
                UpdateView();
                _view.ShowMenu();
                string choice = _view.GetInput("Выберите действие");

                try
                {
                    switch (choice)
                    {
                        case "1": CreateEmployee(); break;
                        case "2": SetBank(); break;
                        case "3": AddEnglish(); break;
                        case "4": AddDegree(); break;
                        case "0": return;

                    }
                }
                catch (Exception ex) { _view.ShowError(ex.Message); Console.ReadKey(); }

            }
        }
        public void UpdateView()
        {
            if (_employee == null)
            {
                _view.ShowMessage("Нет сотрудника");
                return;
            }


            string salaryResult;

            try
            { // Если _employee это Декоратор, он сам решит, как считать (делегирует внутрь).
                double s = _employee.CalculateSalary();
                salaryResult = $"{s:F2} руб.";
            }

            catch 
            { 
                salaryResult = "НЕ РАССЧИТАНО (Выберите банк)"; 
            }

            _view.ShowEmpoyeeStats(_employee.GetInfo(), _employee.BaseSalary, salaryResult);

        }

        public void CreateEmployee()
        {
            string name = _view.GetInput("Имя");
            double salary = double.Parse(_view.GetInput("Зарплата"));
            string type = _view.GetInput("1-Инженер, 2-Менеджер, 3-Ученый");

            
            // ЖЕНЯ: Реализуй классы Engineer, Manager, Scientist в папке Domain!
            switch (type)
            {
                case "1":
                    _employee = new Engineer(name, salary);
                    break;
                case "2":
                    _employee = new Manager(name, salary);
                    break;
                default:
                    _employee = new Scientist(name, salary);
                    break;
            }
        }

        private void SetBank()
        {
            if (_employee == null) throw new Exception("Сотрудник не создан!");

            string choice = _view.GetInput("1-Сбер, 2-Газпром");

            IBankService bank;
            if (choice == "1")
                bank = new Sberbank();
            else
                bank = new Gazprombank();

            // ЖЕНЯ: БАГ-ЛОВУШКА ДЖОКЕРА
            // Если мы обернули сотрудника, то _employee - это Декоратор.
            // Присваивать банк обертке бесполезно, если она просто передает управление внутрь.
            // Нам нужно "докопаться" до базового сотрудника.
            // Реализуй метод GetBaseEmployee() в EmployeeDecorator!

            if (_employee is EmployeeDecorator decorator)
            {
                decorator.GetBaseEmployee().BankService = bank;
            }
            else
            {
                _employee.BankService = bank;
            }
        }
        private void AddEnglish()
        {
            if (_employee == null) throw new Exception("Сотрудник не создан!");

            // ЖЕНЯ: Реализуй класс IntermediateEnglishCertificate в папке Decorators
            _employee = new IntermediateEnglishCertificate(_employee, "IELTS", 2025);
        }

        private void AddDegree()
        {
            if (_employee == null) throw new Exception("Сотрудник не создан!");

            // ЖЕНЯ: Реализуй класс AcademicDegree в папке Decorators
            _employee = new AcademicDegree(_employee, "PhD", "Computer Science");
        }

    }
}
