namespace Lab05;

public class Program
{
    public Program()
    {
        this.Id = ++InstanceCount;
    }

    public int Id { get; private init; }

    public static int InstanceCount { get; private set; } = 0;

    private static void Main(string[] args)
    {
        bool isDone = false;
        double number1 = 0;
        double number2 = 0;
        double result = 0;
        Operation operation = Operation.Add;

        var p = new Program();
        p.DoStuff();
        Program.GetNumber("");
        
        //p.Id = 0;
        //Program.InstanceCount = 0;

        while (!isDone)
        {
            // Console.Clear();
            number1 = GetNumber("Zahl 1 eingeben: ");
            number2 = GetNumber("Zahl 2 eingeben: ");

            operation = GetOperation("Operation auswählen:\n1. Add\n2. Subtract\n3. Multiply\n4. Divide");

            result = DoCalculation(number1, number2, operation);

            Console.WriteLine($"Operation {operation} angewandt auf {number1} und {number2} ergibt: {result}");
            Console.WriteLine("Nochmal (J/N)?");
            string key = Console.ReadLine();
            if (key.ToUpper() != "J")
            {
                isDone = true;
            }
        }
    }

    private static Operation GetOperation(string message)
    {
        Console.WriteLine(message);
        Operation result = Operation.Add;
        while (!Enum.TryParse<Operation>(Console.ReadLine(), out result) || !Enum.GetValues<Operation>().Contains(result))// ((int)result<1) || (int)result>4)
        {
            Console.WriteLine("Keine Operation - Bitte nochmal.");
        }
        return result;
    }

    private static double DoCalculation(double number1, double number2, Operation operation)
    {
        switch (operation)
        {
            case Operation.Add:
                return number1 + number2;
            case Operation.Subtract:
                return number1 - number2;
            case Operation.Multiply:
                return number1 * number2;
            case Operation.Divide:
                return number1 / number2;
            default:
                Console.WriteLine("Keine Operation gefunden");
                return 0;
        }
    }

    private static double GetNumber(string message)
    {
        Console.Write(message);
        double result = 0;
        while (!double.TryParse(Console.ReadLine(), out result))
        {
            Console.WriteLine("Keine Kommazahl - Bitte nochmal.");
        }
        return result;
    }

    public void DoStuff()
    {
        Console.WriteLine($"Program {this.Id} doing stuff");
    }
}

// Speicher
// Program 8Bytes, Id(Wert1):4 Bytes
// Program 8Bytes, Id(Wert2):4 Bytes


enum Operation
{
    Add = 1,
    Subtract,
    Multiply,
    Divide
}

