namespace M011_Linq;

public static class ExtensionMethods
{	
	public static string PrintList<T>(this IEnumerable<T> list)
	{
		return list.Aggregate(new StringBuilder(), (agg, fzg) => agg.Append(fzg.AppendLine($"Das Fahrzeug hat die Marke {fzg.Marke} und kann maximal {fzg.MaxGeschwindigkeit} fahren.").ToString());
	}
}
