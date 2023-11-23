using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9_MODULE.HomeWork
{
    // Базовый класс "Employee", описывающий общие характеристики сотрудника компании
    class Employee
    {
        protected string name;
        protected int age;
        protected double salary;

        // Конструктор для инициализации полей
        public Employee(string name, int age, double salary)
        {
            this.name = name;
            this.age = age;
            this.salary = salary;
        }

        // Виртуальный метод для получения информации о сотруднике.Он позволяет создавать общий код, который может работать как с объектами базового класса, так и с объектами любого его класса-наследника
        public virtual void GetInfo()
        {
            Console.WriteLine($"Name: {name}, Age: {age}, Salary: {salary}");
        }
        // Виртуальный метод для расчета годовой зарплаты
        public virtual double CalculateAnnualSalary()
        {
            return salary * 12;
        }
    }


    // Класс "Manager", наследующий от "Employee", представляющий менеджера
    class Manager : Employee
    {
        private double bonus;//поле для бонуса

        // Конструктор класса "Manager" с вызовом конструктора базового класса "Employee"
        public Manager(string name, int age, double salary, double bonus)
            : base(name, age, salary)
        {
            this.bonus = bonus;
        }
        // Переопределенный метод для вывода информации о менеджере
        public override void GetInfo()
        {
            base.GetInfo();
            Console.WriteLine($"Bonus: {bonus}");
        }
        // Переопределенный метод для расчета годовой зарплаты с учетом бонуса
        public override double CalculateAnnualSalary()
        {
            return base.CalculateAnnualSalary() + bonus;
        }
    }
    // Класс "Developer", также наследующий от "Employee", представляющий разработчика
    class Developer : Employee
    {
        private int linesOfCodePerDay;// Дополнительное поле для количества строк кода в день
        // Конструктор класса "Developer" с вызовом конструктора базового класса "Employee"
        public Developer(string name, int age, double salary, int linesOfCodePerDay)
            : base(name, age, salary)
        {
            this.linesOfCodePerDay = linesOfCodePerDay;
        }

        public override void GetInfo()
        {
            base.GetInfo();
            Console.WriteLine($"Lines of Code per Day: {linesOfCodePerDay}");
        }

        public override double CalculateAnnualSalary()
        {
            // Предполагается доплата $0.1 за каждую строку кода.
            return base.CalculateAnnualSalary() + (linesOfCodePerDay * 0.1 * 250); //250 рабочих дней в году
        }
    }

    class Program
    {
        static void Main()
        {
            // Создание экземпляров классов "Manager" и "Developer" с инициализацией полей
            Manager manager = new Manager("John Manager", 35, 50000, 5000);
            Developer developer = new Developer("Alice Developer", 28, 60000, 1000);
            // Вывод информации о менеджере и его годовой зарплате
            Console.WriteLine("Manager's Info:");
            manager.GetInfo();
            Console.WriteLine($"Annual Salary: {manager.CalculateAnnualSalary()}\n");
            // Вывод информации о разработчике и его годовой зарплате
            Console.WriteLine("Developer's Info:");
            developer.GetInfo();
            Console.WriteLine($"Annual Salary: {developer.CalculateAnnualSalary()}");
        }
    }
}
