namespace ENT0502
{
    internal class Program
    {
        private static void Main()
        {
            if (Ficheros.FilesExists() && Ficheros.LoadFile())      // Verificacion si archivos existen y si se pueden crear y despues se cargan todos los datos del CSV en una lista, en caso contrario el programa no avanza
            {
                if (!Ficheros.VerifyCSVAges())                      // Verificacion de datos del CSV, una vez ecnontrado un error, se guarda en error.log y se termina el programa.
                    Console.WriteLine("Program found errors, check error.log for more information.");
                else
                    if (Ficheros.GenerateCSVAvgPopulation())        // Genera el CSV media_poblacion.csv con los datos tratados ya previamente guardados en una serie de listas estaticas en Ficheros
                        Console.WriteLine("Program finished succesfully");
            }
        }
    }
}