using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Booking01.MainCode
{
    public class Reservation : IReservation
    {
        public int Book(Home home, User user, DateTime date)
        {
            if (LookIsFree(home) == false)
            {
                return 1;
            }
            if(date < DateTime.Now)
            {
                return 2;
            }

            user.Renting.Add(home.Id);
            home.IsFree = false;
            FindHome.UpdateUserInfo(user);
            FindHome.UpdateHomeInfo(home);
            return 0;
        }

        public bool DelHouse(Home home, User user)
        {
            if ((user.IsAdmin == true && home.IsFree == true) || (home.OwnerId == user.Id && home.IsFree == true))
            {
                
                FindHome.houses.Remove(home);
                FindHome.DelHomeFromFile(home);
                return true;
            }
            MessageBox.Show("Квартира зайнята");
            return false;
            
        }

        public void cancelRent(Home home, User user)
        {
            home.IsFree = true;
            user.Renting.Remove(home.Id);

            FindHome.UpdateUserInfo(user);
            FindHome.UpdateHomeInfo(home);
        }

        public bool LookIsFree(Home home)
        {

            return home.IsFree;
        }

        public void RentOut(Home home, User user) 
        { 
            //user.RentOwn.Add(home);
            //FindHome.houses.Add(home);
        }
    }
}
