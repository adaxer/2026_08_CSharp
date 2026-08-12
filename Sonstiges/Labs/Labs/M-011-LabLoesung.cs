using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fahrzeugpark
{
    //@Trainer: Erweiterungen der PKW- und Fahrzeug-Klassen ist nicht Teil des Labs,
    //          sondern kann als erweitertes Beispiel oder Zusatzaufgabe verwendet werden

    interface IBeladbar { }

    public abstract class Fahrzeug
    {
        #region Lab 06-10
        //Lab11 ist Erweiterung von Lab10
        #endregion

        public static Fahrzeug GeneriereFahrzeug(string nameSuffix = "")
        {
            [...]
                case 1:
                    return PKW.ErzeugeZufälligenPKW(nameSuffix);
            [...]
        }
    }

    public class Schiff : Fahrzeug, IBeladbar { }

    public class PKW : Fahrzeug
    {

        #region Lab 06-10
        //Lab11 ist Erweiterung von Lab10
        #endregion

        //Statische Methode zur Erstellung eines zufälligen PKWs 
        public static PKW ErzeugeZufälligenPKW(string plusName)
        {
            string name;
            switch (generator.Next(1, 5))
            {
                case 1:
                    name = "BMW" + plusName;
                    break;
                case 2:
                    name = "Mercedes" + plusName;
                    break;
                case 3:
                    name = "Audi" + plusName;
                    break;
                default:
                    name = "VW" + plusName;
                    break;
            }
            return new PKW(name, generator.Next(15, 31) * 10, generator.Next(15, 30) * 1000, generator.Next(1, 3) == 1 ? 3 : 5);
        }
    }

    public class Flugzeug : Fahrzeug { }

    class Program
    {
        static void Main(string[] args)
        {
            //Ändern des durch Console verwendeten Zeichensatzes auf Unicode (damit das €-Zeichen angezeigt werden kann)
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            #region Lab 06-10
            //Lab11 ist Erweiterung von Lab10
            #endregion

            #region Lab 11: generische Listen
            //Deklaration der benötigten Variablen und und Initialisierung mit Instanzen der benötigten Objekte
            Queue<Fahrzeug> fzQueue = new Queue<Fahrzeug>();
            Stack<Fahrzeug> fzStack = new Stack<Fahrzeug>();
            Dictionary<Fahrzeug, Fahrzeug> fzDict = new Dictionary<Fahrzeug, Fahrzeug>();
            Random random = new Random();
            //Deklaration und Initialisierung einer Variablen zur Bestimmung der Anzahl der Durchläufe 
            int anzahlFahrzeuge = 10;

            //Schleife zur zufälligen Befüllung von Queue und Stack
            for (int i = 0; i < anzahlFahrzeuge; i++)
            {
                fzQueue.Enqueue(Fahrzeug.GeneriereFahrzeug($"_Q{i}"));
                fzStack.Push(Fahrzeug.GeneriereFahrzeug($"_S{i}"));
            }

            for (int i = 0; i < anzahlFahrzeuge; i++)
            {
                //Prüfung, ob das Interface vorhanden ist (mittels Peek(), da die Objekte noch benötigt werden)...
                if (fzQueue.Peek() is IBeladbar)
                {
                    //...wenn ja, dann Cast in das Interface und Ausführung der Belade()-Methode (mittels Peek())...
                    ((IBeladbar)fzQueue.Peek()).Belade(fzStack.Peek());
                    //...sowie Hinzufügen zum Dictionary (mittels Pop()/Dequeue(), um beim nächsten Durchlauf andere Objekte an den Spitzen zu haben)
                    fzDict.Add(fzQueue.Dequeue(), fzStack.Pop());
                }
                else
                {
                    //... wenn nein, dann Löschung der obersten Objekte (mittels Pop()/Dequeue())
                    fzQueue.Dequeue();
                    fzStack.Pop();
                }
            }

            //Programmpause
            Console.ReadKey();
            Console.WriteLine("\n----------LADELISTE----------");

            //Schleife zur Ausgabe des Dictionaries
            foreach (var item in fzDict)
            {
                Console.WriteLine($"'{item.Key.Name}' hat '{item.Value.Name}' geladen.");
            }

            #endregion
        }

        public static void BeladeFahrzeuge(Fahrzeug fz1, Fahrzeug fz2) { }
    }
}