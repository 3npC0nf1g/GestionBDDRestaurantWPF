using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliRestaurantBDD
{
    public class Reservation : INotifyPropertyChanged
    {
        public int ID { get; internal set; }
        public int NombrePersonne { get; set; }
        public DateTime DateHeure { get; set; }
        public bool Manque { get; set; }

        /// <summary>
        /// Cardinalité de type [1:N], côté 1 : 1 Table par Reservation.
        /// </summary>
        public Table_ Table { get; set; }
        public int TableID { get; internal set; } 
        
        /// <summary>
        /// Cardinalité de type [1:N], côté 1 : 1 Client par Reservation.
        /// </summary>
        public Client Client { get; set; }
        public int ClientID { get; internal set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
