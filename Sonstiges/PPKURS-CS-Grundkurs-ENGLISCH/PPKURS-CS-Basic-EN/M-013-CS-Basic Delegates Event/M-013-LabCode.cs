public class Program
{
	static void Main(string[] args)
	{
		//Write your own code here
	}

	public void Addition(double num1, double num2)
	{
		Console.WriteLine($"{num1} + {num2} = {num1 + num2}");
	}

	public void Subtraction(double num1, double num2)
	{
		Console.WriteLine($"{num1} - {num2} = {num1 - num2}");
	}

	public void Multiplication(double num1, double num2)
	{
		Console.WriteLine($"{num1} * {num2} = {num1 * num2}");
	}
}

public class DivisionCalculator
{
	public void Division(double num1, double num2)
	{
		Console.WriteLine($"{num1} : {num2} = {num1 /  num2}");
	}
}

// public bool CheckPrime(int num)
// {
	// if (num % 2 == 0)
		// return false;
	
	// for (int i = 3; i <= num / 2; i += 2)
	// {
		// if (num % i == 0)
		// {
			// return false;
		// }
	// }
	// return true;
// }