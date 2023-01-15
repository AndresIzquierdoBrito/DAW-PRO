double price;
int discount;
Console.WriteLine("Hello, World!");
Console.Write("Precio: ");
price = Convert.ToDouble(Console.ReadLine());
Console.Write("Descuento aplicado: ");
discount = Convert.ToInt32(Console.ReadLine());

Console.WriteLine($"Dado el precio: {price:f2}€ y descuento: {discount} el precio final sería: {price - (discount / 100):f2}");
