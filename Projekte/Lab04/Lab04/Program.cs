
namespace Lab04;

public class Program
{
    private static void Main(string[] args)
    {
        // Aufruf von Kommandozeile z.B. mit:
        // Lab04.exe < in.txt > out.txt 2> err.txt

        bool isDone = false;
        double number1 = 0;
        double number2 = 0;
        double result = 0;
        Operation operation = Operation.Add;

        while (!isDone)
        {
            // Console.Clear();
            Console.Write("Zahl1: ");
            number1 = double.Parse(Console.ReadLine());
            Console.Write("Zahl2: ");
            number2 = double.Parse(Console.ReadLine());

            Console.WriteLine("Operation auswählen: ");
            Console.WriteLine("1. Add");
            Console.WriteLine("2. Subtract");
            Console.WriteLine("3. Multiply");
            Console.WriteLine("4. Divide");
            operation = (Operation)(int.Parse(Console.ReadLine()));
            //operation = Enum.Parse(typeof(Operation, Console.ReadLine());
            //operation = Enum.Parse<Operation>(Console.ReadLine());

            switch (operation)
            {
                case Operation.Add:
                    result = number1 + number2;
                    break;
                case Operation.Subtract:
                    result = number1 - number2;
                    break;
                case Operation.Multiply:
                    result = number1 * number2;
                    break;
                case Operation.Divide:
                    result = number1 / number2;
                    break;
                default:
                    Console.WriteLine("Keine Operation gefunden");
                    break;
            }
            Console.WriteLine($"Ergebnis: {result}");
            Console.WriteLine("Nochmal (J/N)?");
            string key = Console.ReadLine();
            if (key.ToUpper() != "J")
            {
                isDone = true;
            }
        }
    }
}

enum Operation
{
    Add = 1,
    Subtract,
    Multiply,
    Divide
}
