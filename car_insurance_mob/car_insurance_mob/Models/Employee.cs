using car_insurance_mob.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace car_insurance_mob.Models
{
    public class Employee
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("FIO")]
        public string FIO { get; set; }
        [JsonProperty("Phone")]
        public string Phone { get; set; }
        [JsonProperty("Email")]
        public string Email { get; set; }
        [JsonProperty("IsAdmin")]
        public string IsAdmin { get; set; }
        [JsonProperty("Password")]
        public string Password { get; set; }
        [JsonProperty("DateOfBirth")]
        public DateTime DateOfBirth { get; set; }
        [JsonProperty("DateAdd")]
        public DateTime DateAdd { get; set; }
        [JsonProperty("DateDel")]
        public DateTime? DateDel { get; set; }
        public Employee(string FIO, string Phone, string Email, string Password,
        DateTime DateOfBirth, DateTime DateAdd)
        {
            this.FIO = FIO;
            this.Phone = Phone;
            this.Email = Email;
            this.Password = Password;
            this.DateOfBirth = DateOfBirth;
            this.DateAdd = DateAdd;

        }
        public Employee(string FIO, string Phone, string Email, string Password,
            DateTime DateOfBirth, DateTime DateAdd, DateTime DateDel)
        {
            this.FIO = FIO;
            this.Phone = Phone;
            this.Email = Email;
            this.Password = Password;
            this.DateOfBirth = DateOfBirth;
            this.DateAdd = DateAdd;
            this.DateDel = DateDel;

        }
        public Employee(int Id, string FIO, string Phone, string Email, string Password,
           DateTime DateOfBirth, DateTime DateAdd, DateTime DateDel)
        {
            this.Id = Id;
            this.FIO = FIO;
            this.Phone = Phone;
            this.Email = Email;
            this.Password = Password;
            this.DateOfBirth = DateOfBirth;
            this.DateAdd = DateAdd;
            this.DateDel = DateDel;

        }
        public Employee(string Phone, string Password)
        {
           
            this.Phone = Phone;
           
            this.Password = Password;
           

        }
        public Employee()
        {

        }
         
        /////////////////////////////////////////////////////////////////////////////////////////
        //////UPDATE EMPLOYEE///
        //static async Task Main(string[] args)
        //{
        //    // Получаем информацию о существующем сотруднике
        //    Employee existingEmployee = await EmployeeService.GetEmployeeAsync(1);

        //    if (existingEmployee != null)
        //    {
        //        existingEmployee.Id = 1;
        //        // Изменяем необходимые поля
        //        existingEmployee.FIO = "Новое имя";
        //        existingEmployee.Phone = "Новый телефон";
        //        existingEmployee.Email = "Новый email";
        //        existingEmployee.Passwd = "Новый пароль";
        //        existingEmployee.DateOfBirth = DateTime.Now;

        //        try
        //        {
        //            // Вызываем функцию UpdateEmployeeAsync для обновления сотрудника
        //            string response = await EmployeeService.UpdateEmployeeAsync(existingEmployee);
        //            Console.WriteLine("Employee updated successfully!");
        //            Console.WriteLine("Response: " + response);
        //        }
        //        catch (Exception ex)
        //        {
        //            Console.WriteLine("An error occurred: " + ex.Message);
        //        }
        //    }
        //    else
        //    {
        //        Console.WriteLine("Employee not found.");
        //    }

        //}
        //////UPDATE EMPLOYEE///
        ////////////////////////////////////////////////////////////////////////////////////////////
        ///CREATE EMPLOYEE///
        //static async Task Main(string[] args)
        //{
        //    Employee emp1 = new Employee("Иванов Иван Иванович",
        //        "88001111111", "email1@mail.ru", "111", DateTime.Now, DateTime.Now);



        //    try
        //    {
        //        //Вызываем функцию CreateClientAsync для создания клиента
        //        string response = await EmployeeService.CreateEmployeeAsync(emp1);
        //        Console.WriteLine("Employee created successfully!");
        //        Console.WriteLine("Response: " + response);
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("An error occurred: " + ex.Message);
        //    }
        //}
        ///CREATE EMPLOYEE///
        /////////////////////////////////////////////////////////////////////////////////////////
        ///DELETE EMPLOYEE///
        //static async Task Main(string[] args)
        //{
        //    try
        //    {
        //        Вызываем функцию DeleteEmployeeAsync для удаления сотрудника
        //        string response = await EmployeeService.DeleteEmployeeAsync(1);
        //        Console.WriteLine("Employee deleted successfully!");
        //        Console.WriteLine("Response: " + response);
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("An error occurred: " + ex.Message);
        //    }
        //}
        ///DELETE EMPLOYEE///
        ////////////////////////////////////////////////////////////////////////////////////////////
        /////////GET EMPLOYEES///
        //static async Task Main(string[] args)
        //{
        //    try
        //    {
        //        // Вызываем функцию GetAllEmployeesAsync для получения списка всех сотрудников
        //        List<Employee> employees = await EmployeeService.GetAllEmployeesAsync();

        //        if (employees.Count > 0)
        //        {
        //            // Выводим информацию о каждом сотруднике
        //            foreach (var employee in employees)
        //            {
        //                Console.WriteLine($"ID: {employee.Id}");
        //                Console.WriteLine($"FIO: {employee.FIO}");
        //                Console.WriteLine($"Phone: {employee.Phone}");
        //                Console.WriteLine($"Email: {employee.Email}");
        //                Console.WriteLine($"DateOfBirth: {employee.DateOfBirth}");
        //                Console.WriteLine($"DateAdd: {employee.DateAdd}");
        //                Console.WriteLine();
        //            }
        //        }
        //        else
        //        {
        //            Console.WriteLine("No employees found.");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("An error occurred: " + ex.Message);
        //    }
        //}
        //////GET EMPLOYEES///
    }
}
