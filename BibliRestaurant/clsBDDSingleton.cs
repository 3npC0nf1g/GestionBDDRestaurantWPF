
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.ObjectModel;

namespace BibliRestaurantBDD
{
    public class BDDSingleton
    {
        #region Propriétés représentant la Base de données ou la rendant accessible à l'extérieur du projet
        public static BDDSingleton Instance { get; private set; } = new BDDSingleton();
        private BDDRestaurant BDD { get; set; }
        #endregion

        #region Propriétés
        public bool ModificationsEnAttente => BDD?.ChangeTracker.HasChanges() ?? false;
        #endregion

        #region Tables de la BDD (sous forme de ReadOnlyObservableCollection)
        public ReadOnlyObservableCollection<Menu_> Menus { get; private set; }
        public ReadOnlyObservableCollection<Client> Clients { get; private set; }
        public ReadOnlyObservableCollection<Reservation> Reservations { get; private set; }
        public ReadOnlyObservableCollection<SouhaiteAvoir> SouhaiteAvoir { get; private set; }
        public ReadOnlyObservableCollection<Table_> Tables { get; private set; }
        public ReadOnlyObservableCollection<Zone> Zones { get; private set; }
        #endregion

        #region Constructeur de la classe
        public BDDSingleton()
        {
            BDD = new BDDRestaurant();
            BDD.Database.EnsureCreated();
            BDD.Menus.Load();
            Menus = new ReadOnlyObservableCollection<Menu_>(BDD?.Menus.Local.ToObservableCollection());
            BDD.Clients.Load();
            Clients = new ReadOnlyObservableCollection<Client>(BDD?.Clients.Local.ToObservableCollection());
            BDD.Reservations.Load();
            Reservations = new ReadOnlyObservableCollection<Reservation>(BDD?.Reservations.Local.ToObservableCollection());
            BDD.SouhaiteAvoir.Load();
            SouhaiteAvoir = new ReadOnlyObservableCollection<SouhaiteAvoir>(BDD?.SouhaiteAvoir.Local.ToObservableCollection());
            BDD.Tables.Load();
            Tables = new ReadOnlyObservableCollection<Table_>(BDD?.Tables.Local.ToObservableCollection());
            BDD.Zones.Load();
            Zones = new ReadOnlyObservableCollection<Zone>(BDD?.Zones.Local.ToObservableCollection());
        }
        #endregion

        #region Méthodes permettant d'ajouter/d'enlever des données dans les tables de la BDD
        public Menu_ AjouterMenu(string entree, string repas, string dessert, string boisson) { return BDD?.AjouterMenu(entree, repas, dessert, boisson); }
        public Client AjouterClient(string nomprenom, string email, int nombrepersonne, string numerotelephone) { return BDD?.AjouterClient(nomprenom, email, nombrepersonne, numerotelephone); }
        public SouhaiteAvoir AjouterSouhaiteAvoir(Client client, Reservation reservation, Menu_ menu) { return BDD?.AjouterSouhaiteAvoir(client, reservation, menu); }
        public Reservation AjouterReservation(int nombrepersonne, DateTime dateheure, bool manque, Table_ table, Client client) { return BDD?.AjouterReservation(nombrepersonne, dateheure, manque, table, client); }
        public Table_ AjouterTable(int nombreplace, Zone zone) { return BDD?.AjouterTable(nombreplace, zone); }
        public Zone AjouterZone(string description, bool fumeur) { return BDD?.AjouterZone(description, fumeur); }
        public void SupprimerMenu(Menu_ menu) { BDD?.SupprimerMenu(menu); }
        public void SupprimerClient(Client client) { BDD?.SupprimerClient(client); }
        public void SupprimerSouhaiteAvoir(SouhaiteAvoir souhaiteavoir) { BDD?.SupprimerSouhaiteAvoir(souhaiteavoir); }
        public void SupprimerReservation(Reservation reservation) { BDD?.SupprimerReservation(reservation); }
        public void SupprimerTable(Table_ table) { BDD?.SupprimerTable(table); }
        public void SupprimerZone(Zone zone) { BDD?.SupprimerZone(zone); }
        #endregion

        #region Méthodes effectuant des modifications/actions plus spécifiques sur les données
        public void SauvegarderModifications() { BDD?.SaveChanges(); }
        #endregion
    }
}
