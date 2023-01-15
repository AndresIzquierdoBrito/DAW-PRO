int  numA, numB;
Console.WriteLine("Introduce dos valores:valor A y un valor B");
Console.Write("Valor A: ");
numA = Convert.ToInt32(Console.ReadLine());
Console.Write("Valor B: ");
numB = Convert.ToInt32(Console.ReadLine());


numA = numA + numB;
numB = numA - numB;
numA = numA - numB;

Console.WriteLine($"Valor A: {numA} Valor B: {numB}");