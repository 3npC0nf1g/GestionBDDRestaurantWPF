
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using BibliRestaurantBDD;


namespace BibliWPF
{
    /// <summary>
    /// Logique d'interaction pour fenPrincipale.xaml
    /// </summary>
    public partial class fenPrincipale : Window
    {
        private BDDSingleton BDD = BDDSingleton.Instance;
        public fenPrincipale()
        {
            InitializeComponent();
            //Affichage d'un cadre par défaut.
            Cadre.NavigationService.Navigate(new pgMenu());
        }

        #region Méthodes liées au Menu du haut de la fenêtre
        private void AfficherMenu(object sender, RoutedEventArgs e) { Cadre.NavigationService.Navigate(new pgMenu()); }
        private void AfficherClients(object sender, RoutedEventArgs e) { Cadre.NavigationService.Navigate(new pgClients()); }
        private void AfficherReservations(object sender, RoutedEventArgs e) { Cadre.NavigationService.Navigate(new pgReservations()); }
        private void AfficherTables(object sender, RoutedEventArgs e) { Cadre.NavigationService.Navigate(new PgTables()); }
        private void AfficherZones(object sender, RoutedEventArgs e) { Cadre.NavigationService.Navigate(new pgZones()); }
        private void AfficherSouhaiteAvoir(object sender, RoutedEventArgs e) { Cadre.NavigationService.Navigate(new pgSouhaiteAvoir()); }
        private void SauvegarderModifications(object sender, RoutedEventArgs e)
        {
            BDD.SauvegarderModifications();
            MessageBox.Show("Modifications sauvegardées dans la base de données.", "Sauvegarde des modifications", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        private void Quitter(object sender, RoutedEventArgs e) { this.Close(); }
        #endregion

        /// <summary>
        /// Méthode appelée une fois qu'une page a été chargée à l'écran.
        /// Efface l'historique de navigation (les anciennes pages chargées) de la mémoire.
        /// </summary>
        private void NavServiceOnNavigated(object sender, System.Windows.Navigation.NavigationEventArgs e) { while (Cadre.NavigationService.RemoveBackEntry() != null) ; }
        private void OnClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (BDD.ModificationsEnAttente)
            {
                if (MessageBox.Show("Il y a des modifications en attente voulez vous les sauvegarder avant de quitter ?", "Application GestionPAE", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
                {
                    if (MessageBox.Show("La fermeture de l'application va entrainer la perte des modifications non sauvegardées dans la base de données. Etes-vous sûr de vouloir fermer l'application?", "Application GestionPAE", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
                    {
                        e.Cancel = true;
                    }
                }
                else { BDD.SauvegarderModifications(); }
            }
        }
    }
}