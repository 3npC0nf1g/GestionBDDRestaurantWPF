using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliRestaurantBDD
{
    public class SouhaiteAvoir : INotifyPropertyChanged
    {


        public int ClientID { get; set; }
        public Client Client { get; set; }

        public int ReservationID { get; set; }
        public Reservation Reservation { get; set; }

        public int MenuID { get; set; }
        public Menu_ Menu { get; set; }




















        public event PropertyChangedEventHandler PropertyChanged;

    }
}
