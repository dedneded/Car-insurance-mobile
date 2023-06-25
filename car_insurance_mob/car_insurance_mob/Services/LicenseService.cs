using car_insurance_mob.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace car_insurance_mob.Services
{
    class LicenseService
    {
        private static readonly string baseUrl = "http://127.0.0.1:8000/";

        public static async Task<string> CreateLicenseAsync(License license)
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
        public static async Task<License> GetLicenseAsync(int licenseId)
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
                    license.Client.Id = jsonObject.Value<int>("Client");
                    return license;

                }
                else
                {
                    throw new Exception($"Failed to retrieve passport. Status code: {response.StatusCode}");
                }
            }
        }
        public static async Task<string> UpdateLicenseAsync(License license)
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
        public static async Task<List<License>> GetAllLicensesAsync()
        {
            var url = $"{baseUrl}licenses/";

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
                            Id = jsonClient.Value<Int64>("id"),
                            DateOfIssue = jsonClient.Value<DateTime>("DateOfIssue"),
                            ExpirationDate = jsonClient.Value<DateTime>("ExpirationDate"),
                            CodeGIBDD = jsonClient.Value<string>("CodeGIBDD"),
                            Series = jsonClient.Value<string>("Series"),
                            Number = jsonClient.Value<string>("Number"),
                            TransmissionType = jsonClient.Value<string>("TransmissionType"),
                            VehicleCategories = jsonClient.Value<string>("VehicleCategories"),



                        };

                        int clientId = jsonClient.Value<int>("Client");

                        Client client = await ClientService.GetClientAsync(clientId);
                        license.Client = client;

                        licenses.Add(license);
                    }
                    return licenses;
                }
                else
                {
                    throw new Exception($"HTTP request failed with status code {response.StatusCode}");
                }
            }
        }
        public static string str = "92e8c2b2-97d9-4d6d-a9b7-48cb0d039a84";
        public static Guid idTest = new Guid(str);
        public static License license1 = new License(idTest, DateTime.Now, DateTime.Now,"10328", "1111", "102313", "C", "dasdas", "path");
        public static License license2 = new License(Guid.NewGuid(), DateTime.Now, DateTime.Now, "10328", "2222", "102313", "C", "dasdas", "path");
        public static License license3 = new License(Guid.NewGuid(), DateTime.Now, DateTime.Now, "10328", "3333", "102313", "C", "dasdas", "path");
        public static License license4 = new License(Guid.NewGuid(), DateTime.Now, DateTime.Now, "10328", "4444", "102313", "C", "dasdas", "path");
        public List<License> licenses = new List<License> { license1, license2, license3, license4 };
        public LicenseService() { }
        public License GetLicense(Guid id)
        {
            License license = null;
            foreach (License i in licenses)
            {
                if (i.Id == id)
                {
                    license = i;
                }


            }
            return license;
        }
        public List<License> GetAllLicenses()
        {
            return licenses;
        }
        public bool AddLicense(License license)
        {
            return true;
        }
    }
}
