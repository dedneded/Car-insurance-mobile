using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using car_insurance_mob.Models;

namespace car_insurance_mob.Services
{
    public class EmployeeService
    {
        private Employee _stateUser;

        public static string str = "92e8c2b2-97d9-4d6d-a9b7-48cb0d039a84";
        public static Guid idTest = new Guid(str);
        public static Employee emp1 = new Employee(idTest, "Иванов Иван Иванович",
            "88001111111", "email1@mail.ru", "111", DateTime.Now, DateTime.Now);
        public static Employee emp2 = new Employee(Guid.NewGuid(), "Антонов Илья Валерьевич",
            "88002222222", "email2@mail.ru", "222", DateTime.Now, DateTime.Now);
        public static Employee emp3 = new Employee(Guid.NewGuid(), "Соловьева Анна Викторовна",
           "88003333333", "email3@mail.ru", "333", DateTime.Now, DateTime.Now);
        public List<Employee> employees = new List<Employee> { emp1, emp2, emp3 };

        public bool AddEmployee(Employee employee)
        {
            employees.Add(employee);
            return true;
        }
        public Employee GetEmployee(string Passwd)
        {
            Employee empl = null;
            foreach (Employee i in employees)
            {
                if (i.Passwd == Passwd)
                {
                    empl = i;
                }


            }
            return empl;
        }
        public bool Authentification(Employee employee)
        {
            Employee emp = GetEmployee(employee.Passwd);
            
            if (emp != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public Employee GetStateUser()
        {
            return _stateUser;
        }
    }
}
