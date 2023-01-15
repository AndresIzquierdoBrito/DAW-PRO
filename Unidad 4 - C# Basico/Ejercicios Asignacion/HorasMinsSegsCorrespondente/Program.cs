int hours, minutes, seconds;
Console.WriteLine("Introduce una cantidad de segundos: ");
Console.Write("Segundos totales: ");
seconds = Convert.ToInt32(Console.ReadLine());

hours = seconds/3600;
minutes = (seconds%3600)/60;
seconds = (seconds%3600)%60;

Console.WriteLine($"{hours} horas {minutes} minutos {seconds} segundos");
