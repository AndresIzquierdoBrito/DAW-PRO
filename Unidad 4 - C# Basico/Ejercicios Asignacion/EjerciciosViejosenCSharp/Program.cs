double porcentajeChicos, porcentajeChicas;
int cantidadChicos, cantidadChicas;
Console.WriteLine("Introduce por separado el numero de chicos y chicas.");
Console.Write("Numero de chicos: ");
cantidadChicos = Convert.ToInt32(Console.ReadLine());
Console.Write("Numero de chicas: ");
cantidadChicas = Convert.ToInt32(Console.ReadLine());

porcentajeChicos = Convert.ToDouble(cantidadChicos) / (cantidadChicos + cantidadChicas) * 100;
porcentajeChicas = Convert.ToDouble(cantidadChicas) / (cantidadChicos + cantidadChicas) * 100;

Console.WriteLine($"El porcentaje de chicos es : {porcentajeChicos:f2}% y el porcentaje de chicas es: {porcentajeChicas:f2}%");
