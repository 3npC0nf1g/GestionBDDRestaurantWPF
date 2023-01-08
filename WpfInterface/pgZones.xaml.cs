using BibliRestaurantBDD;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BibliWPF
{
    public partial class pgZones : Page
    {
        BDDSingleton _bdd = BDDSingleton.Instance;
        ICollectionView _listeZone;

        public pgZones()
        {
            InitializeComponent();
            _listeZone = CollectionViewSource.GetDefaultView(_bdd.Zones);
            grpListeZones.DataContext = _listeZone;
        }

        private void AjouterZone(object sender, RoutedEventArgs e)
        {
            Statics.TryCatch(() => { lvZones.SelectedItem = _bdd.AjouterZone("Mezzanine", false); }, nameof(AjouterZone));
        }

        private void SupprimerZone(object sender, RoutedEventArgs e)
        {
            Zone selection = (Zone)lvZones.SelectedItem;
            if (selection != null)
            {
                if (MessageBox.Show($"Etes-vous sur de vouloir supprimer la Zone {selection.Description} de la liste ?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    Statics.TryCatch(() => { _bdd.SupprimerZone(selection); }, nameof(SupprimerZone));
                }
            }
        }

        #region Mécanisme de tri des données dans le listview
        GridViewColumnHeader _sortColumnHeader = null;
        ListSortDirection _sortDirection = ListSortDirection.Ascending;
        private void OnClick(object sender, RoutedEventArgs args)
        {
            var ColumnHeader = sender as GridViewColumnHeader;
            //Sort the data based on the column selected
            _listeZone.SortDescriptions.Clear();

            if (ColumnHeader == _sortColumnHeader)
            {
                _sortDirection = (_sortDirection == ListSortDirection.Ascending ? ListSortDirection.Descending : ListSortDirection.Ascending);
            }
            else
            {
                _sortDirection = ListSortDirection.Ascending;
                _sortColumnHeader = ColumnHeader;
            }

            _listeZone.SortDescriptions.Add(new SortDescription(_sortColumnHeader.Tag.ToString(), _sortDirection));
        }
        #endregion
    }
}
