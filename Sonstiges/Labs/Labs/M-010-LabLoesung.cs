using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fahrzeugpark
{
    //Interface zur Definition einer 'Beladungsfähigkeit'
    interface IBeladbar
    {
        Fahrzeug Ladung { get; set; }

        void Belade(Fahrzeug fz);

        Fahrzeug Entlade();
    }

    public abstract class Fahrzeug { }

    //Durch die Implemetierung eines Interfaces können Objekte dieser Klasse auch als Objekte des Interfaces betrachtet werden
    public class Schiff : Fahrzeug, IBeladbar
    {
        #region Lab 06-01
        //Lab10 ist Erweiterung von Lab09
        #endregion

        //Durch IBeladbar verlangte Property
        public Fahrzeug Ladung { get; set; }

        public override string Info()
        {
            if (this.Ladung == null)
                return "Das Schiff " + base.Info() + $" Es fährt mit {this.Treibstoff}.";
            else
                return "Das Schiff " + base.Info() + $" Es fährt mit {this.Treibstoff} und transportiert '{this.Ladung.Name}'.";
        }

        //Durch IBeladbar verlangte Methoden
        public void Belade(Fahrzeug fz)
        {
            //Prüfung auf Gleichheit der Fahrzeuge
            if (this.Equals(fz))
            {
                Console.WriteLine("Das Fahrzeug kann sich nicht selber transportieren.");
            }
            //Prüfung, ob der Ladeplatz leer ist
            else if (this.Ladung == null)
            {
                //Übernehmen der Ladung
                this.Ladung = fz;
                //Erfolgsmeldung
                Console.WriteLine($"Ladevorgang von '{fz.Name}' auf '{this.Name}' erfolgreich.");
            }
            //Fehlermeldung
            else
                Console.WriteLine($"Ladeplatz auf '{this.Name}' bereits durch '{this.Ladung.Name}' belegt.");
        }

        public Fahrzeug Entlade()
        {
            //Prüfung, ob Ladung vorhanden ist
            if (this.Ladung != null)
            {
                //Zwischenspeichern zur Ausgabe
                Fahrzeug fz = this.Ladung;
                //Löschung der Ladung
                this.Ladung = null;
                //Erfolgsmeldung
                Console.WriteLine($"Entladevorgang von '{fz.Name}' erfolgreich.");
                return fz;
            }
            //Fehlermeldung
            else
                Console.WriteLine($"'{this.Name} hat keine Ladung geladen.");
            //Rückgabe von null, falls kein Fahrzeug geladen ist
            return null;
        }
    }

    public class PKW : Fahrzeug { }

    public class Flugzeug : Fahrzeug { }

    class Program
    {
        static void Main(string[] args)
        {
            //Ändern des durch Console verwendeten Zeichensatzes auf Unicode (damit das €-Zeichen angezeigt werden kann)
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            #region Lab 06-09
            //Lab10 ist Erweiterung von Lab09
            #endregion

            #region Lab 10: Interfaces

            //Instanziierung von Bsp-Objekten
            PKW pkw1 = new PKW("BMW", 250, 23000, 5);
            Flugzeug flugzeug1 = new Flugzeug("Boing", 750, 3000000, 9990);
            Schiff schiff1 = new Schiff("Titanic", 40, 3500000, Schiff.SchiffsTreibstoff.Dampf);

            //Aufruf der Belade()-Funktion mit verschiedenen Fahrzeugen
            BeladeFahrzeuge(pkw1, flugzeug1);
            BeladeFahrzeuge(flugzeug1, schiff1);
            BeladeFahrzeuge(schiff1, pkw1);

            //Ausgabe der Info() des Schiffes
            Console.WriteLine("\n" + schiff1.Info());

            //Aufruf der Entlade()-Methode
            schiff1.Entlade();

            #endregion
        }

        public static void BeladeFahrzeuge(Fahrzeug fz1, Fahrzeug fz2)
        {
            //Test, ob fz1 beladbar ist
            if (fz1 is IBeladbar)
            {
                //Cast des Fahrzeuges in IBeladbar und Ausführung der Belade()-Methode
                ((IBeladbar)fz1).Belade(fz2);
            }
            //Test, ob fz2 beladbar ist
            else if (fz2 is IBeladbar)
            {
                //Cast des Fahrzeuges in IBeladbar mittels AS und Ausführung der Belade()-Methode
                (fz2 as IBeladbar).Belade(fz1);
            }
            //Fehlermeldung
            else
                Console.WriteLine("Keines der Fahrzeuge kann ein Fahrzeug transportieren.");
        }
    }
}