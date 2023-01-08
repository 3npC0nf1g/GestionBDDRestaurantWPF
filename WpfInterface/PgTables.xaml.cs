using BibliRestaurantBDD;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// <summary>
    /// Logique d'interaction pour pgReservations.xaml
    /// </summary>
    public partial class PgTables : Page
    {
        BDDSingleton _bdd = BDDSingleton.Instance;
        ICollectionView _listeTables;
        public ReadOnlyObservableCollection<Zone> Zones => _bdd.Zones;

        public PgTables()
        {
            InitializeComponent();
            _listeTables = CollectionViewSource.GetDefaultView(_bdd.Tables);
            grpTables.DataContext = _listeTables;
        }
        private void AjouterTable(object sender, RoutedEventArgs e)
        {
            Statics.TryCatch(() => { lvTables.SelectedItem = _bdd.AjouterTable(5,  _bdd.Zones.FirstOrDefault()); }, nameof(AjouterTable));
        }
        private void SupprimerTable(object sender, RoutedEventArgs e)
        {
            Table_ selection = (Table_)lvTables.SelectedItem;
            if (selection != null)
            {
                if (MessageBox.Show($"Etes-vous sur de vouloir supprimer la Table de {selection.NombrePlace} places de la liste ?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    Statics.TryCatch(() => { _bdd.SupprimerTable(selection); }, nameof(SupprimerTable));
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
            _listeTables.SortDescriptions.Clear();

            if (ColumnHeader == _sortColumnHeader)
            {
                _sortDirection = (_sortDirection == ListSortDirection.Ascending ? ListSortDirection.Descending : ListSortDirection.Ascending);
            }
            else
            {
                _sortDirection = ListSortDirection.Ascending;
                _sortColumnHeader = ColumnHeader;
            }

            _listeTables.SortDescriptions.Add(new SortDescription(_sortColumnHeader.Tag.ToString(), _sortDirection));
        }
        #endregion
    }
}