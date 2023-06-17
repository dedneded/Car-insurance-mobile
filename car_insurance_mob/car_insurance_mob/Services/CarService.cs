using System;
using System.Collections.Generic;
using System.Text;
using car_insurance_mob.Models;

namespace car_insurance_mob.Services
{
    public class CarService
    {
        public static Car car1 = new Car(Guid.NewGuid(), "P758AE", "WDE1400321A269616", "Мерседес Benz",
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
