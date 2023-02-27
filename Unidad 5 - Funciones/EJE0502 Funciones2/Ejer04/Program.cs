using Ejer04;

internal class Program
{
    private static void Main(string[] args)
    {
        int year;
        Console.WriteLine("LEAP YEAR CALCULATOR");
        do
        {
            Console.Write("Insert a year:");
            year = Funciones.IntValue();
            if (year < 1582)
                Console.WriteLine("The year has to be greater than 1582, the first year the Gregorean calendar was employed.");
        } while( year < 1582 );

        Console.Clear();
        Console.WriteLine("LEAP YEAR CALCULATOR");
        if (Funciones.IsLeapYear(year))
            Console.WriteLine("{0} IS a leap year.", year);
        else
            Console.WriteLine("{0} is NOT a leap year.", year);
    }
}