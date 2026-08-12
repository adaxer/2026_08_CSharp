using System;
using System.Collections.Generic;

namespace Fahrzeugpark
{
    class Program
    {
        static void Main(string[] args)
        {
            //Ändern des durch Console verwendeten Zeichensatzes auf Unicode (damit das €-Zeichen angezeigt werden kann)
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            //Bsp-Objekte
            PKW pkw1 = PKW.ErzeugeZufälligenPKW("");
            PKW pkw2 = PKW.ErzeugeZufälligenPKW("");
            Console.WriteLine(pkw1.Info());
            Console.WriteLine(pkw2.Info());

            //Bsp-Anwendung von überladenen Operatoren (vgl. Fahrzeug-Klasse)
            Console.WriteLine(pkw1 > pkw2);

            //Bsp-Anwendung für IEnumerable (vgl. Flugzeug-Klasse)
            Flugzeug flugzeug = new Flugzeug($"Boing", 350, 90000000, 9800);
            foreach (var passagiere in flugzeug)
            {
                Console.WriteLine(passagiere);
            }
            //Bsp-Anwendung einer Indexer-Property (vgl. Flugzeug-Klasse)
            Console.WriteLine(flugzeug[2]);

            //Bsp-Anwendung einer Erweiterungmethode (s.u.)
            Random random = new Random();
            int erg = random.NextInclusive(1, 5);
        }
    }

    class Fahrzeug
    {
        [...]

        #region Operatoren
        //Für Klassen können die bekannten Operatoren mittels des OPERATOR-Stichworts neu definiert werden.
        //Hier gilt ein Fahrzeug als größer, wenn seine MaxGeschwindigkeit größer ist
        public static bool operator >(Fahrzeug fz1, Fahrzeug fz2)
        {
            return fz1.MaxGeschwindigkeit > fz2.MaxGeschwindigkeit;
        }
        public static bool operator <(Fahrzeug fz1, Fahrzeug fz2)
        {
            return fz1.MaxGeschwindigkeit < fz2.MaxGeschwindigkeit;
        }

        #endregion
    }

    class Flugzeug : Fahrzeug, IEnumerable
    {
        [...]

        //Bsp-Property für IEnumerable und Indexer
        public List<string> Passagierliste { get; set; } = new List<string>() { "Hanna", "Anna", "Mario", "Olaf" };

        //IEnumerable erlaubt die Verwendung des Objekts durch die foreach-Schleife, welche die GetEnumerator()-Methode aufruft
        public IEnumerator GetEnumerator()
        {
            foreach (var passagier in this.Passagierliste)
            {
                //YIELD RETURN gibt in jedem Schleifendurchlauf ein Element zurück
                yield return passagier;
            }
        }

        //Indexerproperties werden über den Variablenbezeichner und eine Indexübegabe aufgerufen (wie bei Arrays und Listen)
        public string this[int index]
        {
            get { return this.Passagierliste[index]; }
            set { this.Passagierliste[index] = value; }
        }
    }

    public static class Hilfsmethoden
    {
        //Mittels des THIS-Stichworts in der Parameterübergabe kann eine Methode als Erweiterungsmethode einer Klasse definiert
        //werden. Diese muss in einer statischen Klasse beschrieben werden und wird dann als Teil der zugeordneten Klasse betrachtet.
        public static int NextInclusive(this Random random, int untergrenze, int obergrenze)
        {
            return random.Next(untergrenze, obergrenze + 1);
        }
    }
}