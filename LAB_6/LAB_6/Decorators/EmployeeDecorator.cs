using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LAB_6.Domain;

namespace LAB_6.Decorators
{
    public abstract class EmployeeDecorator : Employee
    {
        protected Employee _employee;

        // передаем имя и зп из обернутого объекта
        public EmployeeDecorator(Employee employee) : base(employee.Name, employee.BaseSalary)
        {
            _employee = employee;
        }

        public override double CalculateSalary()
        {
            // отдаем расчет вложенному объекту
            // если там внутри есть банк, он посчитает, если там другой декоратор, он передаст дальше
            return _employee.CalculateSalary();
        }

        public override string GetInfo()
        {
            return _employee.GetInfo();
        }

        // джокушка ловушкера
        public Employee GetBaseEmployee()
        {
            if (_employee is EmployeeDecorator decorator)
            {
                return decorator.GetBaseEmployee();
            }
            return _employee;
        }
    }
}
