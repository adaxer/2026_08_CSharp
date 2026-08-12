internal class Program
{
	enum Rechenoperation { Addition = 1, Subtraktion, Multiplikation, Division }

	static void Main(string[] args)
	{
		while (true)
		{
			double zahl1 = GetInput("Gib eine Zahl ein: ");
			double zahl2 = GetInput("Gib eine weitere Zahl ein: ");

			foreach (Rechenoperation op in Enum.GetValues<Rechenoperation>())
			{
                Console.WriteLine($"{(int) op}: {op}");
            }

			Rechenoperation operation = GetRechenoperation();
			double ergebnis = Berechne(zahl1, zahl2, operation);
			string symbol = ConvertRechenoperation(operation);
			Console.WriteLine($"{zahl1} {symbol} {zahl2} = {ergebnis}");

            Console.WriteLine("Wiederholen? (Enter)");
            if (Console.ReadKey(true).Key != ConsoleKey.Enter)
				break;
		}
	}

	static double GetInput(string text)
	{
		while (true)
		{
			Console.Write(text);
			string eingabe = Console.ReadLine();
			double zahl;
			bool funktioniert = double.TryParse(eingabe, out zahl);
			if (funktioniert)
				return zahl;
		}
    }

	static Rechenoperation GetRechenoperation()
	{
		Rechenoperation[] alleOperationen = Enum.GetValues<Rechenoperation>();
		while (true)
		{
			string eingabe = Console.ReadLine();
			Rechenoperation operation;
			bool funktioniert = Enum.TryParse<Rechenoperation>(eingabe, out operation);
			if (!alleOperationen.Contains(operation))
			{
				Console.WriteLine("Keine gültige Rechenoperation ausgewählt");
				continue;
			}
			if (funktioniert)
				return operation;
		}
	}

	static double Berechne(double x, double y, Rechenoperation op)
	{
		switch (op)
		{
			case Rechenoperation.Addition:
                return x + y;
			case Rechenoperation.Subtraktion:
				return x - y;
			case Rechenoperation.Multiplikation:
				return x * y;
			case Rechenoperation.Division:
				return y != 0 ? x / y : double.NaN;
			default:
                return double.NaN;
		}
	}

	static string ConvertRechenoperation(Rechenoperation op)
	{
		switch (op)
		{
			case Rechenoperation.Addition:
				return "+";
			case Rechenoperation.Subtraktion:
				return "-";
			case Rechenoperation.Multiplikation:
				return "*";
			case Rechenoperation.Division:
				return "/";
			default: 
				return "";
		}
	}
}