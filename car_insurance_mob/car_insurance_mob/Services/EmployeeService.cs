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
        public readonly string baseUrl = "https://www.myprojectcarinsurance.ru/";
        public async Task<string> CreateEmployeeAsync(Employee employee)
        {
            var url = $"{baseUrl}employees/create_employee/";
            List<string> stringList = new List<string> { "foo", "bar", "baz" };
            string jsonString = JsonConvert.SerializeObject(stringList);
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
        public async Task<List<Employee>> GetAllEmployeesAsync()
        {
            var url = $"{baseUrl}employees/";

            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var jsonContent = await response.Content.ReadAsStringAsync();
                    var employees = JsonConvert.DeserializeObject<List<Employee>>(jsonContent);
                    return employees;
                }
                else
                {
                    throw new Exception($"HTTP request failed with status code {response.StatusCode}");
                }
            }
        }
        private Employee _stateUser;

      
        //public Employee GetEmployee(string Passwd)
        //{
        //    Employee empl = null;
        //    foreach (Employee i in employees)
        //    {
        //        if (i.Passwd == Passwd)
        //        {
        //            empl = i;
        //        }


        //    }
        //    return empl;
        //}
        //public bool Authentification(Employee employee)
        //{
        //    Employee emp = GetEmployee(employee.Passwd);
            
        //    if (emp != null)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}
        public Employee GetStateUser()
        {
            return _stateUser;
        }
    }
}
