using System;
using System.Collections.Generic;

namespace CarList
{
    class CarService : ICarService
    {

        readonly List<Car> cars = new List<Car>
        {
         new Car { Model = "polo", Id = Guid.NewGuid(), Merk = "volkswagen", Type = "stationwagon", Price = 100000d , Afbeelding = "https://www.accuautoshop.nl/media/catalog/product/cache/12/image/9df78eab33525d08d6e5fb8d27136e95/j/j/jj2198_blue_2__2.jpg"},
         new Car { Model = "polo", Id = Guid.NewGuid(), Merk = "volkswagen", Type = "stationwagon", Price = 100000d  , Afbeelding = "https://www.accuautoshop.nl/media/catalog/product/cache/12/image/9df78eab33525d08d6e5fb8d27136e95/j/j/jj2198_blue_2__2.jpg"},
         new Car { Model = "polo", Id = Guid.NewGuid(), Merk = "volkswagen", Type = "stationwagon", Price = 100000d , Afbeelding = "https://www.accuautoshop.nl/media/catalog/product/cache/12/image/9df78eab33525d08d6e5fb8d27136e95/j/j/jj2198_blue_2__2.jpg" },
         new Car { Model = "polo", Id = Guid.NewGuid(), Merk = "volkswagen", Type = "stationwagon", Price = 100000d , Afbeelding = "https://www.accuautoshop.nl/media/catalog/product/cache/12/image/9df78eab33525d08d6e5fb8d27136e95/j/j/jj2198_blue_2__2.jpg"},
         new Car { Model = "polo", Id = Guid.NewGuid(), Merk = "volkswagen", Type = "stationwagon", Price = 100000d , Afbeelding = "https://www.accuautoshop.nl/media/catalog/product/cache/12/image/9df78eab33525d08d6e5fb8d27136e95/j/j/jj2198_blue_2__2.jpg" }

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
