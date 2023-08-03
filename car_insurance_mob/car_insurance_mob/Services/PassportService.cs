using car_insurance_mob.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace car_insurance_mob.Services
{
    public class PassportService
    {
        public readonly string baseUrl = "https://www.myprojectcarinsurance.ru/";

        public async Task<string> CreatePassportAsync(Passport passport)
        {
            var url = $"{baseUrl}passports/create_passport/";
            var jsonContent = JsonConvert.SerializeObject(new
            {
                passport.IssuedByWhom,
                passport.DateOfIssue,
                passport.DivisionCode,
                passport.Series,
                passport.Number,
                passport.FIO,
                passport.IsMale,
                passport.DateOfBirth,
                passport.PlaceOfBirth,
                passport.ResidenceAddress,
                Client = passport.Client.Id,
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
        public async Task<string> UpdatePassportAsync(Passport passport)
        {
            var url = $"{baseUrl}passports/update_passport/{passport.Id}/";
            var jsonContent = JsonConvert.SerializeObject(new
            {
                passport.IssuedByWhom,
                passport.DateOfIssue,
                passport.DivisionCode,
                passport.Series,
                passport.Number,
                passport.FIO,
                passport.IsMale,
                passport.DateOfBirth,
                passport.PlaceOfBirth,
                passport.ResidenceAddress,
                Client = passport.Client.Id
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
        public async Task<Passport> GetPassportAsync(int passportId)
        {
            var url = $"{baseUrl}passports/get_passport/{passportId}/";

            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var jsonContent = await response.Content.ReadAsStringAsync();
                    // Создаем новый объект Passport с пустыми полями
                    var passport = new Passport
                    {
                        Client = new Client()
                    };
                    // Устанавливаем только ID клиента из JSON
                    var jsonObject = JObject.Parse(jsonContent);
                    passport.Client.Id = jsonObject.Value<int>("Client");
                    return passport;

                }
                else
                {
                    throw new Exception($"Failed to retrieve passport. Status code: {response.StatusCode}");
                }
            }
        }
        public async Task<Passport> GetActualPassport(ClientService _clientService, EmployeeService _employeeService, int clientId)
        {
            var url = $"{baseUrl}passports/get_actual_passport/{clientId}";

            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var jsonContent = await response.Content.ReadAsStringAsync();
                    // Создаем новый объект Passport с пустыми полями
                    var passport = new Passport
                    {
                        Client = new Client()
                    };
                    // Устанавливаем только ID клиента из JSON
                    var jsonObject = JObject.Parse(jsonContent);
                    
                    passport.Client = await _clientService.GetClientAsync(jsonObject.Value<int>("Client"), _employeeService);
                    passport.Id = jsonObject.Value<int>("id");
                    passport.IssuedByWhom = jsonObject.Value<string>("IssuedByWhom");
                    passport.DateOfIssue = jsonObject.Value<DateTime>("DateOfIssue");
                    passport.DivisionCode = jsonObject.Value<string>("DivisionCode");
                    passport.Series = jsonObject.Value<string>("Series");
                    passport.Number = jsonObject.Value<string>("Number");
                    passport.FIO = jsonObject.Value<string>("FIO");
                    passport.IsMale = jsonObject.Value<bool>("IsMale");
                    passport.DateOfBirth = jsonObject.Value<DateTime>("DateOfBirth");
                    passport.PlaceOfBirth = jsonObject.Value<string>("PlaceOfBirth");
                    passport.ResidenceAddress = jsonObject.Value<string>("ResidenceAddress");


                    return passport;

                }
                else
                {
                    throw new Exception($"Failed to retrieve passport. Status code: {response.StatusCode}");
                }
            }
        }
        public async Task<List<Passport>> GetAllPassportsAsync()
        {
            var url = $"{baseUrl}passports/";

            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var jsonContent = await response.Content.ReadAsStringAsync();
                    JArray jsonArray = JArray.Parse(jsonContent);
                    List<Passport> passports = new List<Passport>();

                    foreach (JObject jsonClient in jsonArray)
                    {
                        Passport passport = new Passport
                        {
                            Id = jsonClient.Value<int>("id"),
                            IssuedByWhom = jsonClient.Value<string>("IssuedByWhom"),
                            DateOfIssue = jsonClient.Value<DateTime>("DateOfIssue"),
                            DivisionCode = jsonClient.Value<string>("DivisionCode"),
                            Series = jsonClient.Value<string>("Series"),
                            Number = jsonClient.Value<string>("Number"),
                            FIO = jsonClient.Value<string>("FIO"),
                            IsMale = jsonClient.Value<bool>("IsMale"),
                            DateOfBirth = jsonClient.Value<DateTime>("DateOfBirth"),
                            PlaceOfBirth = jsonClient.Value<string>("PlaceOfBirth"),
                            ResidenceAddress = jsonClient.Value<string>("ResidenceAddress"),


                        };

                        int clientId = jsonClient.Value<int>("Client");

                        //Client client = await ClientService.GetClientAsync(clientId);
                        //passport.Client = client;

                        passports.Add(passport);
                    }
                    return passports;
                }
                else
                {
                    throw new Exception($"HTTP request failed with status code {response.StatusCode}");
                }
            }
        }
        public async Task<string> DeletePassportAsync(int passportId)
        {
            var url = $"{baseUrl}passports/delete_passport/{passportId}/";

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
        public static string str = "92e8c2b2-97d9-4d6d-a9b7-48cb0d039a84";
        //public static Guid idTest = new Guid(str);
        //public static Passport pass1 = new Passport(idTest, "dfgdfgdfgdf", DateTime.Now, "1111", "1111", "508349","Иванов Иван Иванович",false, DateTime.Now, "Moscow", "Ленина 11");
        //public static Passport pass2 = new Passport(Guid.NewGuid(), "dfgdfgdfgdf", DateTime.Now, "1111", "2222", "321412", "Иванов Иван Иванович", false, DateTime.Now, "Moscow", "Ленина 11");
        //public static Passport pass3 = new Passport(Guid.NewGuid(), "dfgdfgdfgdf", DateTime.Now, "1111", "3333", "543729", "Иванов Иван Иванович", false, DateTime.Now, "Moscow", "Ленина 11");
        //public static Passport pass4 = new Passport(Guid.NewGuid(), "dfgdfgdfgdf", DateTime.Now, "1111", "4444", "371293", "Иванов Иван Иванович", false, DateTime.Now, "Moscow", "Ленина 11");
        //public List<Passport> passports = new List<Passport> { pass1, pass2, pass3, pass4 };
        public Passport GetPassport(Guid id)
        {
            Passport passport = null;
            //foreach (Passport i in passports)
            //{
            //    //if (i.Id == id)
            //    //{
            //    //    passport = i;
            //    //}


            //}
            return passport;
        }
        //public List<Passport> GetAllPassports()
        //{
        //    return passports;
        //}
        public bool AddPassport(Passport passport)
        {
            return true;
        }
    }
}
