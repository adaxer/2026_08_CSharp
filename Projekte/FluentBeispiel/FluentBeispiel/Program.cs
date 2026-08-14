namespace FluentBeispiel;

internal class Program
{
    static void Main(string[] args)
    {
        var logger = new LoggerConfiguration()
            .WriteTo.Console()
            .WriteTo.File("log.txt")
            .CreateLogger();
    }
}

public class LoggerConfiguration
{
    internal object CreateLogger()
    {
        return new Logger();
    }

    public Targets WriteTo => new Targets();
}

public class Targets
{
    public LoggerConfiguration Console()
    {
        // Merkt sich dass Console verwendet werden soll
        return new LoggerConfiguration();
    }

    public LoggerConfiguration File(string path)
    {
        // Merkt sich dass File verwendet werden soll
        return new LoggerConfiguration();
    }
}

public class Logger
{
    
}