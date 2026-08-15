using System.Diagnostics;
using System.Text.Json;

namespace M012;

internal class Program
{
	static void Main(string[] args)
	{
		#region File lesen
		string readJson = File.ReadAllText(@"..\..\..\Personen.json");
		List<Person> personen = JsonSerializer.Deserialize<List<Person>>(readJson)!;
		#endregion
		
		//Hier eigenen Code schreiben
		var aged = personen.Where(p=>p.Alter>=60).ToList();

		var riches = personen.Where(p => p.Job.Gehalt > 5000).Select(p=>p.ID).ToList();

		var jobsSalaries = personen.OrderBy(p => p.Job.Titel).ThenBy(p => p.Job.Gehalt).ToList();

		var longPrenames = personen.Where(p => p.Vorname.Length > 10).Select(p => p.Vorname).ToList();

		var swSalary = personen.Where(p => p.Job.Titel.Contains("Software")).Select(p => p.Job.Gehalt).Average();

		var oldGoodSalary = personen.Where(p=>p.Alter>50).All(p => p.Job.Gehalt*12 > 25000);

		// ...
		personen.GroupBy(p=>p.Job.Titel)
						   .Select(g => new KeyValuePair<string, List<Person>>(g.Key, g.OrderByDescending(h => h.Job.Gehalt).Take(3).ToList()))
						   .ToDictionary(k => k.Key, v => v.Value)
						   .Print();
    }

}

public static class LinqExtensions
{
    public static void Print(this IDictionary<string, List<Person>> collection)
    {
		Console.WriteLine("Top-Verdiener nach Berufsgruppe:");
        foreach (var item in collection)
        {
            Console.WriteLine(item.Key);
            foreach (var person in item.Value)
            {
                Console.WriteLine($"  {person.Vorname} {person.Nachname}\t{person.Job.Gehalt}");
            }
        }
    }
}

///////////////////////////////////////////////////////////////////////////////

[DebuggerDisplay("Person - ID: {ID}, Vorname: {Vorname}, Nachname: {Nachname}, GebDat: {Geburtsdatum.ToString(\"yyyy.MM.dd\")}, Alter: {Alter}, " +
	"Jobtitel: {Job.Titel}, Gehalt: {Job.Gehalt}, Einstellungsdatum: {Job.Einstellungsdatum.ToString(\"yyyy.MM.dd\")}")]
public record Person(int ID, string Vorname, string Nachname, DateTime Geburtsdatum, int Alter, Beruf Job, List<string> Hobbies);

public record Beruf(string Titel, int Gehalt, DateTime Einstellungsdatum);

///////////////////////////////////////////////////////////////////////////////