using Fahrzeugpark;

namespace Lab08_10;

internal class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        var auto = new PKW("Bmw", 250, 80000, 5);
        Console.WriteLine(auto.Info());

        auto = new PKW("Fiat", 160, 2000, 4);
        Console.WriteLine(auto.Info());

        var boot = new Schiff("Titanic", 40, 20000000, 10);
        Console.WriteLine(boot.Info());

        var jumbo = new Flugzeug("Jumbo", 900, 10000000, 12000); 
        jumbo.StarteMotor();
        Console.WriteLine(jumbo.Info());

        Fahrzeug[] fahrzeuge = new Fahrzeug[10];
        for (int i = 0; i < fahrzeuge.Length; i++)
        {
            fahrzeuge[i] = Fahrzeug.GeneriereFahrzeug($"Fahrzeug {i + 1}");
            Console.WriteLine($"{fahrzeuge[i].ToString()}: {fahrzeuge[i].Info()}");
        }

        Console.WriteLine(Fahrzeug.GetInstanceCount());

        fahrzeuge[2].Hupen();
    }
}
