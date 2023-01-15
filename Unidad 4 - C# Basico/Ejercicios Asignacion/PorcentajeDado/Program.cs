double amount, percentage;
Console.WriteLine("Calcular cuanto sería el porcentaje correspondiente de la cantidad y porcentaje dado.");
Console.Write("La cantidad: ");
amount = Convert.ToDouble(Console.ReadLine());
Console.Write("El porcentaje: ");
percentage = Convert.ToDouble(Console.ReadLine());

Console.WriteLine($"El {percentage}% de {amount} es: {percentage/100*amount}");