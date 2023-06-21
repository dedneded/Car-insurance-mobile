using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Http;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using car_insurance_mob.Models;
using Newtonsoft.Json;
using System.Linq;

namespace car_insurance_mob.Services
{
    public class EmployeeService
    {
        public readonly string baseUrl = "http://127.0.0.1:8000/";
        public async Task<string> CreateEmployeeAsync(Employee employee)
        {
            var url = $"{baseUrl}employees/create_employee/";
            var jsonContent = JsonConvert.SerializeObject(employee);

            using (var httpClient = new HttpClient())
            {
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync(url, content);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsStringAsync();
                }
                else
                {
                    throw new Exception($"HTTP request failed with status code {response.StatusCode}");
                }
            }
        }
        public async Task<string> UpdateEmployeeAsync(Employee employee)
        {
            var url = $"{baseUrl}employees/update_employee/{employee.Id}/";
            var jsonContent = JsonConvert.SerializeObject(employee);

            using (var httpClient = new HttpClient())
            {
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                var response = await httpClient.PutAsync(url, content);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsStringAsync();
                }
                else
                {
                    throw new Exception($"HTTP request failed with status code {response.StatusCode}");
                }
            }
        }
        public async Task<Employee> GetEmployeeAsync(int employeeId)
        {
            var url = $"{baseUrl}employees/get_employee/{employeeId}/";

            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var jsonContent = await response.Content.ReadAsStringAsync();
                    var employee = JsonConvert.DeserializeObject<Employee>(jsonContent);
                    return employee;
                }
                else
                {
                    throw new Exception($"HTTP request failed with status code {response.StatusCode}");
                }
            }
        }
        public async Task<string> DeleteEmployeeAsync(int employeeId)
        {
            var url = $"{baseUrl}employees/delete_employee/{employeeId}/";

            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.DeleteAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsStringAsync();
                }
                else
                {
                    throw new Exception($"HTTP request failed with status code {response.StatusCode}");
                }
            }
        }
        private Employee _stateUser;

        //public static string str = "92e8c2b2-97d9-4d6d-a9b7-48cb0d039a84";
        //public static Guid idTest = new Guid(str);
        public static Employee emp1 = new Employee("Иванов Иван Иванович",
            "88001111111", "email1@mail.ru", "111", DateTime.Now, DateTime.Now);
        public static Employee emp2 = new Employee("Антонов Илья Валерьевич",
            "88002222222", "email2@mail.ru", "222", DateTime.Now, DateTime.Now);
        public static Employee emp3 = new Employee("Соловьева Анна Викторовна",
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
