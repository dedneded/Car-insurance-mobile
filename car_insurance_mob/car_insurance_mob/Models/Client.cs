using car_insurance_mob.Services;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace car_insurance_mob.Models
{
    public class Client
    {
        public Guid Id { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public DateTime DateAdd { get; set; }
        public DateTime DateDel { get; set; }
       
       public Employee Employee { get; set; }

        public Client(string Phone, string Email, DateTime DateAdd, DateTime DateDel, Employee Employee)
        {

            this.Phone = Phone;
            this.Email = Email;
            this.DateAdd = DateAdd;
            this.DateDel = DateDel;
            this.Employee = Employee;
        }
        public Client(Guid Id, string Phone, string Email, DateTime DateAdd, DateTime DateDel, Employee Employee)
        {
            this.Id = Id;
            this.Phone = Phone;
            this.Email = Email;
            this.DateAdd = DateAdd;
            this.DateDel = DateDel;
            this.Employee = Employee;
        }
        public Client(Guid Id, string Phone, string Email, DateTime DateAdd, DateTime DateDel)
        {
            this.Id = Id;
            this.Phone = Phone;
            this.Email = Email;
            this.DateAdd = DateAdd;
            this.DateDel = DateDel;
            
        }
        public Client(string Phone, string Email, DateTime DateAdd, DateTime DateDel)
        {

            this.Phone = Phone;
            this.Email = Email;
            this.DateAdd = DateAdd;
            this.DateDel = DateDel;
        }
        public Client()
        {
            
        }
        ///////////////////////////////////////////////////////////////////////////
        //CREATE CLIENT
        //static async Task Main(string[] args)
        //{
        //    Employee existingEmployee = await EmployeeService.GetEmployeeAsync(1);

        //    if (existingEmployee != null)
        //    {
        //        existingEmployee.Id = 1;
        //        // Создаем экземпляр класса Client с нужными данными
        //        Client client = new Client("88001111111", "email1@mail.ru", DateTime.Now, existingEmployee);
        //        try
        //        {
        //            // Вызываем функцию CreateClientAsync для создания клиента
        //            string response = await ClientService.CreateClientAsync(client);
        //            Console.WriteLine("Client created successfully!");
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
        //CREATE CLIENT
        ///////////////////////////////////////////////////////////////////////////
        //////UPDATE CLIENT///
        //static async Task Main(string[] args)
        //{
        //    // Получаем информацию о существующем сотруднике
        //    Client existingClient = await ClientService.GetClientAsync(10);

        //    if (existingClient != null)
        //    {
        //        existingClient.Id = 10;
        //        // Изменяем необходимые поля
        //        existingClient.Phone = "Новый телефон";
        //        existingClient.Email = "Новый email";
        //        Employee existingEmployee = await EmployeeService.GetEmployeeAsync(7);
        //        existingClient.Employee = existingEmployee;


        //        try
        //        {
        //            // Вызываем функцию UpdateEmployeeAsync для обновления сотрудника
        //            string response = await ClientService.UpdateClientAsync(existingClient);
        //            Console.WriteLine("Client updated successfully!");
        //            Console.WriteLine("Response: " + response);
        //        }
        //        catch (Exception ex)
        //        {
        //            Console.WriteLine("An error occurred: " + ex.Message);
        //        }
        //    }
        //    else
        //    {
        //        Console.WriteLine("Client not found.");
        //    }

        //}
        //////UPDATE CLIENT///
    }
}
