using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace design_pattern_evaluation.DesignPattern
{

    public interface IReservationDecoration
    {
        void Decorate(Reservation reservation);
    }
    public class Reservation
    {
        string name { get; set; }

        List<Option> options = new List<Option>();
        public Reservation(string name)
        {
            this.name = name;
        }

        public void afficher()
        {
            Console.WriteLine($"{name}");
        }

        public void afficherOptions()
        {
            if (options.Count() == 0)
            {
                Console.WriteLine("Aucune option ajouté");
            } else
            {
                foreach (Option option in options)
                {
                    Console.WriteLine(option.getOption());
                }
            }
        }

        public void addOption(Option option)
        {
            options.Add(option);
        }
    }

    public class Option : IReservationDecoration
    {
        string option;
        public Option(string option)
        {
            this.option = option;
        }
        public string getOption()
        {
            return option;
        }

        public void Decorate(Reservation reservation)
        {
            Console.WriteLine($"On ajoute l'option : {option}");
            reservation.addOption(this);
        }
    }
}
