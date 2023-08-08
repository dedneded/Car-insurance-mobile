using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using car_insurance_mob.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace car_insurance_mob.Services
{
    public class CarService
    {
        public readonly string baseUrl = "https://www.myprojectcarinsurance.ru/";
        public List<Car> cars;
        public async Task<string> CreateCarAsync(Car car)
        {
            var url = $"{baseUrl}cars/create_car/";
            var jsonContent = JsonConvert.SerializeObject(new
            {
                car.RegistrationNumber,
                car.IdNumber,
                car.Brand,
                car.Model,
                car.TCType,
                car.TCCategory,
                car.YearOfIssue,
                car.EngineModel,
                car.EngineNumber,
                car.ChassisNumber,
                car.CarBodyNumber,
                car.Color,
                car.EnginePower,
                car.EngineDisplacement,
                car.Series,
                car.Number,
                car.MaxWeightPermitted,
                car.WeightWithoutCapacity,
                car.NameOwner,
                car.PlaceRegistration,
                car.PlaceOfIssue,
                car.DateOfIssue,
                Client = car.Client.Id
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
        public async Task<string> UpdateCarAsync(Car car)
        {
            var url = $"{baseUrl}cars/update_car/{car.Id}/";
            var jsonContent = JsonConvert.SerializeObject(new
            {
                car.RegistrationNumber,
                car.IdNumber,
                car.Brand,
                car.Model,
                car.TCType,
                car.TCCategory,
                car.YearOfIssue,
                car.EngineModel,
                car.EngineNumber,
                car.ChassisNumber,
                car.CarBodyNumber,
                car.Color,
                car.EnginePower,
                car.EngineDisplacement,
                car.Series,
                car.Number,
                car.MaxWeightPermitted,
                car.WeightWithoutCapacity,
                car.NameOwner,
                car.PlaceRegistration,
                car.PlaceOfIssue,
                car.DateOfIssue,
                Client = car.Client.Id
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
        public async Task<List<Car>> GetAllCarsAsync(ClientService clientService, EmployeeService employeeService)
        {
            var url = $"{baseUrl}cars/";

            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var jsonContent = await response.Content.ReadAsStringAsync();
                    JArray jsonArray = JArray.Parse(jsonContent);
                    List<Car> cars = new List<Car>();

                    foreach (JObject jsonClient in jsonArray)
                    {
                        Car car = new Car
                        {
                            Id = jsonClient.Value<int>("id"),
                            RegistrationNumber = jsonClient.Value<string>("RegistrationNumber"),
                            IdNumber = jsonClient.Value<string>("IdNumber"),
                            Brand = jsonClient.Value<string>("Brand"),
                            Model = jsonClient.Value<string>("Model"),
                            TCType = jsonClient.Value<string>("TCType"),
                            TCCategory = jsonClient.Value<string>("TCCategory"),
                            YearOfIssue = jsonClient.Value<int>("YearOfIssue"),
                            EngineModel = jsonClient.Value<string>("EngineModel"),
                            EngineNumber = jsonClient.Value<string>("EngineNumber"),
                            ChassisNumber = jsonClient.Value<string>("ChassisNumber"),
                            CarBodyNumber = jsonClient.Value<string>("CarBodyNumber"),
                            Color = jsonClient.Value<string>("Color"),
                            EnginePower = jsonClient.Value<string>("EnginePower"),
                            EngineDisplacement = jsonClient.Value<int>("EngineDisplacement"),
                            Series = jsonClient.Value<string>("Series"),
                            Number = jsonClient.Value<string>("Number"),
                            MaxWeightPermitted = jsonClient.Value<int>("MaxWeightPermitted"),
                            WeightWithoutCapacity = jsonClient.Value<int>("WeightWithoutCapacity"),
                            NameOwner = jsonClient.Value<string>("NameOwner"),
                            PlaceRegistration = jsonClient.Value<string>("PlaceRegistration"),
                            PlaceOfIssue = jsonClient.Value<string>("PlaceOfIssue"),
                            DateOfIssue = jsonClient.Value<DateTime>("DateOfIssue"),

                        };

                        int clientId = jsonClient.Value<int>("Client");
                        Client client = await clientService.GetClientAsync(clientId, employeeService);
                        car.Client = client;

                        cars.Add(car);
                    }
                    return cars;
                }
                else
                {
                    throw new Exception($"HTTP request failed with status code {response.StatusCode}");
                }
            }
        }
        public List<Car> GetAllCars()
        {
            return cars;
        }


    }
}
