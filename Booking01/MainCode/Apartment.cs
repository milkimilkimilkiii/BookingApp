using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Booking01.MainCode
{
    public class Apartment : Home
    {
        public int Floor { get; set; }
        public int NumOfFloors { get; set; }

        public Apartment(int id, string description, float price, string country, int numOfRooms, int floor, int numOfBedrooms, string address, string image, int ownerId)
        {
            Id = id;
            Description = description;
            Price = price;
            Country = country;
            NumOfRooms = numOfRooms;
            NumOfBedrooms = numOfBedrooms;
            Address = address;
            Images.Add(image);
            OwnerId = ownerId;
            Floor = floor;
            IsFree = true;
            HousesType = HousesType.APARTMENT;

        }

        public Apartment(int id, string description, float price, string country, int numOfRooms, int Floor, int numOfBedrooms, string address, int ownerId)
        {
            Id = id;
            Description = description;
            Price = price;
            Country = country;
            NumOfRooms = numOfRooms;
            NumOfBedrooms = numOfBedrooms;
            Address = address;
            OwnerId = ownerId;
            IsFree = true;
        }

        public Apartment() { }
    }
}
