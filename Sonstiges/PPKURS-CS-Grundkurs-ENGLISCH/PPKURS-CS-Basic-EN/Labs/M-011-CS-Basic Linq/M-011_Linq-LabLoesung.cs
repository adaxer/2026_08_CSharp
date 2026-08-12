namespace M011_Linq;

public class M_011_Linq_LabLoesung
{
	static void Main(string[] args)
	{
		List<Fahrzeug> fahrzeuge = new List<Fahrzeug>
		{
			new Fahrzeug(0, 251, FahrzeugMarke.BMW),
			new Fahrzeug(1, 274, FahrzeugMarke.BMW),
			new Fahrzeug(2, 146, FahrzeugMarke.BMW),
			new Fahrzeug(3, 208, FahrzeugMarke.Audi),
			new Fahrzeug(4, 189, FahrzeugMarke.Audi),
			new Fahrzeug(5, 133, FahrzeugMarke.VW),
			new Fahrzeug(6, 253, FahrzeugMarke.VW),
			new Fahrzeug(7, 304, FahrzeugMarke.BMW),
			new Fahrzeug(8, 151, FahrzeugMarke.VW),
			new Fahrzeug(9, 250, FahrzeugMarke.VW),
			new Fahrzeug(10, 217, FahrzeugMarke.Audi),
			new Fahrzeug(11, 125, FahrzeugMarke.Audi)
		};

		//1
		fahrzeuge.Where(e => e.Sitze.Count == 6);

		//2
		fahrzeuge.Sum(e => e.Sitze.Count);

		//3
		fahrzeuge.OrderBy(e => e.Marke).ThenBy(e => e.MaxGeschwindigkeit);

		//4
		fahrzeuge.Where(e => e.Sitze.Any(x => x.IstBesetzt));

		//5
		fahrzeuge.Where(e => e.MaxGeschwindigkeit > fahrzeuge.Average(x => x.MaxGeschwindigkeit));

		//6
		fahrzeuge.Where(e => e.Sitze.Count(x => x.IstBesetzt) > e.Sitze.Count / 2);

		//7
		fahrzeuge.GroupBy(e => e.Marke).ToDictionary(e => e.Key, e => e.MaxBy(x => x.MaxGeschwindigkeit));
		Dictionary<Brand, Car> x = cars.OrderByDescending(c => c.MaxV).DistinctBy(c => c.Brand).ToDictionary(c => c.Brand, c => c);

		//8
		fahrzeuge.GroupBy(e => e.Sitze.Count).ToDictionary(e => e.Key, e => e.MaxBy(x => x.MaxGeschwindigkeit)).OrderBy(e => e.Key);
		Dictionary<int, Car> y = cars.OrderByDescending(c => c.MaxV).DistinctBy(c => c.SeatList.Count).ToDictionary(c => c.SeatList.Count, c => c);
	}
}
public class Fahrzeug
{
	public int ID;
	public int MaxGeschwindigkeit;
	public FahrzeugMarke Marke;
	public List<Sitzplatz> Sitze;

	public Fahrzeug(int id, int v, FahrzeugMarke fm)
	{
		ID = id;
		MaxGeschwindigkeit = v;
		Marke = fm;
		Sitze = new();

		//Anzahl Sitzplätze anhand der Geschwindigkeit (6: max 150km/h, 5 bis 250km/h, 4 ab 250km/h)
		int sitze = v <= 150 ? 6 : v <= 250 ? 5 : 4;

		//Sitzplätze erstellen
		for (int i = 0; i < sitze; i++)
			Sitze.Add(new Sitzplatz());

		//Sitzplätze semi-zufällig belegen damit die Übung zwischen Teilnehmern gleiche Ergebnisse liefert
		//Geschwindigkeit modulo Anzahl Sitzplätze besetzen
		for (int i = 0; i < v % (sitze + 1); i++)
			Sitze[i].IstBesetzt = true;
	}
}

public record Sitzplatz(bool IstBesetzt);

public enum FahrzeugMarke
{
	Audi, BMW, VW
}