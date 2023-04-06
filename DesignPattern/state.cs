using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace design_pattern_evaluation.DesignPattern
{
    public class Inscription
    {
        public Etape etat { get; set; }
        public Inscription()
        {
            this.etat = new Name();
        }

        public void Suivant()
        {
            this.etat.Suivant(this);
        }
        public void Precedent()
        {
            this.etat.Precedent(this);
        }
        public void GetEtape()
        {
            this.etat.GetEtape(this);
        }
    }

    public abstract class Etape
    {
        public abstract void GetEtape(Inscription inscription);
        public abstract void Suivant(Inscription inscription);
        public abstract void Precedent(Inscription inscription);
    }

    public class Name : Etape
    {
        public override void GetEtape(Inscription inscription)
        {
            Console.WriteLine("Je suis l'étape name");
        }
        public override void Suivant(Inscription inscription)
        {
            Console.WriteLine("Suivant...");
            inscription.etat = new Adresse();
        }
        public override void Precedent(Inscription inscription)
        {
            Console.WriteLine("Vous etes à la première étapes, vous ne pouvez pas revenir à l'étape précédente");
        }
    }

    public class Adresse : Etape
    {
        public override void GetEtape(Inscription inscription)
        {
            Console.WriteLine("Je suis l'étape adresse");
        }
        public override void Suivant(Inscription inscription)
        {
            Console.WriteLine("Suivant...");
            inscription.etat = new Paiement();
        }
        public override void Precedent(Inscription inscription)
        {
            Console.WriteLine("Précédent...");
            inscription.etat = new Name();
        }
    }

    public class Paiement : Etape
    {
        public override void GetEtape(Inscription inscription)
        {
            Console.WriteLine("Je suis l'étape paiement");
        }
        public override void Suivant(Inscription inscription)
        {
            Console.WriteLine("Vous etes à la dernière étapes, vous ne pouvez pas aller à l'étape suivante");
        }
        public override void Precedent(Inscription inscription)
        {
            Console.WriteLine("Précédent...");
            inscription.etat = new Paiement();
        }
    }
}
