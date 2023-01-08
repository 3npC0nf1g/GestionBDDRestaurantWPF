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
    /// <summary>
    /// Logique d'interaction pour pgClients.xaml
    /// </summary>
    public partial class pgClients : Page
    {
        BDDSingleton _bdd = BDDSingleton.Instance;
        ICollectionView _listeClient;

        public pgClients()
        {
            InitializeComponent();
            _listeClient = CollectionViewSource.GetDefaultView(_bdd.Clients);
            grpListeClients.DataContext = _listeClient;
        }

        private void AjouterClient(object sender, RoutedEventArgs e)
        {
            Statics.TryCatch(() => { lvClients.SelectedItem = _bdd.AjouterClient("Teuma Steve", "teumayouomo115@gmail.com", 8, "+32484674671"); }, nameof(AjouterClient));
        }

        private void SupprimerClient(object sender, RoutedEventArgs e)
        {
            Client selection = (Client)lvClients.SelectedItem;
            if (selection != null)
            {
                if (MessageBox.Show($"Etes-vous sur de vouloir supprimer le Client {selection.NomPrenom} de la liste ?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    Statics.TryCatch(() => { _bdd.SupprimerClient(selection); }, nameof(SupprimerClient));
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
            _listeClient.SortDescriptions.Clear();

            if (ColumnHeader == _sortColumnHeader)
            {
                _sortDirection = (_sortDirection == ListSortDirection.Ascending ? ListSortDirection.Descending : ListSortDirection.Ascending);
            }
            else
            {
                _sortDirection = ListSortDirection.Ascending;
                _sortColumnHeader = ColumnHeader;
            }

            _listeClient.SortDescriptions.Add(new SortDescription(_sortColumnHeader.Tag.ToString(), _sortDirection));
        }
        #endregion
    }
}
