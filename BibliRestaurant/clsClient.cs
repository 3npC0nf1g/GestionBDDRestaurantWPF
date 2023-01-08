using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliRestaurantBDD
{
    public class Client : INotifyPropertyChanged
    {
        public int ID { get; internal set; }

        public string NomPrenom { get; set; }

        public string NumeroTelephone { get; set; }

        public string Email { get; set; }

        public int NombrePersonne { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
