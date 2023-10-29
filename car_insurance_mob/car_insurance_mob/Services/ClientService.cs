using car_insurance_mob.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using System.Numerics;
using car_insurance_mob.Services;
using System.Linq;

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
        public async Task<List<Client>> GetAllClientsAsync(EmployeeService _employeeservice, PassportService _passportService, ClientService _clientService)
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
                        await _passportService.GetActualPassport(_clientService, _employeeservice, client.Id);
                        client.Name = _passportService.Name;

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
        public async Task<List<Client>> FilterClientsAsync(EmployeeService _employeeservice, PassportService _passportService, ClientService _clientService, string Email, string Phone)
        {
            var url = $"{baseUrl}clients/filter_clients/?email={Email}&phone={Phone}";

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
                        await _passportService.GetActualPassport(_clientService, _employeeservice, client.Id);
                        client.Name = _passportService.Name;
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
        public void OrderByClient()
        {
            this.clients= clients.OrderBy(p => p.Name.FirstOrDefault()).ToList();
        }
        public void OrderByDescendingClient()
        {
            this.clients = clients.OrderByDescending(p => p.Name.FirstOrDefault()).ToList();
        }
       

    }
}
