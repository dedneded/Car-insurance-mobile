using car_insurance_mob.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace car_insurance_mob.Services
{
    public class PassportService
    {
        public static string str = "92e8c2b2-97d9-4d6d-a9b7-48cb0d039a84";
        public static Guid idTest = new Guid(str);
        public static Passport pass1 = new Passport(idTest, "dfgdfgdfgdf", DateTime.Now, "1111", "1111", "508349","Иванов Иван Иванович",false, DateTime.Now, "Moscow", "Ленина 11");
        public static Passport pass2 = new Passport(Guid.NewGuid(), "dfgdfgdfgdf", DateTime.Now, "1111", "2222", "321412", "Иванов Иван Иванович", false, DateTime.Now, "Moscow", "Ленина 11");
        public static Passport pass3 = new Passport(Guid.NewGuid(), "dfgdfgdfgdf", DateTime.Now, "1111", "3333", "543729", "Иванов Иван Иванович", false, DateTime.Now, "Moscow", "Ленина 11");
        public static Passport pass4 = new Passport(Guid.NewGuid(), "dfgdfgdfgdf", DateTime.Now, "1111", "4444", "371293", "Иванов Иван Иванович", false, DateTime.Now, "Moscow", "Ленина 11");
        public List<Passport> passports = new List<Passport> { pass1, pass2, pass3, pass4 };
        public Passport GetPassport(Guid id)
        {
            Passport passport = null;
            foreach (Passport i in passports)
            {
                if (i.Id == id)
                {
                    passport = i;
                }


            }
            return passport;
        }
        public List<Passport> GetAllPassports()
        {
            return passports;
        }
        public bool AddPassport(Passport passport)
        {
            return true;
        }
    }
}
