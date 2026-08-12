using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    public class Lebewesen
    {
        #region Modul 06
        //Demo M07 basiert auf Demo M06
        #endregion

        #region Statische Member

        //STATISCHE Variablen und Methoden hängen an der Klasse selbst und nicht an instanziierten Objekten. Sie existieren demnach unabhängig von der Anzahl
        ///Objekte genau einmal. Der Aufruf erfolgt über den Klassenbezeichner.
        public static int AnzahlLebewesen { get; set; } = 0;

        public static string ZeigeAnzahlLebewesen()
        {
            return $"Es gibt {AnzahlLebewesen} Lebewesen.";
        }

        #endregion

        #region Destruktor

        //Der DESTRUKTOR wird von der GarbageCollection aufgerufen, wenn das Objekt nicht
        //mehr referenziert ist. Hier können Aktionen definiert werden,
        //welche zusätzlich zur 'Zerstörung' erfolgen sollen.
        ~Lebewesen()
        {
            Console.WriteLine($"{this.Name} ist gestorben.");
            AnzahlLebewesen--;
        }

        #endregion

    }

    class Program
    {
        static void Main(string[] args)
        {
            #region Modul 06
            //Demo M07 basiert auf Demo M06
            #endregion

            #region Modul 07: Statische Member und GC

            //Aufruf eines statischen Members der Person-Klasse
            Console.WriteLine(Lebewesen.ZeigeAnzahlLebewesen());

            //Nullsetzung der Variablen (um das Personenobjekt freizugeben und die GC demonstrieren zu können)
            neuesLebewesen = null;

            //Aufruf der GC und Programmpause, bis alle Destruktoren beendet wurden
            GC.Collect();
            GC.WaitForPendingFinalizers();

            #endregion
        }
    }
}

namespace Werte_Referenzen
{
    //Klasse, deren Objekte als REFERENZTYPEN betrachtet werden
    class PersonC
    {
        public int Alter { get; set; }
        public string Name { get; set; }

        public PersonC(int a, string n)
        {
            Alter = a;
            Name = n;
        }
    }

    //Struct, dessen Objekte, wie sämtliche Basisdatentypen, als WERTETYPEN betrachtet werden
    struct PersonS
    {
        public int Alter { get; set; }
        public string Name { get; set; }

        public PersonS(int a, string n)
        {
            Alter = a;
            Name = n;
        }
    }


    class Program
    {
        //Methoden, welche jeweils die Alter-Property manipulieren
        public static void Altern(PersonC person)
        {
            person.Alter++;
        }

        public static void Altern(PersonS person)
        {
            person.Alter++;
        }

        //Mittels des REF-Stichworts können Werte als Referenzen an Methoden übergeben werden (s.u.)
        public static void Altern(ref PersonS person)
        {
            person.Alter++;
        }

        static void Main(string[] args)
        {
            //Instanziierung von Bsp-Objekten
            PersonC classP = new PersonC(30, "Anna");
            PersonS structP = new PersonS(30, "Hugo");
            //Ausgabe der Alter
            Console.WriteLine($"{classP.Name}: {classP.Alter}");
            Console.WriteLine($"{structP.Name}: {structP.Alter}");

            //Übergabe des Klassenobjekts (Referenztyp):
            ///Da bei der Übergabe die Referenz des Objektes an die Methode übergeben wird, wird innerhalb der Methode
            ///das Alter des Objekts manipuliert. Im Ergebnis ist das Objekt nach der Methode ein Jahr älter geworden.
            Altern(classP);
            Console.WriteLine($"{classP.Name}: {classP.Alter}");

            //Übergabe des Structobjekts (Wertetyp):
            ///Als Wertetyp wird das Objekt bei der Übergabe an die Methode kopiert. Die Methode manipuliert nur die Kopie.
            ///In dem Originalobjekt sind keine Veränderungen zu beobachten. Dieses Verhalten findet scih bei allen Wertetypen.
            Altern(structP);
            Console.WriteLine($"{structP.Name}: {structP.Alter}");

            //Übergabe eines Wertetypen mittels ref
            ///Ducrh ref wird auch bei Wertetypen die Referenz übergeben, wodurch hier eine Manipulation des Originalobjekts durchgeführt wird.
            Altern(ref structP);
            Console.WriteLine($"{structP.Name}: {structP.Alter}");
        }
    }
}
