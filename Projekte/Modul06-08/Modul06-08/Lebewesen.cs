namespace Modul06_08;

public abstract class Lebensform // : System.Object
{
    public abstract void Fortpflanzung();
}

public class Lebewesen : Lebensform
{
    public virtual int Beine { get; } = 0;

    public int Alter { get; set; }

    public Lebewesen(int alter)
    {
        Alter = alter;
    }

    public void Geburtstag()
    {
        Alter++;
    }

    public virtual void WasBinIch()
    {
        Console.WriteLine($"Ich bin ein Lebewesen mit {Beine} Bein(en), genauer gesagt ein {GetType().Name} und {Alter} Jahre alt.");
    }

    public override void Fortpflanzung()
    {
        Console.WriteLine("Fortpflanzung unbestimmt");
    }
}

public class Mensch : Lebewesen
{
    public  string Name { get; set; }

    public override int Beine => 2;

    public Mensch(string name, int alter) : base(alter)
    {
        Name = name;
    }

    public override void WasBinIch()
    {
        Console.WriteLine($"Ich bin ein Mensch namens {Name}.");
        Console.WriteLine("Aber zusätzlich:");
        base.WasBinIch();
        Console.WriteLine();
    }

    public override void Fortpflanzung()
    {
        Console.WriteLine("Fortpflanzung zweigeschlechtlich");
    }
}

public static class OOPAktionen
{
    public static void DoSomething()
    {
        Lebewesen lebewesen1 = new Lebewesen(1);
        Mensch mensch1 = new("Hans", 30);

        Lebewesen menschAlsLebewesen = mensch1;
        lebewesen1.Geburtstag();
        menschAlsLebewesen.Geburtstag();

        Lebewesen[] someLifeForms = new Lebewesen[4];
        someLifeForms[0] = lebewesen1;
        someLifeForms[1] = mensch1;
        someLifeForms[2] = new Mensch("Anna", 25);
        someLifeForms[3] = menschAlsLebewesen;

        foreach (var lifeForm in someLifeForms)
        {
            lifeForm.WasBinIch();
        }
    }
}


