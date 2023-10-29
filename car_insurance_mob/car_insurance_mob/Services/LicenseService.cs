using car_insurance_mob.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.Collections;

namespace car_insurance_mob.Services
{
    class LicenseService
    {
        
        public readonly string baseUrl = "https://www.myprojectcarinsurance.ru/";
        public List<License> licenses;
        public async Task<string> CreateLicenseAsync(License license)
        {
            var url = $"{baseUrl}licenses/create_license/";
            var jsonContent = JsonConvert.SerializeObject(new
            {
                license.DateOfIssue,
                license.ExpirationDate,
                license.CodeGIBDD,
                license.Series,
                license.Number,
                license.TransmissionType,
                license.VehicleCategories,
                Client = license.Client.Id
            });

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
        public async Task<License> GetLicenseAsync(int licenseId, ClientService clientService, EmployeeService employeeService)
        {
            var url = $"{baseUrl}licenses/get_license/{licenseId}/";

            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var jsonContent = await response.Content.ReadAsStringAsync();
                    // Создаем новый объект License с пустыми полями
                    var license = new License
                    {
                        Client = new Client()
                    };
                    // Устанавливаем только ID клиента из JSON
                    var jsonObject = JObject.Parse(jsonContent);
                    license.Id = jsonObject.Value<int>("id");
                    license.DateOfIssue = jsonObject.Value<DateTime>("DateOfIssue");
                    license.ExpirationDate = jsonObject.Value<DateTime>("ExpirationDate");
                    license.CodeGIBDD = jsonObject.Value<string>("CodeGIBDD");
                    license.Series = jsonObject.Value<string>("Series");
                    license.Number = jsonObject.Value<string>("Number");
                    license.TransmissionType = jsonObject.Value<string>("TransmissionType");
                    license.VehicleCategories = jsonObject.Value<string>("VehicleCategories");
                    try
                    {
                        license.DateDel = jsonObject.Value<DateTime>("DateDel");
                    }
                    catch
                    {

                    }
                    license.Client = await clientService.GetClientAsync(jsonObject.Value<int>("Client"), employeeService);
                    return license;

                }
                else
                {
                    throw new Exception($"Failed to retrieve passport. Status code: {response.StatusCode}");
                }
            }
        }
        public async Task<string> UpdateLicenseAsync(License license)
        {
            var url = $"{baseUrl}licenses/update_license/{license.Id}/";
            var jsonContent = JsonConvert.SerializeObject(new
            {
                license.DateOfIssue,
                license.ExpirationDate,
                license.CodeGIBDD,
                license.Series,
                license.Number,
                license.TransmissionType,
                license.VehicleCategories,
                Client = license.Client.Id
            });

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
        public async Task<License> GetActualLicense(ClientService _clientService, EmployeeService _employeeService, int clientId)
        {
            var url = $"{baseUrl}licenses/get_actual_license/{clientId}";

            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var jsonContent = await response.Content.ReadAsStringAsync();
                    // Создаем новый объект License с пустыми полями
                    var license = new License
                    {
                        Client = new Client()
                    };
                    // Устанавливаем только ID клиента из JSON
                    var jsonObject = JObject.Parse(jsonContent);
                    if (jsonObject.Value<int>("id") != 0)
                    {
                        license.Id = jsonObject.Value<int>("id");
                        license.DateOfIssue = jsonObject.Value<DateTime>("DateOfIssue");
                        license.ExpirationDate = jsonObject.Value<DateTime>("ExpirationDate");
                        license.CodeGIBDD = jsonObject.Value<string>("CodeGIBDD");
                        license.Series = jsonObject.Value<string>("Series");
                        license.Number = jsonObject.Value<string>("Number");
                        license.TransmissionType = jsonObject.Value<string>("TransmissionType");
                        license.VehicleCategories = jsonObject.Value<string>("VehicleCategories");
                        try
                        {
                            license.DateDel = jsonObject.Value<DateTime>("DateDel");
                        }
                        catch
                        {

                        }
                        license.Client = await _clientService.GetClientAsync(jsonObject.Value<int>("Client"), _employeeService);
                    }
                    return license;
                }
                else
                {
                    throw new Exception($"Failed to retrieve passport. Status code: {response.StatusCode}");
                }
            }
        }
        public async Task<List<License>> GetAllLicensesAsync(ClientService clientService, EmployeeService employeeService, int ClientId)
        {
            var url = $"{baseUrl}licenses/{ClientId}";
            List<License> licenses_loc=  new List<License>();
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var jsonContent = await response.Content.ReadAsStringAsync();
                    JArray jsonArray = JArray.Parse(jsonContent);
                    List<License> licenses = new List<License>();

                    foreach (JObject jsonClient in jsonArray)
                    {
                        License license = new License
                        {
                            Id = jsonClient.Value<int>("id"),
                            DateOfIssue = jsonClient.Value<DateTime>("DateOfIssue"),
                            ExpirationDate = jsonClient.Value<DateTime>("ExpirationDate"),
                            CodeGIBDD = jsonClient.Value<string>("CodeGIBDD"),
                            Series = jsonClient.Value<string>("Series"),
                            Number = jsonClient.Value<string>("Number"),
                            TransmissionType = jsonClient.Value<string>("TransmissionType"),
                            VehicleCategories = jsonClient.Value<string>("VehicleCategories"),

                        };
                        int clientId = jsonClient.Value<int>("Client");

                        Client client = await clientService.GetClientAsync(clientId, employeeService);
                        license.Client = client;

                        licenses_loc.Add(license);
                        
                    }
                    this.licenses = licenses_loc;
                    return licenses_loc;
                }
                else
                {
                    throw new Exception($"HTTP request failed with status code {response.StatusCode}");
                }
            }
        }
        public async Task<List<License>> GetAllLicensesDescAsync(ClientService clientService, EmployeeService employeeService, int ClientId)
        {
            var url = $"{baseUrl}licenses/get_all_licenses_desc/{ClientId}";
            List <License> licenses_loc = new List<License>();
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var jsonContent = await response.Content.ReadAsStringAsync();
                    JArray jsonArray = JArray.Parse(jsonContent);
                    List<License> licenses = new List<License>();

                    foreach (JObject jsonClient in jsonArray)
                    {
                        License license = new License
                        {
                            Id = jsonClient.Value<int>("id"),
                            DateOfIssue = jsonClient.Value<DateTime>("DateOfIssue"),
                            ExpirationDate = jsonClient.Value<DateTime>("ExpirationDate"),
                            CodeGIBDD = jsonClient.Value<string>("CodeGIBDD"),
                            Series = jsonClient.Value<string>("Series"),
                            Number = jsonClient.Value<string>("Number"),
                            TransmissionType = jsonClient.Value<string>("TransmissionType"),
                            VehicleCategories = jsonClient.Value<string>("VehicleCategories"),

                        };
                        int clientId = jsonClient.Value<int>("Client");

                        Client client = await clientService.GetClientAsync(clientId, employeeService);
                        license.Client = client;

                        licenses_loc.Add(license);
                        this.licenses = licenses_loc;
                    }

                    return licenses_loc;
                }
                else
                {
                    throw new Exception($"HTTP request failed with status code {response.StatusCode}");
                }
            }
        }
        public async Task<string> DeleteLicenseAsync(int licenseId)
        {
            var url = $"{baseUrl}licenses/delete_license/{licenseId}/";

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
        public LicenseService() { }
        public List<License> GetAllLicenses()
        {
            return this.licenses;
        }
        
    }
}
