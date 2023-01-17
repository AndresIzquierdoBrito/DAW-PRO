namespace Ejercicio02
{

    internal class Program
    {
        private static void Main(string[] args)
        {
            decimal temp;
            char tempOption;
            string acceptedTemps = "KF"; //List of chars that are accepted in the program

            Console.WriteLine("Introduce una temperatura en Celcius:");
            temp = GetValidated.DecimalValue();
            temp = GetValidated.Celcius(temp);

            Console.WriteLine("Selecciona que conversion desea realizar: \nF (para convertir a Fahrenheit) \tK (para convertir a Kelvin)");

            do
            {
                tempOption = GetValidated.CharValue();
                tempOption = Char.ToUpper(tempOption);
                if (GetValidated.IsAcceptedAmongChars(tempOption, acceptedTemps))
                    Console.WriteLine("El valor seleccionado tiene que ser: F o K");
            } while (GetValidated.IsAcceptedAmongChars(tempOption, acceptedTemps));

            switch (tempOption)
            {
                case 'F':
                    Console.WriteLine("Cº a Fº: " + Temperature.CelciusToFahrenhreint(temp));
                    break;
                case 'K':
                    Console.WriteLine("Cº to K: " + Temperature.CelciusToKelvin(temp));
                    break;
            }
        }
    }

    class GetValidated
    {
        public static bool IsAcceptedAmongChars(char introducedValue, string acceptedValues)
        {
            int cont = acceptedValues.Length;
            for (int i = 0; i < acceptedValues.Length; i++)
                if (introducedValue == Convert.ToChar(acceptedValues[i]))
                    cont++;
            
            if (cont == acceptedValues.Length)
                return true;
            else
                return false;

        }

        public static char CharValue()
        {
            bool check = false;
            char returnedChar;
            do
            {
                if (char.TryParse(Console.ReadLine(), out returnedChar))
                    check = true;
                else Console.WriteLine("Valor no válido. Valor esparado: CHAR");
            } while (!check);

            return returnedChar;
        }

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
                    check = true;
                else
                {
                    Console.WriteLine("Celsius no puede ser menor que -273.15 Cº");
                    temp = Celcius(DecimalValue());
                }
            } while (!check);

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