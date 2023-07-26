﻿using car_insurance_mob.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using System.Numerics;
using car_insurance_mob.Services;

namespace car_insurance_mob.Services
{
    public class ClientService

    {
        public readonly string baseUrl = "https://www.myprojectcarinsurance.ru/";
        public List<Client> clients;
        public async Task<string> CreateClientAsync(Client client)
        {
            var url = $"{baseUrl}clients/create_client/";
            var jsonContent = JsonConvert.SerializeObject(new { client.Phone, client.Email, client.DateAdd, client.DateDel, Employee = client.Employee.Id });

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
        public  async Task<string> UpdateClientAsync(Client client)
        {
            var url = $"{baseUrl}clients/update_client/{client.Id}/";
            var jsonContent = JsonConvert.SerializeObject(new { client.Phone, client.Email, client.DateAdd, client.DateDel, Employee = client.Employee.Id });

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
        //public async Task<Client> GetClientAsync(int clientId)
        //{
        //    var url = $"{baseUrl}clients/get_client/{clientId}/";

        //    using (var httpClient = new HttpClient())
        //    {
        //        var response = await httpClient.GetAsync(url);

        //        if (response.IsSuccessStatusCode)
        //        {
        //            var jsonContent = await response.Content.ReadAsStringAsync();
        //            // Создаем новый объект Client с пустыми полями
        //            var client = new Client
        //            {
        //                Employee = new Employee()
        //            };
        //            // Устанавливаем только ID сотрудника из JSON
        //            var jsonObject = JObject.Parse(jsonContent);
        //            client.Employee.Id = jsonObject.Value<int>("Employee");
        //            //var client = JsonConvert.DeserializeObject<Client>(jsonContent);
        //            return client;
        //        }
        //        else
        //        {
        //            throw new Exception($"HTTP request failed with status code {response.StatusCode}");
        //        }
        //    }
        //}
        public async Task<Client> GetClientAsync(int clientId, EmployeeService _employeeService)
        {
            var url = $"{baseUrl}clients/get_client/{clientId}/";

            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var jsonContent = await response.Content.ReadAsStringAsync();
                    // Создаем новый объект Client с пустыми полями
                    var client = new Client
                    {
                        Employee = new Employee()
                    };
                    // Устанавливаем только ID сотрудника из JSON
                    var jsonObject = JObject.Parse(jsonContent);
                    client.Id = jsonObject.Value<int>("id");
                    client.Employee = await _employeeService.GetEmployeeAsync(jsonObject.Value<int>("Employee"));
                    client.Email = jsonObject.Value<string>("Email");
                    client.DateAdd = jsonObject.Value<DateTime>("DateAdd");
                    client.Phone = jsonObject.Value<string>("Phone");
                    client.DateDel = jsonObject.Value<DateTime>("DateDel");
                    
                    return client;
                }
                else
                {
                    throw new Exception($"HTTP request failed with status code {response.StatusCode}");
                }
            }
        }
        public async Task<List<Client>> GetAllClientsAsync(EmployeeService _employeeservice)
        {
            var url = $"{baseUrl}clients/";

            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var jsonContent = await response.Content.ReadAsStringAsync();
                    JArray jsonArray = JArray.Parse(jsonContent);
                    List<Client> clients = new List<Client>();

                    foreach (JObject jsonClient in jsonArray)
                    {
                        Client client = new Client
                        {
                            Id = jsonClient.Value<int>("id"),
                            Phone = jsonClient.Value<string>("Phone"),
                            Email = jsonClient.Value<string>("Email"),
                            DateAdd = jsonClient.Value<DateTime>("DateAdd"),
                            DateDel = jsonClient.Value<DateTime>("DateDel"),
                        };

                        int employeeId = jsonClient.Value<int>("Employee");

                        Employee employee = await _employeeservice.GetEmployeeAsync(employeeId);
                        client.Employee = employee;

                        clients.Add(client);
                    }
                    return clients;
                }
                else
                {
                    throw new Exception($"HTTP request failed with status code {response.StatusCode}");
                }
            }
        }
        /// GET CLIENTS

        //public static async Task<List<Client>> GetAllClientsAsync()
        //{
        //    var url = $"{baseUrl}clients/";

        //    using (var httpClient = new HttpClient())
        //    {
        //        var response = await httpClient.GetAsync(url);

        //        if (response.IsSuccessStatusCode)
        //        {
        //            var jsonContent = await response.Content.ReadAsStringAsync();
        //            //var clients = JsonConvert.DeserializeObject<List<Client>>(jsonContent);
        //            JArray jsonArray = JArray.Parse(jsonContent);
        //            List<Client> clients = new List<Client>();

        //            foreach (JObject jsonClient in jsonArray)
        //            {
        //                Client client = new Client
        //                {
        //                    Id = jsonClient.Value<BigInteger>("id"),
        //                    Phone = jsonClient.Value<string>("Phone"),
        //                    Email = jsonClient.Value<string>("Email"),
        //                    DateAdd = jsonClient.Value<DateTime>("DateAdd"),
        //                    DateDel = jsonClient.Value<DateTime>("DateDel"),
        //                };

        //                int employeeId = jsonClient.Value<int>("Employee");

        //                Employee employee = await EmployeeService.GetEmployeeAsync(employeeId);
        //                client.Employee = employee;

        //                clients.Add(client);
        //            }
        //            return clients;
        //        }
        //        else
        //        {
        //            throw new Exception($"HTTP request failed with status code {response.StatusCode}");
        //        }
        //    }
        //}
        /// 
        /// GET CLIENTS
        //public static string str = "92e8c2b2-97d9-4d6d-a9b7-48cb0d039a84";
        //public static Guid idTest = new Guid(str);
        public static Client client1 = new Client(1, "88001111111", "email1@mail.ru", DateTime.Now, DateTime.Now);
        public static Client client2 = new Client(2, "88002222222", "email2@mail.ru", DateTime.Now, DateTime.Now);
        public static Client client3 = new Client(3, "88003333333", "email3@mail.ru", DateTime.Now, DateTime.Now);
        public static Client client4 = new Client(4, "88004444444", "email4@mail.ru", DateTime.Now, DateTime.Now);
        //public List<Client> clients = new List<Client> { client1, client2, client3, client4 };
        public Client GetClient(BigInteger id)
        {
            Client client = null;
            foreach (Client i in clients)
            {
                if (i.Id == id)
                {
                    client = i;
                }


            }
            return client;
        }
        //public List<Client> GetAllClients()
        //{
        //    return clients;
        //}
    }
}
