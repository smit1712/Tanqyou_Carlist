using System;
using System.Collections.Generic;

namespace CarList
{
    class CarService : ICarService
    {

        readonly List<Car> cars = new List<Car>
        {
         new Car { Model = "polo", Id = Guid.NewGuid(), Merk = "volkswagen", Type = "stationwagon", Price = 100000d , Afbeelding = "https://www.autoscout24.nl/assets/auto/images/model/vw/vw-polo/vw-polo-l-01.webp"},
         new Car { Model = "polo", Id = Guid.NewGuid(), Merk = "volkswagen", Type = "stationwagon", Price = 100000d  , Afbeelding = "https://www.autoscout24.nl/assets/auto/images/model/vw/vw-polo/vw-polo-l-01.webp"},
         new Car { Model = "polo", Id = Guid.NewGuid(), Merk = "volkswagen", Type = "stationwagon", Price = 100000d , Afbeelding = "https://www.autoscout24.nl/assets/auto/images/model/vw/vw-polo/vw-polo-l-01.webp" },
         new Car { Model = "polo", Id = Guid.NewGuid(), Merk = "volkswagen", Type = "stationwagon", Price = 100000d , Afbeelding = "https://www.autoscout24.nl/assets/auto/images/model/vw/vw-polo/vw-polo-l-01.webp"},
         new Car { Model = "polo", Id = Guid.NewGuid(), Merk = "volkswagen", Type = "stationwagon", Price = 100000d , Afbeelding = "https://www.autoscout24.nl/assets/auto/images/model/vw/vw-polo/vw-polo-l-01.webp" }

        };
        public List<Car> GetCars()
        {            
            return cars;
        }
        public Car GetCarDetails(Guid ID)
        {
            foreach (Car c in cars)
            {
                if (c.Id == ID)
                {
                    return c;
                }

            }
            return new Car{Model = "No car found" };
        }
    }
}
