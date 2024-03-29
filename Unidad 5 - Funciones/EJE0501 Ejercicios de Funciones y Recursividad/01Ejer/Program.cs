﻿namespace Ejercicio02
{

    internal class Program
    {
        private static void Main(string[] args)
        {
            decimal temp;
            
            Console.WriteLine("Introduce una temperatura en Celcius:");
            temp = GetValidated.DecimalValue();
            temp = GetValidated.Celcius(temp);
            
            Console.WriteLine("Cº a Fº: " + Temperature.CelciusToFahrenhreint(temp));
            Console.WriteLine("Cº to K: " + Temperature.CelciusToKelvin(temp));
        }
    }

    class GetValidated
    {
        public static decimal DecimalValue()
        {
            bool check = false;
            decimal returnedDecimal;
            do
            {
                
                if (decimal.TryParse(Console.ReadLine(), out returnedDecimal))
                    check = true;
                else Console.WriteLine("Valor no válido. Valor esperado: DECIMAL");
            } while (!check);

            return returnedDecimal;
        }

        public static decimal Celcius(decimal temp)
        {
            bool check = false;
            do
            {
                if (temp > -273.15m)
                {
                    check = true;
                }
                else
                {
                    Console.WriteLine("Celsius no puede ser menor que -273.15 Cº");
                    temp = Celcius(DecimalValue());
                }
            } while(!check);
            
            return temp;
        }
    }
    class Temperature
    {
        public static decimal CelciusToFahrenhreint(decimal temp)
        {
            return temp * (9 / 5) + 32;
        }

        public static decimal CelciusToKelvin(decimal temp)
        {
            return temp + 273.15m;
        }

    }
}