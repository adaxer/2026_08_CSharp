using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    public class Lebewesen
    {
        #region Modul 06-07
        //Demo M08 basiert auf Demo M07
        #endregion


        //Mittels OVERRIDE können Methoden der Mutterklassen, welche mit VIRTUAL markiert sind, überschrieben werden. Bei Aufruf wird die neue Methode ausgeführt.
        public override string ToString()
        {
            return $"{this.Name} ist {this.AlterInJahren} Jahre alt und mag gerne {this.Lieblingsnahrung}.";
        }

    }

    //Arbeitnehmer erbt mittels des :-Zeichens von der Person-Klasse und übernimmt somit alle Eigenschaften und Methoden von dieser.
    class Mensch : Lebewesen
    {
        //Zusätzliche Arbeitnehmer-eigene Eigenschaften
        public string Vorname { get; set; }
        public Mensch Mutter { get; set; }

        //Arbeitnehmer-Konstruktor, welcher per BASE-Stichwort den Konstruktor der Personklasse aufruft. Dieser erstellt dann eine Person, gibt diese
        ///an diesen Konstruktor zurück, welcher dann die zusätzlichen Eigenschaften einfügt
        public Mensch(string vorname, string nachname, string lieblingsnahrung,  DateTime geburtsdatum, Mensch mutter = null) : base(nachname, lieblingsnahrung, geburtsdatum)
        {
            this.Vorname = vorname;
            this.Mutter = mutter;
        }

        //Mittels OVERRIDE können Methoden der Mutterklassen, welche mit VIRTUAL markiert sind, überschrieben werden. Bei Aufruf wird die neue Methode ausgeführt.
        //Mittels BASE kann ein Rückbezug zur nächst-höheren Klasse hergestellt werden.
        //Mit SEALED kann eine Überschreibung durch Kindklassen verindert werden.
        public sealed override string ToString()
        {
            string ausgabe = $"Der Mensch {this.Vorname} " + base.ToString();
            if (this.Mutter != null)
                ausgabe = ausgabe + $" Die Mutter ist {this.Mutter.Vorname} {this.Mutter.Nachname}.";
            return ausgabe;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            #region Modul 06-07
            //Demo M08 basiert auf Demo M07
            #endregion

            #region Modul 08: Vererbung

            //Instanziierung eines Objekts der vererbenden Klasse
            Lebewesen lebewesen = new Lebewesen("Bello", "Fleisch" new DateTime(2007, 4, 23));
            //Instanziierung eines Objekts der abgeleiteten Klasse
            Mensch mensch = new Mensch("Anna", "Meier", "Lasagne", new DateTime(1984, 5, 6));
            Mensch mensch2 = new Mensch("Maria", "Meier", "Schnitzel", new DateTime(1997, 5, 6), mensch);
            //Aufruf von Properties und Methoden, welche aus der Mutterklasse stammen
            Console.WriteLine(mensch2.AlterInJahren);
            Console.WriteLine(mensch2.Name);

            //Ausgabe der (überschriebenen) ToString()-Methoden
            Console.WriteLine(lebewesen);
            Console.WriteLine(mensch);
            Console.WriteLine(mensch2);

            //Aufruf einer Property der abgeleiteten Klasse
            Console.WriteLine(mensch2.Vorname);

            //Aufruf einer Property eines abhängigen Objekts
            Console.WriteLine(mensch2.Mutter.AlterInJahren);

            #endregion
        }
    }
}
