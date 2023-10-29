using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using car_insurance_mob.Models;
using car_insurance_mob.Services;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Linq;

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
        public async Task<List<Car>> GetAllCarsAsync(ClientService clientService, EmployeeService employeeService, int ClientId)
        {
            var url = $"{baseUrl}cars/{ClientId}";

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
        public async Task<List<Car>> FilterCarsAsync(ClientService clientService, EmployeeService employeeService, string RegistrationNumber)
        {
            var url = $"{baseUrl}cars/filter_cars/?registrationNumber={RegistrationNumber}";

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
        public async Task<Car> GetCarAsync(int carId, ClientService clientService, EmployeeService employeeService)
        {
            var url = $"{baseUrl}cars/get_car/{carId}/";

            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var jsonContent = await response.Content.ReadAsStringAsync();
                    // Создаем новый объект Car с пустыми полями
                    var car = new Car
                    {
                        Client = new Client()
                    };
                    // Устанавливаем только ID клиента из JSON
                    var jsonObject = JObject.Parse(jsonContent);
                    car.Id = jsonObject.Value<int>("id");
                    car.Brand = jsonObject.Value<string>("Brand");
                    car.CarBodyNumber = jsonObject.Value<string>("CarBodyNumber");
                    car.ChassisNumber = jsonObject.Value<string>("ChassisNumber");
                    car.TCCategory = jsonObject.Value<string>("TCCategory");
                    car.Color = jsonObject.Value<string>("Color");
                    car.TCCategory = jsonObject.Value<string>("TCCategory");
                    car.EnginePower = jsonObject.Value<string>("EnginePower");
                    car.IdNumber = jsonObject.Value<string>("IdNumber");
                    car.RegistrationNumber = jsonObject.Value<string>("RegistrationNumber");
                    car.Model = jsonObject.Value<string>("Model");
                    car.TCType = jsonObject.Value<string>("TCType");
                    car.YearOfIssue = jsonObject.Value<int>("YearOfIssue");
                    car.PlaceRegistration = jsonObject.Value<string>("PlaceRegistration");
                    car.PlaceOfIssue = jsonObject.Value<string>("PlaceOfIssue");
                    car.EngineModel = jsonObject.Value<string>("EngineModel");
                    car.EngineDisplacement = jsonObject.Value<int>("EngineDisplacement");
                    car.Series = jsonObject.Value<string>("Series");
                    car.Number = jsonObject.Value<string>("Number");
                    car.MaxWeightPermitted = jsonObject.Value<int>("MaxWeightPermitted");
                    car.WeightWithoutCapacity = jsonObject.Value<int>("WeightWithoutCapacity");
                    car.NameOwner = jsonObject.Value<string>("NameOwner");
                    car.DateOfIssue = jsonObject.Value<DateTime>("DateOfIssue");
                    try
                    {
                        car.DateDel = jsonObject.Value<DateTime>("DateDel");
                    }
                    catch
                    {

                    }
                    car.Client = await clientService.GetClientAsync(jsonObject.Value<int>("Client"), employeeService);
                    return car;

                }
                else
                {
                    throw new Exception($"Failed to retrieve car. Status code: {response.StatusCode}");
                }
            }
        }
        public async Task<string> DeleteCarAsync(int carId)
        {
            var url = $"{baseUrl}cars/delete_car/{carId}/";

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
        public List<Car> GetAllCars()
        {
            return cars;
        }
        


    }
}
