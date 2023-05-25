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
    public class House : Home
    {
        public int NumOfFloors { get; set; }


        public House(int id, string description, float price, string country, int numOfRooms, int numOfFloors, int numOfBedrooms, string address, string image, int ownerId)
        {
            Id = id;
            Description = description;
            Price = price;
            Country = country;
            NumOfRooms = numOfRooms;
            NumOfFloors = numOfFloors;
            NumOfBedrooms = numOfBedrooms;
            Address = address;
            Images.Add(image); 
            OwnerId = ownerId;
            IsFree = true;
            HousesType = HousesType.HOUSE;

        }
        public House(int id, string description, float price, string country, int numOfRooms, int numOfFloors, int numOfBedrooms, string address, int ownerId)
        {
            Id = id;
            Description = description;
            Price = price;
            Country = country;
            NumOfRooms = numOfRooms;
            NumOfFloors = numOfFloors;
            NumOfBedrooms = numOfBedrooms;
            Address = address;
            OwnerId = ownerId;
            IsFree = true;

        }
        public House() { }
    }
}
