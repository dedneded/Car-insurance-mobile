﻿using car_insurance_mob.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace car_insurance_mob.Services
{
    class LicenseService
    {
        public static License license1 = new License(Guid.NewGuid(), DateTime.Now, DateTime.Now,"10328", "1111", "102313", "C", "dasdas", "path");
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
    }
}