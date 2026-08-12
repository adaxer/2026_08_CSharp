using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    public abstract class Lebewesen { }

    //Ein INTERFACE zwingt die implementierenden Klassen bestimmte Methoden und Eigenschaften zu implementieren, so dass diesbezüglich 
    ///eine Typsicherheit besteht. Dieses Interface fordert die Implementierung einer Methode und einer Eigenschaft und ermöglicht
    ///einer Klasse 'einer Arbeit nachzugehen'.
    interface IArbeit
    {
        //In einem Interface sind idR keine Zugriffsmodifier erlaubt
        int Gehalt { get; set; }

        string Job { get; set; }

        //Es werden (wie bei abstarkten Methoden) idR nur die Methodenköpfe geschrieben. Der Rest wird in den implementierenden Klassen hinzugefügt
        void Auszahlung();
    }

    //Arbeitnehmer implementiert Interfaces, welche dieser Klasse zusätzliche Eigenschaften verleihen
    public class Mensch : Lebewesen, IArbeit, ICloneable
    {
        #region Modul 06-09
        //Demo M10 basiert auf Demo M09
        #endregion

        //Durch IArbeit verlangte Eigenschaften
        public int Gehalt { get; set; } = 3500;
        public string Job { get; set;}

        //Ducrh IArbeit verlangte Methode
        public void Auszahlung()
        {
            Console.WriteLine($"{this.Vorname} {this.Nachname} hat {this.Gehalt}€ für {this.Job} bekommen.");
        }

        //Durch IClonable verlangte Methode (Bsp für .NET-eigenes Interface)
        ///Diese Methode erlaubt die Erstellung einer Kopie dieses Objekts
        public object Clone()
        {
            //Durch .MemberwiseClone() werden alle Wertetypen des Originalobjekts kopiert
            Mensch neuerMensch = (Mensch)this.MemberwiseClone();
            //Referenzen müssen manuell neu zugewiesen werden oder ebenfalls über IClonable verfügen und durch .Clone() kopiert werden
            neuerMensch.Mutter = this.Mutter;
            return neuerMensch;
        }

        //Alternativ zu IClonable kann ein Kopierkonstruktor zur Dublizierung verwendet werden. Hier werden die Werte und Referenzen koiert und übertragen
        public Mensch(Mensch alterMensch)
        {
            this.Vorname = alterMensch.Vorname;
            this.Name = alterMensch.Name;
            //...
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            #region Modul 06-08
            //Demo M09 basiert auf Demo M08
            #endregion

            #region Modul 10: Interfaces

            //Instanziierung eines Beispiel-Objekts
            Mensch mensch = new Mensch("Anna", "Meier", "Lasagne", new DateTime(1984, 5, 6));
            //Betrachtung des Objekts als Objekt des Interfaces
            IArbeit arbeitendesObjekt = mensch;
            //Zugriff auf Interface-Methode
            arbeitendesObjekt.Auszahlung();
            //Übergabe an Methode, welche ein Objekt des Interfaces erwartet
            Gehaltserhöhung(arbeitendesObjekt);
            //Übergabe benötigt keinen Cast aus implementierender Klasse
            Gehaltserhöhung(mensch);

            //Aufruf der Clone()-Funktion des IClonable-Interfaces
            Mensch kopierterMensch = (Mensch)mensch.Clone();
            #endregion
        }

        //Bsp-Methode, welche ein Objekt vom Typ des Interfaces verlangt
        public static void Gehaltserhöhung(IArbeit arbeitendesObjekt)
        {
            arbeitendesObjekt.Gehalt += 100;

            //Prüfung des Objekts auf Laufzeittyp
            if (arbeitendesObjekt is Mensch)
            {
                //Cast
                Mensch mensch = (Mensch)arbeitendesObjekt;
                mensch.Essen();
            }
        }
    }
}
