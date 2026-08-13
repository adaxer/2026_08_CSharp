using Fahrzeugpark;

namespace Lab07;

internal class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        var auto = new Fahrzeug("Auto", 200, 30000);
        auto.StarteMotor();
        auto.Beschleunige(50);
        Console.WriteLine(auto.Info());

        auto = new Fahrzeug("Bmw", 250, 80000);
        Console.WriteLine(auto.Info());

        auto = new Fahrzeug("Fiat", 160, 20000);
        Console.WriteLine(auto.Info());


        Console.WriteLine(Fahrzeug.GetInstanceCount());
    }
}
