using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace BibliRestaurantBDD
{ public class  Menu_ : INotifyPropertyChanged
    {
        public int ID { get; internal set; }
        public string Entree  { get; set; }
        public string Repas  { get; set; }
        public string Dessert  { get; set; }
        public string Boisson   { get; set; }
     
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
