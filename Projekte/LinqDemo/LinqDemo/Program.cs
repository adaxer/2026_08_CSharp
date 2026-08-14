namespace LinqDemo;

internal class Program
{
    static void Main(string[] args)
    {
        var ints = new List<int> { 1, 2, 3, 4, 5, 6,7,8,9 };

        var query = ints.Where(i => i % 2 == 0);
        ints.Add(10);

        // var evens = query.ToList();  // Ausgeführt
        var query2 = query.OrderDescending();     // Noch nicht ausgeführt

        var element = query2.Last();    // Ausgeführt

        foreach (var i in query2)       // Ausgeführt
        {
            Console.WriteLine(i);
        }

        var queue = new Queue<int>(ints);
        var lastInQueue = queue.Last(); // Ausgeführt

        var stack = new Stack<int>(ints);
        var content = stack.Select(i => i.ToString()).ToList(); // Ausgeführt

        var sameSequence = stack.SequenceEqual(queue);
        sameSequence = stack.IsEquivalentTo(queue);

        sameSequence = LinqExtensions.IsEquivalentTo(stack, queue);

        stack.Pop();
        stack.Pop();
        stack.Pop();

        var sqlWay = from l in ints
                     where l < 5
                     orderby l descending
                     select l;

        var sqlList = sqlWay.ToList();

        var orderedList = ints
            .Where(i => i % 2 == 0)
            .OrderDescending()
            .Select(i => i)
            .ToList();

        var teil1 = Enumerable.Where(ints, i => i % 2 == 0);
        var teil2 = Enumerable.OrderDescending(teil1);
        var teil3 = Enumerable.Select(teil2, i => i);
        orderedList = Enumerable.ToList(teil3);

    }
}

public static class LinqExtensions
{
    public static bool IsEquivalentTo<T>(this IEnumerable<T> first, IEnumerable<T> second)
    {
        return first.Count() == second.Count() && !first.Except(second).Any();
    }
}
