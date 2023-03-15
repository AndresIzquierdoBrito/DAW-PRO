using EXA05;

internal class Program
{
    private static void Main()
    {
        if (Ficheros.FilesExists() && Ficheros.LoadFile())
        {
            if (!Ficheros.ValidateCSVData())
                Console.WriteLine("Program finished with errors while validating the CSV data.");
            else if(!Ficheros.GenerateProcessedCSV())
                Console.WriteLine("Program finished with errors while generating the processed CSV");
            else if (!Ficheros.FillProcessedCSV())
                Console.WriteLine("Program finished with errors while filling the processed CSV.");
            else
            {
                Ficheros.GetUserInput();
            }
        }
        else
            Console.WriteLine("Program finished with errors while loading the CSV.");

        Console.ReadKey();
    }
}