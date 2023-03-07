namespace ENT0502
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            if (Ficheros.FilesExists() && Ficheros.LoadFile())
            {
                if (!Ficheros.VerifyCSVAges())
                {
                    //Creat archivo finals function
                }
            }
        }
    }
}