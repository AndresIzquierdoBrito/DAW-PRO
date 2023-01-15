Algoritmo discount
	Definir cost Como Real
	Definir disc Como Entero;
	Escribir "Introduce el precio de la prenda y seguidamente su descuento: ";
	Leer cost, disc;
	Mientras cost < 0
		Escribir "El precio no puede ser menor que 0. Pruebe otra vez.";
		Leer cost;
	FinMientras
	Mientras disc > 100 O disc < 0 Hacer
		Escribir "Tiene que ser un descuento por debajo de 100 y por encima de 0. Pruebe otra vez.";
		Leer disc;
	Fin Mientras
	Escribir "El precio desconatado es: " cost*((100-disc)/100) "$ (Precio original: " cost "$)";
FinAlgoritmo
