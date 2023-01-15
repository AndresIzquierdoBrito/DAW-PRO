using System;

internal class Program
{
    private static void Main(string[] args)
    {
        int n, num, rev, dig;
        num = Convert.ToInt32(Console.ReadLine());
        n = num;
        rev = 0;
        while (num > 0)
        {
            dig = num % 10;
            rev = rev * 10 + dig;
            num = num / 10;
        }
        if (n == rev)
            Console.WriteLine("El numero es capicua");
        else
            Console.WriteLine("El numero no es capicupa");
    }
}