double miles, meters;
Console.WriteLine("Introduce un valor en millas marinas: ");
Console.Write("Millas: ");
miles = Convert.ToDouble(Console.ReadLine());
meters = miles * 1852;
Console.WriteLine("\t↓");
Console.WriteLine("Metros: " + meters);
