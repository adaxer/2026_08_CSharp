internal class Program
{
    private static void Main(string[] args)
    {
        double aZero = 1.0 / 0.0; // Positive Infinity
        Console.WriteLine($"Look at that: {aZero}");

        Console.WriteLine(aZero);
        Console.WriteLine(aZero.ToString("F2"));
        Console.WriteLine(double.IsPositiveInfinity(aZero));

        var nfi = System.Globalization.CultureInfo.CurrentCulture.NumberFormat;
        Console.WriteLine($"Culture: {System.Globalization.CultureInfo.CurrentCulture.Name}");
        Console.WriteLine($"PositiveInfinitySymbol: [{nfi.PositiveInfinitySymbol}]");
        Console.WriteLine($"PositiveInfinitySymbol: [{(short)nfi.PositiveInfinitySymbol[0]}]");
        Console.WriteLine($"PositiveInfinitySymbol: [{(short)"8"[0]}]");

        // Daten einlesen

        bool _isLoggedIn = false;

        Console.WriteLine();
        Console.Write("Entfernung in Meter: ");
        int meter = int.Parse(Console.ReadLine());
        //int meter = int.Parse(Console.ReadLine()??"0");
        Console.Write("Stunden: ");
        int stunden = int.Parse(Console.ReadLine());
        //int stunden = int.Parse(Console.ReadLine()!); 
        Console.Write("Minuten: ");
        int minuten = int.Parse(Console.ReadLine());
        Console.Write("Sekunden: ");
        int sekunden = int.Parse(Console.ReadLine());


        // Berechnung

        double totalHours = stunden + minuten / 60.0 + sekunden / 3600.0;
        double totalSeconds = stunden * 3600 + minuten * 60 + sekunden;
        double speedMps = meter / totalSeconds; // Geschwindigkeit in m/s
        double speedKph = speedMps * 3.6; // Geschwindigkeit in km/h
        double speedMph = speedKph / 1.609; // Geschwindigkeit in mph

#pragma warning disable CS0219 // Variable ist zugewiesen, der Wert wird jedoch niemals verwendet
        bool isValid = false;
#pragma warning restore CS0219 // Variable ist zugewiesen, der Wert wird jedoch niemals verwendet

        // Für Abweichungen kann man .editorconfig
        if (isValid)
        {
            Console.WriteLine(isValid);
            Console.ReadLine();
        }
        else
        {
        }

        // Ausgabe

        Console.WriteLine($"Meter/Sekunde: {speedMps:f2} m/s,\nKilometer/Stunde: {speedKph:f2} km/h, \nMeilen/Stunde: {speedMph:f2} mph");
        Console.WriteLine("\n\nEnde - Taste drücken");

        Roles myRoles = Roles.Admin | Roles.PowerUser;
        Console.WriteLine((int)myRoles);

        switch (myRoles)
        {
            case Roles.Admin:
                Console.WriteLine("Admin");
                break;
            case Roles.Guest:
                Console.WriteLine("Guest");
                break;
            case Roles.PowerUser:
                Console.WriteLine("PowerUser");
                break;
            default:
                Console.WriteLine("Unknown role");
                break;
        }

        Console.ReadKey();
    }
}

[Flags]
enum Roles
{
    None = 0,
    Admin = 1,
    Guest = 2,
    PowerUser = 4
}
