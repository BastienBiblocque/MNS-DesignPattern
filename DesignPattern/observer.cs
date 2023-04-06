using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace design_pattern_evaluation.DesignPattern
{
    public interface Partenaire
    {
        public void notificationManager(string motif);
    }

    public class VuePartenaire : Partenaire
    {
        public string name;

        public string getName()
        {
            return name;
        }

        public VuePartenaire(string name)
        {
            this.name = name;
        }

        public void notificationManager(string motif)
        {
            Console.WriteLine($"Message de {name} :");
            Console.WriteLine($"Une nouvelle notification à été recu, motif : {motif}");
        }
    }

    public class Sujet
    {
        protected List<Partenaire> partenaires;

        public Sujet()
        {
            partenaires = new List<Partenaire>();
        }

        public void addPartenaire(VuePartenaire partenaire)
        {
            Console.WriteLine($"Le partenaire {partenaire.getName()} a été ajouté");
            partenaires.Add(partenaire);
        }

        public void removePartenaire(VuePartenaire partenaire)
        {
            Console.WriteLine($"Le partenaire {partenaire.getName()} a été supprimé");
            partenaires.Remove(partenaire);
        }

        public void notifie(string motif)
        {
            Console.WriteLine("On envoie la notif");
            foreach (Partenaire partenaire in partenaires)
            {
                partenaire.notificationManager(motif);
            }
        }
    }

    public class ReservationObserver : Sujet
    {
        protected string nom;
        protected int prix;

        public ReservationObserver(string nom, int prix)
        {
            this.nom = nom;
            this.prix = prix;
            VuePartenaire airbus = new VuePartenaire("Airbus");
            this.partenaires.Add(airbus);
            VuePartenaire Boeing = new VuePartenaire("Boeing");
            this.partenaires.Add(Boeing);
            notifie("Création");
        }
        public void setPrix(int prix)
        {
            this.prix = prix;
            notifie("Modification prix");
        }
    }
}
