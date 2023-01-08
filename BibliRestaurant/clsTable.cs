using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliRestaurantBDD
{
    public class Table_ : INotifyPropertyChanged
    {
        public int ID { get; internal set; }
        public int NombrePlace { get;  set; }

        /// <summary>
        /// Cardinalité de type [1:N], côté 1 : Une zone possible par table.
        /// </summary>
        public Zone Zone { get; set; }
        public int ZoneID { get; internal set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}


