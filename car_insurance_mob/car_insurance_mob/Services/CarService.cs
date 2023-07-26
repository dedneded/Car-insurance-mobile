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
        private static readonly string baseUrl = "http://127.0.0.1:8000/";

        public static async Task<string> CreateCarAsync(Car car)
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
        public static async Task<string> UpdateCarAsync(Car car)
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
        public static async Task<List<Car>> GetAllCarsAsync()
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
                            //Id = jsonClient.Value<Int64>("id"),
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

                        //Client client = await ClientService.GetClientAsync(clientId);
                        //car.Client = client;

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
        public static string str = "92e8c2b2-97d9-4d6d-a9b7-48cb0d039a84";
        public static Guid idTest = new Guid(str);
        public static Car car1 = new Car(idTest, "P758AE", "WDE1400321A269616", "Мерседес Benz",
            "9320", "Мерседес Benz 9320", "B", 1995, "model1", "10494422002105",
            "1111", "11111", "Синий", "161/212", 3199, "72EX", "879845", 2380, 1780,
            "Иванов Иван Иванович", "Иркутск, Ленина 11", "ГИБДД Иркутска", DateTime.Now);
        public static Car car2 = new Car(Guid.NewGuid(), "K222MM", "WDE1400321A269616", "Мерседес Benz",
            "9320", "Мерседес Benz 9320", "B", 1996, "model1", "10494422002105",
            "2222", "22222", "Красный", "161/212", 3199, "72EX", "879845", 2380, 1780,
            "Иванов Иван Иванович", "Иркутск, Ленина 11", "ГИБДД Иркутска", DateTime.Now);
        public static Car car3 = new Car(Guid.NewGuid(), "H333AE", "WDE1400321A269616", "Мерседес Benz",
            "9320", "Мерседес Benz 9320", "B", 1997, "model1", "10494422002105",
            "3333", "33333", "Зеленый", "161/212", 3199, "72EX", "879845", 2380, 1780,
            "Иванов Иван Иванович", "Иркутск, Ленина 11", "ГИБДД Иркутска", DateTime.Now);
        public static Car car4 = new Car(Guid.NewGuid(), "С444AE", "WDE1400321A269616", "Мерседес Benz",
            "9320", "Мерседес Benz 9320", "B", 1998, "model1", "10494422002105",
            "4444", "44444", "Черный", "161/212", 3199, "72EX", "879845", 2380, 1780,
            "Иванов Иван Иванович", "Иркутск, Ленина 11", "ГИБДД Иркутска", DateTime.Now);
        public List<Car> cars = new List<Car> { car1, car2, car3, car4 };
        public Car GetCar(Guid id)
        {
            Car car = null;
            foreach (Car i in cars)
            {
                if (i.Id == id)
                {
                    car = i;
                }


            }
            return car;
        }
        public List<Car> GetAllCars()
        {
            return cars;
        }
        public bool AddCar(Car car)
        {
            return true;
        }
    }
}
