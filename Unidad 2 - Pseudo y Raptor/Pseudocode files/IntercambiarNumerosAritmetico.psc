// Andres Izquierdo
Algoritmo IntercambiarNumerosAritmetico
	Definir numA, numB como Real;
	Escribir "Introduce dos valores (A y B) numéricos a intercambiar: ";
	Leer numA, numB
	numA <- numA + numB;
	numB <- numA - numB;
	numA <- numA - numB;
	Escribir "Ahora el valor A vale: " numA " y el valor B vale: " numB
FinAlgoritmo
