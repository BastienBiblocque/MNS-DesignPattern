using System.Xml.Linq;
using design_pattern_evaluation.DesignPattern;

// State
// Problématique : Créer un système d'inscription avec plusieurs étapes. Il faut pouvoir naviguer entre chaque étapes.
// Solution : Le pattern State permet de resoudre ce soucis en encapsulant les étapes et permettant de naviguer entre elle grace à des fonctions obligatoire, déclarer préalablement dans le parent.
Console.WriteLine("_____STATE_____");

Inscription inscription = new Inscription();

inscription.Precedent(); // On essaye d'aller à l'étape 0
inscription.Suivant(); // On va à l'étape 2
inscription.Precedent(); // On reviens à l'étape 1
inscription.Suivant(); // On va à l'étape 2
inscription.Suivant(); // On va à l'étape 3
inscription.Suivant(); // On essayer d'aller à l'étape 4
inscription.GetEtape(); // On affiche l'étape en cours


// Decorator
// Problématique : Generer des options sur une préstation (voyage en avion)
// Solution : Le pattern decorator est une solution à ce problème, on va pouvoir ajouter des options à notre entité Reservation sans impacter celle-ci
Console.WriteLine("");
Console.WriteLine("_____DECORATOR_____");

Reservation reservation = new Reservation("Paris -> Osaka");
reservation.afficher();
reservation.afficherOptions();
var optionBagage = new Option("3 bagages");
optionBagage.Decorate(reservation);
reservation.afficherOptions();

var optionRepas = new Option("4 repas");
optionRepas.Decorate(reservation);
reservation.afficherOptions();


// Observer
// Problématique : A chaque reservation, on souhaite prévenir nos différents partenaire, on souhaite également les prévenir à chaque changement de prix.
// Solution : Le pattern Observer permet de dispatcher un evenement à chaque partenaire inscrit dans une liste de partenaire. Il permet d'éviter à chaque partenaire ayant besoin de l'information, de demander si une nouvelle reservation à était effectuer.
Console.WriteLine("");
Console.WriteLine("_____OBSERVER_____");

ReservationObserver reservationObserver = new ReservationObserver("Paris -> Toronto", 150);
VuePartenaire airfrance = new VuePartenaire("air france");
reservationObserver.addPartenaire(airfrance);
reservationObserver.setPrix(140);
reservationObserver.removePartenaire(airfrance);
