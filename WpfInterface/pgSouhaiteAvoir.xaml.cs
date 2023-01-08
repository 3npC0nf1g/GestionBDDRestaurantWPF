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
    public partial class pgSouhaiteAvoir : Page
    {
        BDDSingleton _bdd = BDDSingleton.Instance;
        ICollectionView _listeSouhaiteAvoir;
        public ReadOnlyObservableCollection<Client> Clients => _bdd.Clients;
        public ReadOnlyObservableCollection<Menu_> Menus => _bdd.Menus;
        public ReadOnlyObservableCollection<Reservation> Reservations => _bdd.Reservations;

        public pgSouhaiteAvoir()
        {
            InitializeComponent();
            _listeSouhaiteAvoir = CollectionViewSource.GetDefaultView(_bdd.SouhaiteAvoir);
            grpSouhaiteAvoir.DataContext = _listeSouhaiteAvoir;
        }

        #region Code associé à l'inputBox permettant d'ajouter un lien écrire (livre-auteur)
        private void AjouterSouhaiteAvoirAfficherInbox(object sender, RoutedEventArgs e)
        {
            IAE_cmbClient.SelectedItem = null;
            IAE_cmbReservation.SelectedItem = null;
            IAE_cmbMenu.SelectedItem = null;
            inboxAjouterSouhaiteAvoir.Visibility = Visibility.Visible;
        }
        private void AjouterSouhaiteAvoirAnnulerAction(object sender, RoutedEventArgs e) { inboxAjouterSouhaiteAvoir.Visibility = Visibility.Collapsed; }
        private void AjouterSouhaiteAvoirConfirmerAction(object sender, RoutedEventArgs e)
        {
            try
            {
                SouhaiteAvoir lNouveauSouhaiteAvoir = _bdd.AjouterSouhaiteAvoir((Client)IAE_cmbClient.SelectedItem, (Reservation)IAE_cmbReservation.SelectedItem, (Menu_)IAE_cmbMenu.SelectedItem);
                inboxAjouterSouhaiteAvoir.Visibility = Visibility.Collapsed;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Ajouter un lien SouhaiteAvoir", MessageBoxButton.OK, MessageBoxImage.Warning); }
        }
        #endregion

        private void SupprimerSouhaiteAvoir(object sender, RoutedEventArgs e)
        {
            SouhaiteAvoir selection = (SouhaiteAvoir)lvSouhaiteAvoir.SelectedItem;
            if (selection != null)
            {
                if (MessageBox.Show($"Etes-vous sur de vouloir supprimer le Monsieur {selection.Client.NomPrenom} de la liste ?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    Statics.TryCatch(() => { _bdd.SupprimerSouhaiteAvoir(selection); }, nameof(SupprimerSouhaiteAvoir));
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
            _listeSouhaiteAvoir.SortDescriptions.Clear();

            if (ColumnHeader == _sortColumnHeader)
            {
                _sortDirection = (_sortDirection == ListSortDirection.Ascending ? ListSortDirection.Descending : ListSortDirection.Ascending);
            }
            else
            {
                _sortDirection = ListSortDirection.Ascending;
                _sortColumnHeader = ColumnHeader;
            }

            _listeSouhaiteAvoir.SortDescriptions.Add(new SortDescription(_sortColumnHeader.Tag.ToString(), _sortDirection));
        }
        #endregion
    }
}
