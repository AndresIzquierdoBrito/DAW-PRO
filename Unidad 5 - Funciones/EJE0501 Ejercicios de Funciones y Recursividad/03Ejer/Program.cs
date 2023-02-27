namespace Ejer03
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Introduce un valor entero, solo entero, intenta poner otra cosa, atrevete.");
            GetValidated.IntValue();
            Console.WriteLine("Te dije, solo entero jeje");
        }
    }
    class GetValidated
    {
        public static int IntValue()
        {
            bool check = false;
            int returnedInt;
            do
            {
                if (int.TryParse(Console.ReadLine(), out returnedInt))
                    check = true;
                else Console.WriteLine("Valor no válido. Valor esperado: ENTERO");
            } while (!check);

            return returnedInt;
        }
    }

}