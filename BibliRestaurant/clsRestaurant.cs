using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BibliRestaurantBDD
{
    internal class BDDRestaurant : DbContext
    {
        #region Tables de la BDD
        internal DbSet<Menu_> Menus { get; set; }
        internal DbSet<Client> Clients { get; set; }
        internal DbSet<Reservation> Reservations { get; set; }
        internal DbSet<SouhaiteAvoir> SouhaiteAvoir { get; set; }
        internal DbSet<Table_> Tables { get; set; }
        internal DbSet<Zone> Zones { get; set; }
        #endregion

        #region Méthodes d'initialisation de la base de données
        /// <summary>
        /// Méthode de configuration de la connexion à la base de données.
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($@"Data Source={Path.Combine(Directory.GetCurrentDirectory(), "BDDBibliotheque.db")}");
        }

        /// <summary>
        /// Méthode contenant le code lié aux contraintes du modèle de données et aux données présentes par défaut
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Contraintes liées au modèle de la BDD
            //Pour une table provenant d'une association il vaut mieux préciser la clé primaire, qui est ici la combinaison des deux clés étrangères
            modelBuilder.Entity<SouhaiteAvoir>().HasKey(sc => new { sc.ClientID, sc.ReservationID, sc.MenuID });
          
            #endregion

            #region Données présentes par défaut dans la BDD
            modelBuilder.Entity<Menu_>().HasData(

                new Menu_() { ID = 1,  Entree = "Salade de fruit",            Repas = "Ndolè",              Dessert = "Mousse aux fruits rouges",   Boisson = "Fanta" },
                new Menu_() { ID = 2,  Entree = "Velouté de petits pois",     Repas = "Poulet DG",          Dessert = "Carrot Cake",                Boisson = "Coca" },
                new Menu_() { ID = 3,  Entree = "Soupe de patates douces",    Repas = "Le poisson braisé",  Dessert = "Gâteau au thé matcha",       Boisson = "Sprite" },
                new Menu_() { ID = 4,  Entree = "Salade de fruit",            Repas = "Ndolè",              Dessert = "Gâteau au chocolat",         Boisson = "Anana" },
                new Menu_() { ID = 5,  Entree = "Tarte feuilletée pomme",     Repas = "Le poisson braisé",  Dessert = "Mousse aux fruits rouges",   Boisson = "Pemplemouss" },
                new Menu_() { ID = 6,  Entree = "Nems au four",               Repas = "Ndolè",              Dessert = "Gâteau au praliné",          Boisson = "Fanta" },
                new Menu_() { ID = 7,  Entree = "Croque-Monsieur au caramel", Repas = "Kondrè",             Dessert = "Gâteau au thé matcha",       Boisson = "Coca" },
                new Menu_() { ID = 8,  Entree = "Nems au four",               Repas = "Poulet DG",          Dessert = "Blondie au sorbet",          Boisson = "Sprite" },
                new Menu_() { ID = 9,  Entree = "Salade de fruit",            Repas = "Sanga",              Dessert = "Carrot Cake",                Boisson = "Pemplemouss" },
                new Menu_() { ID = 10, Entree = "Tarte feuilletée pomme",     Repas = "Le Nkui",            Dessert = "Gâteau au praliné",          Boisson = "Anana" },
                new Menu_() { ID = 11, Entree = "Nems au four",               Repas = "Ndolè",              Dessert = "Gâteau au chocolat",         Boisson = "Pemplemouss" },
                new Menu_() { ID = 12, Entree = "Velouté de petits pois",     Repas = "Kondrè",             Dessert = "Cheesecake",                 Boisson = "Anana" },
                new Menu_() { ID = 13, Entree = "Soupe de patates douces",    Repas = "Eru",                Dessert = "Mousse aux fruits rouges",   Boisson = "Fanta" },
                new Menu_() { ID = 14, Entree = "Salade de fruit",            Repas = "Koki",               Dessert = "Blondie au sorbet",          Boisson = "Coca" },
                new Menu_() { ID = 15, Entree = "Croque-Monsieur au caramel", Repas = "Okok",               Dessert = "Cheesecake",                 Boisson = "Sprite" } 
            );

            modelBuilder.Entity<Client>().HasData(

               new Client() { ID = 1, NomPrenom = "Fontaine Jesper",       Email = "JesperFontaine@dayrep.com",          NombrePersonne = 4 },
               new Client() { ID = 2,  NomPrenom = "Leroy Violette",       Email = "VioletteLeroy@fai.com",              NombrePersonne = 2 },
               new Client() { ID = 3,  NomPrenom = "Favreau Fantine",      Email = "FantinaFavreau@fai.com",             NombrePersonne = 4 },
               new Client() { ID = 4,  NomPrenom = "Flordelis Mathieu",    Email = "CarolosGabriaux@fai.com",            NombrePersonne = 7 },
               new Client() { ID = 5,  NomPrenom = "Mavise  Michel",       Email = "PercyPanetier@rhyta.com",            NombrePersonne = 7 },
               new Client() { ID = 6,  NomPrenom = "Marcoux Désiré",       Email = "MaximeScholten@jourrapide.com",      NombrePersonne = 2 },
               new Client() { ID = 7,  NomPrenom = "Ayot Jacques",         Email = "DesireMarcoux@jourrapide.com",       NombrePersonne = 4 },
               new Client() { ID = 8,  NomPrenom = "Pannetier Percy",      Email = "ChristabelBoncoeur@fai.com",         NombrePersonne = 7 },
               new Client() { ID = 9,  NomPrenom = "Boncoeur Christabel",  Email = "CarolosGabriaux@fai.com",            NombrePersonne = 7 },
               new Client() { ID = 10, NomPrenom = "Paré Natalie",         Email = "ChristabelBoncoeur@fai.com",         NombrePersonne = 6 },
               new Client() { ID = 11, NomPrenom = "Carolos Gabriel",      Email = "PercyPanetier@rhyta.com",            NombrePersonne = 2 },
               new Client() { ID = 12, NomPrenom = "Rep  Aniel",           Email = "CarolosGabriaux@fai.com",            NombrePersonne = 4 },
               new Client() { ID = 13, NomPrenom = "Levijn Gianna",        Email = "DesireMarcoux@jourrapide.com",       NombrePersonne = 7 },
               new Client() { ID = 14, NomPrenom = "Scholten Maxime",      Email = "MaximeScholten@jourrapide.com",      NombrePersonne = 7 },
               new Client() { ID = 15, NomPrenom = "Favreau Julie",        Email = "MaximeScholten@jourrapide.com",      NombrePersonne = 7 }
               
               );


            modelBuilder.Entity<Reservation>().HasData(

              new Reservation() { ID = 1, Manque = true,  NombrePersonne = 6,  DateHeure = DateTime.Today.AddDays(1), ClientID = 5, TableID =8},
              new Reservation() { ID = 2, Manque = true,  NombrePersonne = 2 , DateHeure = DateTime.Today.AddDays(1), ClientID = 5, TableID =8}, 
              new Reservation() { ID = 3, Manque = true,  NombrePersonne = 4 , DateHeure = DateTime.Today.AddDays(1), ClientID = 5, TableID =8}, 
              new Reservation() { ID = 4, Manque = true,  NombrePersonne = 7 , DateHeure = DateTime.Today.AddDays(1), ClientID = 5, TableID =8}, 
              new Reservation() { ID = 5, Manque = true,  NombrePersonne = 7 , DateHeure = DateTime.Today.AddDays(1), ClientID = 5, TableID =8}, 
              new Reservation() { ID = 6, Manque = true,  NombrePersonne = 2 , DateHeure = DateTime.Today.AddDays(1), ClientID = 5, TableID =8}, 
              new Reservation() { ID = 7, Manque = true,  NombrePersonne = 4 , DateHeure = DateTime.Today.AddDays(1), ClientID = 5, TableID =8}, 
              new Reservation() { ID = 8, Manque = true,  NombrePersonne = 7 , DateHeure = DateTime.Today.AddDays(1), ClientID = 5, TableID =8}, 
              new Reservation() { ID = 9, Manque = true,  NombrePersonne = 7 , DateHeure = DateTime.Today.AddDays(1), ClientID = 5, TableID =8}, 
              new Reservation() { ID = 10,Manque = true,  NombrePersonne = 6 , DateHeure = DateTime.Today.AddDays(1), ClientID = 5, TableID =8}, 
              new Reservation() { ID = 11,Manque = true,  NombrePersonne = 2 , DateHeure = DateTime.Today.AddDays(1), ClientID = 5, TableID =8}, 
              new Reservation() { ID = 12,Manque = true,  NombrePersonne = 4 , DateHeure = DateTime.Today.AddDays(1), ClientID = 5, TableID =8}, 
              new Reservation() { ID = 13,Manque = true,  NombrePersonne = 7 , DateHeure = DateTime.Today.AddDays(1), ClientID = 5, TableID =8}, 
              new Reservation() { ID = 14,Manque = true,  NombrePersonne = 7 , DateHeure = DateTime.Today.AddDays(1), ClientID = 5, TableID =8}, 
              new Reservation() { ID = 15,Manque = true,  NombrePersonne = 7 , DateHeure = DateTime.Today.AddDays(1), ClientID = 5, TableID =8}
               );

            modelBuilder.Entity<SouhaiteAvoir>().HasData(

                new SouhaiteAvoir() { ClientID = 1,  ReservationID = 1, MenuID = 7, },
                new SouhaiteAvoir() { ClientID = 2,  ReservationID = 1, MenuID = 7, },
                new SouhaiteAvoir() { ClientID = 3,  ReservationID = 1, MenuID = 7, },
                new SouhaiteAvoir() { ClientID = 4,  ReservationID = 2, MenuID = 7, },
                new SouhaiteAvoir() { ClientID = 5,  ReservationID = 2, MenuID = 7, },
                new SouhaiteAvoir() { ClientID = 6,  ReservationID = 2, MenuID = 7, },
                new SouhaiteAvoir() { ClientID = 7,  ReservationID = 1, MenuID = 7, },
                new SouhaiteAvoir() { ClientID = 8,  ReservationID = 1, MenuID = 7, },
                new SouhaiteAvoir() { ClientID = 9,  ReservationID = 1, MenuID = 7, },
                new SouhaiteAvoir() { ClientID = 10, ReservationID = 2, MenuID = 7, },
                new SouhaiteAvoir() { ClientID = 11, ReservationID = 2, MenuID = 7, },
                new SouhaiteAvoir() { ClientID = 12, ReservationID = 2, MenuID = 7, },
                new SouhaiteAvoir() { ClientID = 13, ReservationID = 1, MenuID = 7, },
                new SouhaiteAvoir() { ClientID = 14, ReservationID = 1, MenuID = 7, },
                new SouhaiteAvoir() { ClientID = 15, ReservationID = 1, MenuID = 7, }
             
            ); modelBuilder.Entity<Table_>().HasData(

                new Table_() { ID = 1,  ZoneID = 1, NombrePlace = 7, },
                new Table_() { ID = 2,  ZoneID = 1, NombrePlace = 7, },
                new Table_() { ID = 3,  ZoneID = 1, NombrePlace = 7, },
                new Table_() { ID = 4,  ZoneID = 2, NombrePlace = 7, },
                new Table_() { ID = 5,  ZoneID = 2, NombrePlace = 7, },
                new Table_() { ID = 6,  ZoneID = 2, NombrePlace = 7, },
                new Table_() { ID = 7,  ZoneID = 1, NombrePlace = 7, },
                new Table_() { ID = 8,  ZoneID = 1, NombrePlace = 7, },
                new Table_() { ID = 9,  ZoneID = 1, NombrePlace = 7, },
                new Table_() { ID = 10, ZoneID = 2, NombrePlace = 7, },
                new Table_() { ID = 11, ZoneID = 2, NombrePlace = 7, },
                new Table_() { ID = 12, ZoneID = 2, NombrePlace = 7, },
                new Table_() { ID = 13, ZoneID = 1, NombrePlace = 7, },
                new Table_() { ID = 14, ZoneID = 1, NombrePlace = 7, },
                new Table_() { ID = 15, ZoneID = 1, NombrePlace = 9, }
             
            );
     
            modelBuilder.Entity<Zone>().HasData(

                new Zone() { ID = 1,  Description = "Térasse" ,           Fumeur = false, },
                new Zone() { ID = 2,  Description = "Près du bar" ,       Fumeur = false, },
                new Zone() { ID = 3,  Description = "près de la sortie" , Fumeur = false, },
                new Zone() { ID = 4,  Description = "Mezzanine" ,         Fumeur = false, },
                new Zone() { ID = 5,  Description = "Entreé" ,            Fumeur = false, },
                new Zone() { ID = 6,  Description = "Mezzanine" ,         Fumeur = false, },
                new Zone() { ID = 7,  Description = "Térasse" ,           Fumeur = false, },
                new Zone() { ID = 8,  Description = "Près du bar" ,       Fumeur = false, },
                new Zone() { ID = 9,  Description = "près de la sortie" , Fumeur = false, },
                new Zone() { ID = 10, Description = "Entreé" ,            Fumeur = false, },
                new Zone() { ID = 11, Description = "Mezzanine" ,         Fumeur = false, },
                new Zone() { ID = 12, Description = "Entreé" ,            Fumeur = false, },
                new Zone() { ID = 13, Description = "Térasse" ,           Fumeur = false, },
                new Zone() { ID = 14, Description = "Près du bar" ,       Fumeur = false, },
                new Zone() { ID = 15, Description = "près de la sortie" , Fumeur = false, }
             
            );
            #endregion


        }
        #endregion

        #region Méthodes permettant d'ajouter/d'enlever des données dans les tables de la BDD
        internal Menu_ AjouterMenu(string entree, string repas, string dessert, string boisson)
        {
            //Gestion des erreurs
            if (entree == null || entree == string.Empty) { throw new ArgumentNullException($"{nameof(AjouterMenu)} : Le Menu doit avoir une entrée (valeur NULL ou chaine vide)."); }
            if (repas == null || repas == string.Empty) { throw new ArgumentNullException($"{nameof(AjouterMenu)} : Le Menu doit avoir une repas (valeur NULL ou chaine vide)."); }
            if (dessert == null || dessert == string.Empty) { throw new ArgumentNullException($"{nameof(AjouterMenu)} : Le Menu doit avoir une dessert (valeur NULL ou chaine vide)."); }
            if (boisson == null || boisson == string.Empty) { throw new ArgumentNullException($"{nameof(AjouterMenu)} : Le Menu doit avoir une boisson (valeur NULL ou chaine vide)."); }

            //Ajout d'un nouveau Menu 
            Menu_ lMenu = new() { Entree = entree, Repas = repas, Dessert = dessert, Boisson = boisson };
            Menus.Local.Add(lMenu);
            return lMenu;
        }
        internal Client AjouterClient(string nomprenom, string email, int nombrepersonne)
        {
             int NombrePersonnesMIN = 1;
             int NombrePersonnesMAX = 8;

            //Gestion des erreurs
            if (nomprenom == null || nomprenom == string.Empty) { throw new ArgumentNullException($"{nameof(AjouterClient)} : Le client doit avoir un nom et un prenom (valeur NULL ou chaine vide)."); }
            if(email == null || email == string.Empty) { throw new ArgumentNullException("L'email ne peut pas être une valeur vide !"); }
            if(!email.Contains("@")) { throw new ArgumentException("L'email doit contenir au moins un @ !"); }
            if (nombrepersonne < NombrePersonnesMIN || nombrepersonne > NombrePersonnesMAX) { throw new ArgumentException($"Le numéro de personne doit être compris entre {NombrePersonnesMIN} et {NombrePersonnesMAX}."); }
          

            //Ajout du nouveau client
            Client lClient = new() { NomPrenom = nomprenom, Email = email, NombrePersonne = nombrepersonne };
            Clients.Local.Add(lClient);
            return lClient;
        }
        internal Reservation AjouterReservation(int nombrepersonne, DateTime dateheure, bool manque, Table_ table, Client client)
        {
            int NombrePersonnesMIN = 1;
            int NombrePersonnesMAX = 8;
            DateTime DateReservationMAX = DateTime.Today.AddYears(1);


            //Gestion des erreurs.
            if (nombrepersonne < NombrePersonnesMIN || nombrepersonne > NombrePersonnesMAX) { throw new ArgumentException($"Le numéro de personne doit être compris entre {NombrePersonnesMIN} et {NombrePersonnesMAX}."); }
            if (dateheure < DateTime.Today.AddDays(1)) throw new ArgumentException($"Pas de Reservations disponible avant demain.");
            if (client == null) { throw new ArgumentNullException($"{nameof(AjouterReservation)} : La reservation doit avoir un client (valeur NULL)."); }
            if (table == null) { throw new ArgumentNullException($"{nameof(AjouterReservation)} : La reservation  doit avoir une table (valeur NULL)."); }


           
            //Ajout d'une nouvelle réservation.
            Reservation lReservation = new() { NombrePersonne = nombrepersonne , DateHeure = dateheure , Table = table , Client = client };
            Reservations.Local.Add(lReservation);
            return lReservation;
        }
        internal SouhaiteAvoir AjouterSouhaiteAvoir(Client client, Reservation reservation, Menu_ menu)
        {
            //Gestion des erreurs.
            if (client == null) { throw new ArgumentNullException($"{nameof(AjouterSouhaiteAvoir)} : Il faut un client pour le lien client/reservation/menu (valeur NULL)."); }
            if (reservation == null) { throw new ArgumentNullException($"{nameof(AjouterSouhaiteAvoir)} : Il faut un reservation pour le lien client/reservation/menu (valeur NULL)."); }
            if (menu == null) { throw new ArgumentNullException($"{nameof(AjouterSouhaiteAvoir)} : Il faut un menu pour le lien client/reservation/menu (valeur NULL)."); }
            if (SouhaiteAvoir.Local.FirstOrDefault(shtavr => shtavr.ClientID == client.ID && shtavr.ReservationID == reservation.ID && shtavr.MenuID == menu.ID) != null)
            { throw new InvalidOperationException($"{nameof(AjouterSouhaiteAvoir)} : Le lien écrire existe déjà."); }

            //Ajout du nouveau lien souhaiteavoir (client/reservation/menu).
            SouhaiteAvoir lSouhaiteAvoir = new() { Client = client , Reservation = reservation, Menu = menu};
            SouhaiteAvoir.Local.Add(lSouhaiteAvoir);
            return lSouhaiteAvoir;
        }
        internal Table_ AjouterTable(int nombreplace, Zone zone)
        {
           int NombrePlaceMIN = 1;
           int NombrePlaceMAX = 8;

            //Gestion des erreurs
            if (nombreplace < NombrePlaceMIN || nombreplace > NombrePlaceMAX) { throw new ArgumentException($"Le nombre de places doit être compris entre {NombrePlaceMIN} et {NombrePlaceMAX}."); }
            if (zone == null) { throw new ArgumentNullException($"{nameof(AjouterTable)} : La table doit avoir une zone (valeur NULL)."); }

            //Ajout d'une nouvelle table
            Table_ lTable = new() { Zone = zone, NombrePlace = nombreplace };
            Tables.Local.Add(lTable);
            return lTable;
        }
        internal Zone AjouterZone(string description, bool fumeur)
        {
            //Gestion des erreurs
            if (description == null || description == string.Empty) { throw new ArgumentNullException($"{nameof(AjouterZone)} : La Zone doit avoir une description (valeur NULL ou chaine vide)."); }

            //Ajout de la nouvelle Zone
            Zone lZone = new() { Description = description, Fumeur = fumeur };
            Zones.Local.Add(lZone);
            return lZone;
        }

        internal void SupprimerMenu(Menu_ menu)
        {
            //Gestion des erreurs
            if (menu == null) { throw new ArgumentNullException($"{nameof(SupprimerMenu)} : Il faut un menu en argument (valeur NULL)."); }

            //Suppression du menu
            Menus.Local.Remove(menu);
        }
        internal void SupprimerClient(Client client)
        {
            //Gestion des erreurs
            if (client == null) { throw new ArgumentNullException($"{nameof(SupprimerClient)} : Il faut un client en argument (valeur NULL)."); }

            

            //Suppression du client
            Clients.Local.Remove(client);
        }
        internal void SupprimerReservation(Reservation reservation)
        {
            //Gestion des erreurs
            if (reservation == null) { throw new ArgumentNullException($"{nameof(SupprimerReservation)} : Il faut un lien ecrire(livre/auteur) en argument (valeur NULL)."); }

            //Suppression de la reservation
            Reservations.Local.Remove(reservation);
        }
        internal void SupprimerSouhaiteAvoir(SouhaiteAvoir souhaiteavoir)
        {
            //Gestion des erreurs
            if (souhaiteavoir == null) { throw new ArgumentNullException($"{nameof(SupprimerSouhaiteAvoir)} : Il faut un lien ecrire(livre/auteur) en argument (valeur NULL)."); }

            //Suppression du SouhaiteAvoir
            SouhaiteAvoir.Local.Remove(souhaiteavoir);
        }
        internal void SupprimerTable(Table_ table)
        {
            //Gestion des erreurs
            if (table == null) { throw new ArgumentNullException($"{nameof(SupprimerTable)} : Il faut un livre en argument (valeur NULL)."); }

        

            //Suppression de la table.
            Tables.Local.Remove(table);
        }
        internal void SupprimerZone(Zone zone)
        {
            //Gestion des erreurs
            if (zone == null) { throw new ArgumentNullException($"{nameof(SupprimerZone)} : Il faut une ville en argument (valeur NULL)."); }

            //Suppression de la zone.
            Zones.Local.Remove(zone);
        }
        #endregion
    }
}
