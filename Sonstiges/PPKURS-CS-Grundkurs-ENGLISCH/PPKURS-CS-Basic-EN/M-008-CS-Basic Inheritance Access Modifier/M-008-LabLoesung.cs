using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fahrzeugpark
{
    public class Fahrzeug
    {
        #region Lab 06-07
        //Lab08 ist Erweiterung von Lab07
        #endregion

        //Methode zur Ausgabe von Objektinformationen | virtual erlaubt das Überschreiben durch erbende Klassen
        public virtual string Info() { ...}
    }

    //Schiff erbt von der Fahrzeug-Klasse und übernimmt deren Member
    public class Schiff : Fahrzeug
    {
        //Klasseneigener Enum
        public enum SchiffsTreibstoff { Diesel = 0, Dampf, Wind, Muskelkraft }

        //Klasseneigene Property
        public SchiffsTreibstoff Treibstoff { get; set; }

        //Konstruktor mit Bezug auf den Konstruktor der Mutterklasse (base)
        public Schiff(string name, int maxG, double preis, SchiffsTreibstoff treibstoff) : base(name, maxG, preis)
        {
            this.Treibstoff = treibstoff;
        }

        //Überxchreibung der Info()-Methode mit Bezug auf die Methode der Mutterklasse (base)
        public override string Info()
        {
            return "Das Schiff " + base.Info() + $" Es fährt mit {this.Treibstoff}.";
        }
    }

    //vgl. Schiff
    public class PKW : Fahrzeug
    {
        public int AnzahlTueren { get; set; }

        public PKW(string name, int maxG, double preis, int anzTueren) : base(name, maxG, preis)
        {
            this.AnzahlTueren = anzTueren;
        }

        public override string Info()
        {
            return "Der PKW " + base.Info() + $" Er hat {this.AnzahlTueren} Türen.";
        }
    }

    //vgl. Schiff
    public class Flugzeug : Fahrzeug
    {
        public int MaxFlughöhe { get; set; }

        public Flugzeug(string name, int maxG, double preis, int maxFH) : base(name, maxG, preis)
        {
            this.MaxFlughöhe = maxFH;
        }

        public override string Info()
        {
            return "Das Flugzeug " + base.Info() + $" Es kann bis auf {this.MaxFlughöhe}m aufsteigen.";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //Ändern des durch Console verwendeten Zeichensatzes auf Unicode (damit das €-Zeichen angezeigt werden kann)
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            #region Lab 06-07
            //Lab08 ist Erweiterung von Lab07
            #endregion

            #region Lab 08: Vererbung

            //Instanziierung verschiedener Fahrzeuge
            PKW pkw1 = new PKW("Mercedes", 210, 23000, 5);
            Schiff schiff1 = new Schiff("Titanic", 40, 25000000, Schiff.SchiffsTreibstoff.Dampf);
            Flugzeug flugzeug1 = new Flugzeug("Boing", 350, 90000000, 9800);

            //Ausgabe der verschiedenen Info()-Methoden
            Console.WriteLine(pkw1.Info());
            Console.WriteLine(schiff1.Info());
            Console.WriteLine(flugzeug1.Info());

            #endregion

        }
    }
}