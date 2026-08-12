using System.Diagnostics;

namespace Linq_LabCode;

public class LabCode
{
	static void Main(string[] args)
	{
		List<Car> cars = new List<Car>
		{
			new Car(0, 251, Brand.BMW),
			new Car(1, 274, Brand.BMW),
			new Car(2, 146, Brand.BMW),
			new Car(3, 208, Brand.Audi),
			new Car(4, 189, Brand.Audi),
			new Car(5, 133, Brand.VW),
			new Car(6, 253, Brand.VW),
			new Car(7, 304, Brand.BMW),
			new Car(8, 151, Brand.VW),
			new Car(9, 250, Brand.VW),
			new Car(10, 217, Brand.Audi),
			new Car(11, 125, Brand.Audi)
		};
	}
}

[DebuggerDisplay("ID: {ID}, Brand: {Brand}, Max velocity: {MaxV} - {typeof(Car).FullName}")]
public class Car
{
	public int ID;
	public int MaxV;
	public Brand Brand;
	public List<Seat> SeatList;

	public Car(int id, int v, Brand b)
	{
		ID = id;
		MaxV = v;
		Brand = b;
		SeatList = new();

		int sitze = v <= 150 ? 6 : v <= 250 ? 5 : 4;

		for (int i = 0; i < sitze; i++)
			SeatList.Add(new Seat());

		for (int i = 0; i < v % (sitze + 1); i++)
			SeatList[i].IsOccupied = true;
	}
}

public class Seat
{
	public bool IsOccupied;
}

public enum Brand
{
	Audi, BMW, VW
}