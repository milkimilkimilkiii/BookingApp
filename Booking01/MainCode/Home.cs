using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booking01.MainCode
{
    abstract public class Home
    {
        public List<string> Images = new List<string>();
        public int Id = 0;
        public string Address { get; set; }
        public bool IsFree { get; set; }
        public int NumOfBedrooms { get; set; }
        public int NumOfRooms { get; set; }
        public HousesType HousesType { get; set; }
        public string Description { get; set; }
        public float Price {get; set; }
        public string Country { get; set; }
        public int OwnerId { get; set; }
    }
}
