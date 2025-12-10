using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB_6.VIew
{
    public class ConsoleView : IView
    {
        public ConsoleView() => Console.OutputEncoding = Encoding.UTF8;
        public void ShowMenu()
        {
            Console.WriteLine("\n------------Меню------------");
            Console.WriteLine("1. Добавить сотрудника");
            Console.WriteLine("2. Выбрать банк для сотрудника");
            Console.WriteLine("3. Добавить English");
            Console.WriteLine("4. Добавить ученую степень");
            Console.WriteLine("5. Выход");


        }

        public void ShowMessage(string msg) => Console.WriteLine(msg);
        public void ShowError(string error)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Ошибка: {error}");
            Console.ResetColor();
        }
        public void ShowEmpoyeeStats(string info, double baseSalary, string result)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"\n---Статистика сотрудника---\n{info}\nБазовая зарплата: {baseSalary}\nИтоговая зарплата: {result}\n---------------------------");
            Console.ResetColor();
        }

        public string GetInput(string prompt)
        {
            Console.Write($"{prompt}:");
            return Console.ReadLine();
        }
        public void Clear() => Console.Clear();
    }
}
