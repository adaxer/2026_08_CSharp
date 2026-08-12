namespace Modul05;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        var someResult = MakeUpper("Hello, World!");
        Console.WriteLine(someResult.name);

        (string newValue, bool changed) = MakeUpper("HELLO WORLD");

        Addiere(1, 2);
        Addiere(3, 4, 5);

        int[] values = { 1, 2, 3 };
        Addiere(values);

        // Out- und ref-Beispiel
        bool isOk = TryGetLength("123", out int length);
        if (isOk)
        {
            Console.WriteLine(length);
        }

        bool isInt = int.TryParse("123", out int number);
        isInt = int.TryParse("einszweidrei", out number);
        number = 10;

        DoubleNumber(ref number);
        DontDoubleNumber(number);
    }

    private static void DontDoubleNumber(int input)
    {
        // This method does not modify the number
        input *= 2;
    }

    private static void DoubleNumber(ref int input)
    {
        input *= 2;
    }

    private static bool TryGetLength(string input, out int length)
    {
        length = 0;
        if (input != null)
        {
            length = input.Length;
            return true;
        }
        return false;
    }

    static (string name, bool changed) MakeUpper(string input)
    {
        var computed = input.ToUpper();
        var result = (computed, computed != input);
        return result;
    }

    static int Addiere(params int[] values)
    {
        int sum = 0;
        foreach (var value in values)
        {
            sum += value;
        }
        return sum;
    }

    static int Addiere(int a, int b, int c)
    {
        return a + b + c;
    }
}
