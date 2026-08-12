using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    //ABSTRACT definiert eine Klasse als abstrakt. D.h. von dieser Klasse können keine Objekte mehr instanziiert werden, sie dient nur noch als Mutterklasse
    public abstract class Lebewesen
    {
        #region Modul 06-08
        //Demo M09 basiert auf Demo M08
        #endregion

        //Abstrakte Methoden dürfen nur in abstrakten Klassen existieren und definieren nur
        ///eine Signatur. Die erbenden Klassen werden gezwungen eine Implementierung vorzunehmen
        public abstract void Essen();

    }

    public class Mensch : Lebewesen
    {
        #region Modul 06-08
        //Demo M09 basiert auf Demo M08
        #endregion

        //Durch Mutterklasse erzwungene (weil dort abstrakte) Methode
        public override void Essen()
        {
            Console.WriteLine($"{this.Vorname} konsumiert {this.Lieblingsnahrung}.");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            #region Modul 06-08
            //Demo M09 basiert auf Demo M08
            #endregion

            #region Modul 09: Polymorphismus

            //Deklaration einer Bsp-Variablen
            Lebewesen lebewesen;
            //Instanziierung eines Objekts der abgeleiteten Klasse
            Mensch mensch = new Mensch("Anna", "Meier", "Lasagne", new DateTime(1984, 5, 6));

            //Zuweisung des abgeleiteten Objekts zu Variable der Mutterklasse
            lebewesen = mensch;

            //Tests des Laufzeittyps (des beinhalteten Objekts)
            if (lebewesen.GetType() == typeof(Mensch))
                Console.WriteLine("Lebewesen ist ein Mensch");

            if (lebewesen is Mensch)
                Console.WriteLine("Lebewesen ist ein Mensch");

            //überschriebene Methoden werden trotzdem ausgeführt
            Console.WriteLine(lebewesen.ToString());

            if (lebewesen is Arbeitnehmer)
            {
                //Rückcast des abgeleiteten Objekts aus Mutterklassevariablen in abgeleitete Variable
                Mensch mensch2 = (Arbeitnehmer)person;
                //Alternativer Cast
                mensch2 = person as Arbeitnehmer;
            }

            #endregion
        }
    }
}
