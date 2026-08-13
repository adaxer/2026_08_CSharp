namespace GetSetDemo;


/// <summary>
/// This is a demo project to show how to use get and set in C#.
/// Am besten mit ILSpy ansehen (https://github.com/icsharpcode/ilspy)
/// </summary>

internal class Program
{
    static void Main(string[] args)
    {
        var thing = new Thing();
        thing.Secret = "This is a secret";
        thing.Status = "OK";

        Console.WriteLine(thing.Name);
    }
}

public class Thing
{
    // Sollte man nicht machen, da es die Kapselung verletzt. Besser wäre es, eine Property zu verwenden.
    public string Status;

    private string _name;
    public string Name
    {
        get { return _name; }
        set { _name = value; }
    }

    private string _secret;

    public string Secret
    {
        set { _secret = value; }
    }

    public int Age { get; set; }

    public static int InstanceCount { get; private set; }

    public Thing()
    {
        InstanceCount++;
    }


    // Die Vorlage in Java, von der MS abgeschaut hat, ist nicht so elegant.
    private int _orderCount;
    public int getOrderCount() { return _orderCount; }
    public void setOrderCount(int value) { _orderCount = value; }
}
