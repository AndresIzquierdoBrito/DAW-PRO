// Andres Izquierdo
Algoritmo IntercambiarNumeros
	Definir numA, numB, storeNumber como Real;
	Escribir "Introduce dos valores (A y B) numéricos a intercambiar: ";
	Leer numA, numB
	// Guardo en una diferente variable el valor de B, para no perder su valor una vez se asigne el valor de numA dentro de numB
	storeNumberB <- numB;
	numB <- numA;
	// Asigno a numA el valor guardado de numB
	numA <- storeNumber;
	Escribir "Ahora el valor A vale: " numA " y el valor B vale: " numB
FinAlgoritmo
