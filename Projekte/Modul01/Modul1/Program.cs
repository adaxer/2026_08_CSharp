Console.WriteLine("Hello, World!");

// Fang mit 20 (typisches Alter)
int number = 20;

/* Mehrzeiliger Kommentar:
 * dsfjldasfldsalf
 * kdsljfaldla
 */

/// ldsaflkösakfö
/// sdfadsf
/// sadfdsafa
/// sadfafs
/// 

Console.WriteLine($"Die Zahl ist: {number}");

if (args.Length > 0 && args[0] == "--wait")
{
    Console.WriteLine("Programmende - beliebige Taste drücken...");
    ConsoleKeyInfo keyInfo = Console.ReadKey();
    if(keyInfo.Key == ConsoleKey.Enter)
    {
        Console.WriteLine("Enter-Taste wurde gedrückt.");
    }
    else
    {
        Console.WriteLine($"Taste {keyInfo.Key} wurde gedrückt.");
    }
}

