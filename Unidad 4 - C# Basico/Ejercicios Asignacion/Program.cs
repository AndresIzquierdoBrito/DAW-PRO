double valor;
Console.WriteLine("Introduce un valor: ");
valor = Convert.ToDouble(Console.ReadLine());



Console.WriteLine($"El valor de las centenas del numero {valor} es: {(Convert.ToInt32(valor) / 100) % 10}");
