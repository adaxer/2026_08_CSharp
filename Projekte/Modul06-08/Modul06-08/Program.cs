namespace Modul06_08;

internal class Program
{
    static void Main(string[] args)
    {
        PointStruct? nullablePointStruct = null;
        Nullable<PointStruct> theSameThing=null;

        PointStruct emptyPoint;
        // emptyPoint.X++; Darf man nicht verwenden wenn nicht zugewiesen
        PointStruct p = new PointStruct(3, 4);
        ChangeX(p);
        ChangePoint(ref p);
        ChangeStructProperty(p);
        // p = null; // Not allowed for structs

        PointClass emptyPointClass;
        PointClass pc = new PointClass(1, 2);
        ChangeInstanceProperty(pc);
        pc = null;
    }

    private static void ChangeInstanceProperty(PointClass pc)
    {
        pc.X++;
        pc.Y++;
    }

    private static void ChangeStructProperty(PointStruct p)
    {
        p.X += 1;
        p.Y += 1;
    }

    private static void ChangePoint(ref PointStruct p)
    {
        p=new PointStruct(p.X+1, p.Y+1);
    }

    private static void ChangeX(PointStruct p)
    {
        p = new PointStruct(p.X + 1, p.Y + 1);
    }
}

public struct PointStruct
{
    public int X { get; set; }
    public int Y { get; set; }
    public PointStruct(int x, int y)
    {
        X = x;
        Y = y;
    }
    public override string ToString()
    {
        return $"({X}, {Y})";
    }
}
public class PointClass
{
    public int X { get; set; }
    public int Y { get; set; }
    public PointClass(int x, int y)
    {
        X = x;
        Y = y;
    }
    public override string ToString()
    {
        return $"({X}, {Y})";
    }
}

public class BusinessObject
{
    public int? Id { get; set; } = null;

    // Andere Properties
}