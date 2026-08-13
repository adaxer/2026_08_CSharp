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
    }
}
