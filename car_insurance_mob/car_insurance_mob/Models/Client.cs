using car_insurance_mob.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace car_insurance_mob.Models
{
    public class Client
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("Phone")]
        public string Phone { get; set; }
        [JsonProperty("Email")]
        public string Email { get; set; }
        [JsonProperty("DateAdd")]
        public DateTime DateAdd { get; set; }

        [JsonProperty("DateDel")]
        public DateTime DateDel { get; set; }
        [JsonProperty("Employee")]
        public Employee Employee { get; set; }
        public string Name { get; set; }


        public Client(string Phone, string Email, DateTime DateAdd, DateTime DateDel, Employee Employee)
        {

            this.Phone = Phone;
            this.Email = Email;
            this.DateAdd = DateAdd;
            this.DateDel = DateDel;
            this.Employee = Employee;
        }
        public Client(int Id, string Phone, string Email, DateTime DateAdd, DateTime DateDel, Employee Employee)
        {
            this.Id = Id;
            this.Phone = Phone;
            this.Email = Email;
            this.DateAdd = DateAdd;
            this.DateDel = DateDel;
            this.Employee = Employee;
        }
        public Client(int Id, string Phone, string Email, DateTime DateAdd, DateTime DateDel)
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
        ///////////////////////////////////////////////////////////////////////////
        //////DELETE CLIENT///
        //static async Task Main(string[] args)
        //{
        //    try
        //    {
        //        //Вызываем функцию DeleteClientAsync для удаления клиента
        //        string response = await ClientService.DeleteClientAsync(10);
        //        Console.WriteLine("Client deleted successfully!");
        //        Console.WriteLine("Response: " + response);
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("An error occurred: " + ex.Message);
        //    }
        //}
        ///DELETE CLIENT///
        ///////////////////////////////////////////////////////////////////////////
        /////////GET CLIENTS///
        //static async Task Main(string[] args)
        //{
        //    try
        //    {
        //        // Вызываем функцию GetAllClientsAsync для получения списка всех клиентов
        //        List<Client> clients = await ClientService.GetAllClientsAsync();

        //        if (clients.Count > 0)
        //        {
        //            // Выводим информацию о каждом сотруднике
        //            foreach (var client in clients)
        //            {
        //                Console.WriteLine($"ID: {client.Id}");
        //                Console.WriteLine($"Phone: {client.Phone}");
        //                Console.WriteLine($"Email: {client.Email}");
        //                Console.WriteLine($"DateAdd: {client.DateAdd}");
        //                Console.WriteLine();
        //            }
        //        }
        //        else
        //        {
        //            Console.WriteLine("No clients found.");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("An error occurred: " + ex.Message);
        //    }
        //}
        //////GET CLIENTS///
    }
}
