using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fahrzeugpark
{
    //Als abstrakte Klasse dient Fahrzeug nur noch als Vorlage für erbende Klassen und kann selbst keine Objekte mehr instanziieren
    public abstract class Fahrzeug
    {
        #region Lab 06-08
        //Lab09 ist Erweiterung von Lab08
        #endregion

        #region Lab 08: Polymorphismus

        //statisches Feld für Zufallsgenerator
        protected static Random generator = new Random();
        //Methode zur zufälligen Generierung eines Fahrzeugs
        public static Fahrzeug GeneriereFahrzeug(string nameSuffix = "")
        {
            switch (generator.Next(1, 4))
            {
                //Instanziierung der jeweiligen spezifischen Fahrzeuge
                case 1:
                    return new PKW("Mercedes" + nameSuffix, 210, 23000, 5);
                case 2:
                    return new Schiff("Titanic" + nameSuffix, 40, 25000000, Schiff.SchiffsTreibstoff.Dampf);
                default:
                    return new Flugzeug("Boing" + nameSuffix, 350, 90000000, 9800);
            }
        }

        //Definition einer abstrakten Methode
        public abstract void Hupen();

        //override ToString() überschreibt die Standart-ToString()-Methode
        public override string ToString()
        {
            return this.GetType().Name + ": " + this.Name;
        }

        #endregion
    }

    public class Schiff : Fahrzeug
    {
        #region Lab 06-08
        //Lab09 ist Erweiterung von Lab08
        #endregion

        //Durch Mutterklasse verlangter Member (da dort als abstract gesetzt)
        public override void Hupen()
        {
            Console.WriteLine($"{this.Name}: 'Tröööt'");
        }
    }

    public class PKW : Fahrzeug
    {
        #region Lab 06-08
        //Lab09 ist Erweiterung von Lab08
        #endregion

        public override void Hupen()
        {
            Console.WriteLine($"{this.Name}: 'Hup Hup'");
        }
    }

    public class Flugzeug : Fahrzeug
    {
        #region Lab 06-08
        //Lab09 ist Erweiterung von Lab08
        #endregion

        public override void Hupen()
        {
            Console.WriteLine($"{this.Name}: 'Biep Biep'");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //Ändern des durch Console verwendeten Zeichensatzes auf Unicode (damit das €-Zeichen angezeigt werden kann)
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            #region Lab 06-08
            //Lab09 ist Erweiterung von Lab08
            #endregion

            #region Lab 09: Polymorphismus

            //Arraydeklarierung
            Fahrzeug[] fahrzeuge = new Fahrzeug[10];

            //Schleife über das Array zur Befüllung
            for (int i = 0; i < fahrzeuge.Length; i++)
            {
                //Aufruf der Zufallsmethode aus der Fahrzeug-Klasse
                fahrzeuge[i] = Fahrzeug.GeneriereFahrzeug($"_{i}");
            }

            //Deklarierung/Initialisierung der Zählvariablen
            int pkws = 0, schiffe = 0, flugzeuge = 0;

            //Schleife über das Array zur Identifizierung der Objekttypen
            foreach (var item in fahrzeuge)
            {
                //Ausgabe der ToString()-Methoden
                Console.WriteLine(item as Fahrzeug);
                //Prüfung des Objektstyps und Hochzählen der entsprechenden Variablen
                if (item == null) Console.WriteLine("Kein Objekt vorhanden");
                else if (item is PKW) pkws++;
                else if (item is Schiff) schiffe++;
                else flugzeuge++;
            }

            //Ausgabe
            Console.WriteLine($"Es wurden {pkws} PKW(s), {flugzeuge} Flugzeug(e) und {schiffe} Schiff(e) produziert.");
            //Ausführung der abstrakten Methode
            fahrzeuge[2].Hupen();

            #endregion

        }
    }
}