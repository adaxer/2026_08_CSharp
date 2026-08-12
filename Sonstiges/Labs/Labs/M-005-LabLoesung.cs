while (true)
{
	double zahl1 = ZahlEingabe("Gib eine Zahl ein: ");
	double zahl2 = ZahlEingabe("Gib eine weitere Zahl ein: ");

	foreach (Rechenoperationen operation in Enum.GetValues<Rechenoperationen>())
		Console.WriteLine($"{(int) operation}: {operation}");
	Rechenoperationen op = RechenoperationEingabe();

	double ergebnis = Berechne(zahl1, zahl2, op);

	if (Console.ReadKey().Key == ConsoleKey.Escape)
		break;
}

double Berechne(double zahl1, double zahl2, Rechenoperationen op)
{
	switch (op)
	{
		case Rechenoperationen.Add:
			Console.WriteLine($"{zahl1} + {zahl2} = {zahl1 + zahl2}");
			return zahl1 + zahl2;
		case Rechenoperationen.Sub:
			Console.WriteLine($"{zahl1} - {zahl2} = {zahl1 - zahl2}");
			return zahl1 - zahl2;
		case Rechenoperationen.Mult:
			Console.WriteLine($"{zahl1} * {zahl2} = {zahl1 * zahl2}");
			return zahl1 * zahl2;
		case Rechenoperationen.Div:
			if (zahl2 == 0)
				return double.NaN;

			Console.WriteLine($"{zahl1} / {zahl2} = {zahl1 / zahl2}");
			return zahl1 / zahl2;
		default:
			Console.WriteLine("Fehler");
			return double.NaN;
	}
}

double ZahlEingabe(string text)
{
	while (true)
	{
		Console.Write(text);
		bool funktioniert = double.TryParse(Console.ReadLine(), out double ergebnis);
		if (funktioniert)
			return ergebnis;
		else
			Console.WriteLine("Keine Zahl eingegeben");
	}
}

Rechenoperationen RechenoperationEingabe()
{
	while (true)
	{
		double ergebnis = ZahlEingabe("Gib eine Rechenoperation ein: ");
		Rechenoperationen op = (Rechenoperationen) ergebnis;
		if (Enum.IsDefined(op))
			return op;
		else
			Console.WriteLine("Keine gültige Rechenoperation eingegeben");
	}
}

enum Rechenoperationen { Add = 1, Sub, Mult, Div }