using BibliRestaurantBDD;
using System;
using System.Windows;
using System.Windows.Data;

namespace   BibliWPF {

    /// <summary>
    /// Inverse la valeur 'Fumeur' d'une personne (pour le radio bouton associé)
    /// Inverse la valeur 'Manque' d'une personne (pour le radio bouton associé)
    /// </summary>
    public class BoolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null) return DependencyProperty.UnsetValue;
            return !((bool)value);
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture) => null;
    }
}


