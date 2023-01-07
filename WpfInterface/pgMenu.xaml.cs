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
    /// Logique d'interaction pour pgMenu.xaml
    /// </summary>
    public partial class pgMenu : Page
    {
        BDDSingleton _bdd = BDDSingleton.Instance;
        ICollectionView _listeMenu;

        public pgMenu()
        {
            InitializeComponent();
            _listeMenu = CollectionViewSource.GetDefaultView(_bdd.Menus);
            grpListeMenus.DataContext = _listeMenu;
        }

        private void AjouterMenu(object sender, RoutedEventArgs e)
        {
            Statics.TryCatch(() => { lvMenus.SelectedItem = _bdd.AjouterMenu("Nouvelle Entree", "Nouveau Repas","Nouveau Dessert","Nouvelle Boisson"); }, nameof(AjouterMenu));
        }

        private void SupprimerMenu(object sender, RoutedEventArgs e)
        {
            Menu_ selection = (Menu_)lvMenus.SelectedItem;
            if (selection != null)
            {
                if (MessageBox.Show($"Etes-vous sur de vouloir supprimer le Menu {selection.Entree} de la liste ?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    Statics.TryCatch(() => { _bdd.SupprimerMenu(selection); }, nameof(SupprimerMenu));
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
            _listeMenu.SortDescriptions.Clear();

            if (ColumnHeader == _sortColumnHeader)
            {
                _sortDirection = (_sortDirection == ListSortDirection.Ascending ? ListSortDirection.Descending : ListSortDirection.Ascending);
            }
            else
            {
                _sortDirection = ListSortDirection.Ascending;
                _sortColumnHeader = ColumnHeader;
            }

            _listeMenu.SortDescriptions.Add(new SortDescription(_sortColumnHeader.Tag.ToString(), _sortDirection));
        }
        #endregion
    }
}
