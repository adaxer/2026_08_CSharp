namespace Fahrzeugpark;

public class PKW : Fahrzeug
{
    public int Sitzplaetze { get; set; }

    public PKW(string name, int maxG, double preis, int sitzplaetze) : base(name, maxG, preis)
    {
        Sitzplaetze = sitzplaetze;
    }

    public override string Info()
    {
        return base.Info() + $" Es hat {Sitzplaetze} Sitzplätze.";
    }

    public override void Hupen()
    {
        Console.WriteLine($"{Name}: Meep meep!");
    }
}

public class Schiff : Fahrzeug
{
    public double Tiefgang { get; set; }

    public Schiff(string name, int maxG, double preis, double tiefgang) : base(name, maxG, preis)
    {
        Tiefgang = tiefgang;
    }
    public override string Info()
    {
        return base.Info() + $" Es hat einen Tiefgang von {Tiefgang} Metern.";
    }

    public override void Hupen()
    {
        Console.WriteLine($"{Name}: ?!");
    }
}

public class Flugzeug : Fahrzeug
{
    public int MaxFlughoehe { get; set; }

    public Flugzeug(string name, int maxG, double preis, int maxFlughoehe) : base(name, maxG, preis)
    {
        MaxFlughoehe = maxFlughoehe;
    }
    public override string Info()
    {
        return base.Info() + $" Es hat eine maximale Flughöhe von {MaxFlughoehe} Metern.";
    }

    public override void Hupen()
    {
        Console.WriteLine($"{Name}: Tröööt!");
    }
}