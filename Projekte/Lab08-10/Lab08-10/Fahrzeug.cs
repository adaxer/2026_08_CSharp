namespace Fahrzeugpark;

public abstract class Fahrzeug
{
    #region Lab 06: Properties, Methoden, Konstruktor

    //Properties
    public static int InstanceCount { get; private set; } = 0;

    private static int _instanceCount = 0;

    public string Name { get; set; }
    public int MaxGeschwindigkeit { get; set; }
    public int AktGeschwindigkeit { get; set; }
    public double Preis { get; set; }
    public bool MotorLaeuft { get; set; }

    public static Fahrzeug GeneriereFahrzeug(string name)
    {
        Random random = new Random(DateTime.Now.Microsecond);
        var r = random.Next(3);
        switch (r)
        {
            case 0:
                return new PKW(name, 200, 30000, 5);
            case 1:
                return new Schiff(name, 40, 20000000, 10);
            default:
                return new Flugzeug(name, 900, 10000000, 12000);
        }
    }

    public static string CounterInfo()
    {
        return $"Es wurden {_instanceCount} Fahrzeuge erstellt.";
    }

    //Konstruktor mit Übergabeparametern und Standartwerten
    public Fahrzeug(string name, int maxG, double preis)
    {
        Name = name;
        MaxGeschwindigkeit = maxG;
        Preis = preis;
        AktGeschwindigkeit = 0;
        MotorLaeuft = false;
        InstanceCount++;
        _instanceCount++;
    }

    // Ausgabe InstanceCount
    public static string GetInstanceCount()
    {
        return $"Es wurden {InstanceCount} Fahrzeuge erstellt.";
    }

    //Methode zur Ausgabe von Objektinformationen
    public virtual string Info()
    {
        if (MotorLaeuft)
            return $"{Name} kostet {Preis}€ und fährt momentan mit {AktGeschwindigkeit} von maximal {MaxGeschwindigkeit}km/h.";
        else
            return $"{Name} kostet {Preis}€ und könnte maximal {MaxGeschwindigkeit}km/h fahren.";
    }

    //Methode zum Starten des Motors
    public void StarteMotor()
    {
        if (MotorLaeuft)
            Console.WriteLine($"Der Motor von {Name} läuft bereits.");
        else
        {
            MotorLaeuft = true;
            Console.WriteLine($"Der Motor von {Name} wurde gestartet.");
        }
    }

    //Methode zum Stoppen des Motors
    public void StoppeMotor()
    {
        if (!MotorLaeuft)
            Console.WriteLine($"Der Motor von {Name} ist bereits gestoppt");
        else if (AktGeschwindigkeit > 0)
            Console.WriteLine($"Der Motor kann nicht gestoppt werden, da sich {Name} noch bewegt");
        else
        {
            MotorLaeuft = false;
            Console.WriteLine($"Der Motor von {Name} wurde gestoppt.");
        }
    }

    //Methode zum Beschleunigen und Bremsen
    public void Beschleunige(int a)
    {
        if (MotorLaeuft)
        {
            if (AktGeschwindigkeit + a > MaxGeschwindigkeit)
                AktGeschwindigkeit = MaxGeschwindigkeit;
            else if (AktGeschwindigkeit + a < 0)
                AktGeschwindigkeit = 0;
            else
                AktGeschwindigkeit += a;

            Console.WriteLine($"{Name} bewegt sich jetzt mit {AktGeschwindigkeit}km/h");
        }
    }

    public abstract void Hupen();

    public override string ToString()
    {
        IDriveable.MaxSpeed = 400;
        return $"{Name} ({GetType().Name})";
    }
    #endregion
}

interface IDriveable
{
    string Name { get; set; }
    double Speed { get; }

    // Statische Konstante für die maximale Geschwindigkeit
    static double MaxSpeed { get; set; } = 300;

    void Accelerate(double deltaSpeed);
    void Brake(double deltaSpeed);
}

