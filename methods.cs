public static bool FilesExists()
        {
            if (!File.Exists(EdadesCSV))
            {
                Console.WriteLine("Cannot find base CSV file.");
                return false;
            }

            if (!File.Exists(log))
            {
                if (!CreateFile(log))
                {
                    Console.WriteLine("Cannot create error log");
                    return false;
                }
            }
            else
            {
                File.WriteAllText(log, string.Empty); // Si el archivo log ya existe, borra su contenido
            }
            return true;
        }
//--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
        const string NOMBREFICH = "Datos notas.csv";
        public static bool ArchivoExiste() => File.Exists(NOMBREFICH);

//--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        public static bool LoadFile()
        {
            try
            {
                lines = File.ReadAllLines(EdadesCSV).ToList();           // Guardo todos los contenidos del CSV en una lista: cada linea, un espacio en la lista
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }
//--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        static bool CreateFile(string filename)
        {
            try
            {
                File.CreateText(filename).Close();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }
//--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

        public static int IntValue(int lowerLimit = int.MinValue, int upperLimit = int.MaxValue)
        /* Defino dos parametros para definir el rango de valores, al asingarles MaxValue/MinValue, 
           si no se le pasa un numero no hay limite (mas alla del limite de memoria de int) */
        {
            int userInput;
            bool check = false;
            if (lowerLimit != int.MinValue && upperLimit != int.MaxValue)
                Console.Write(" between " + lowerLimit + " and " + upperLimit);
            Console.WriteLine(":");
            do
            {
                if (!int.TryParse(Console.ReadLine(), out userInput))
                    Console.WriteLine("Input value not valid. Enter a new value matching the requirements.");
                else if (userInput < lowerLimit || userInput > upperLimit)
                    Console.WriteLine("Input value not within the specified range. Enter a new value between " + lowerLimit + " and " + upperLimit + ":");
                else 
                    check = true;
            } while (!check);
            return userInput;
        }