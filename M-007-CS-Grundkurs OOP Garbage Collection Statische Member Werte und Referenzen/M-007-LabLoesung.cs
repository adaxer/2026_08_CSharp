using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fahrzeugpark
{
    public class Fahrzeug
    {
        #region Lab 06
        //Lab07 ist Erweiterung von Lab06
        #endregion

        #region Lab 07: Statische Member, Destruktor

        public static int AnzahlFahrzeuge { get; set; } = 0;

        public static string ZeigeAnzahlFahrzeuge()
        {
            return $"Es wurden {AnzahlFahrzeuge} Fahrzeuge gebaut.";
        }

        ~Fahrzeug()
        {
            Console.WriteLine($"{this.Name} wurde gerade verschrottet.");
        }

        #endregion
    }

    class Program
    {
        static void Main(string[] args)
        {
            //Ändern des durch Console verwendeten Zeichensatzes auf Unicode (damit das €-Zeichen angezeigt werden kann)
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            #region Lab 06
            //Lab07 ist Erweiterung von Lab06
            #endregion

            #region Lab 07: GC und statische Member

            //Generierung von div. Objekten (zur Überschwemmung des RAM)
            Fahrzeug fz1 = new Fahrzeug("BMW", 230, 25999.99);
            for (int i = 0; i < 1000; i++)
            {
                fz1 = new Fahrzeug("BMW", 230, 25999.99);
            }

            //Bsp-Aufruf der GarbageCollection
            GC.Collect();
            //Abwarten der Finalizer-Ausführungen (der Objekte)
            GC.WaitForPendingFinalizers();

            //Aufruf der statischen Methode
            Console.WriteLine(Fahrzeug.ZeigeAnzahlFahrzeuge());

            #endregion

        }
    }
}
