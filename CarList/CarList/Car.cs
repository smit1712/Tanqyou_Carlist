using System;
using System.Collections.Generic;
using System.Text;

namespace CarList
{
    class Car
    {
        public string Model { get; set; }
        public Guid Id { get; set; }
        public string Merk { get; set; }
        public string Type { get; set; }
        public Object Afbeelding { get; set; }
        public double Price { get; set; }
        public string FormattedPrice { get { return new ValueConverter().Convert(Price); } }

    }
}
