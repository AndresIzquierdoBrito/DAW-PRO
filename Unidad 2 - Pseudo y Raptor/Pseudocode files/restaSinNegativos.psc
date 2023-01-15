Algoritmo restaSinNegativos
	Definir num1, num2 Como Real
	Escribir "Introduzca dos numeros a restar"
	Leer num1, num2;
	
	Mientras num2 > num1 Hacer
		Escribir "El resultado no puede dar un numero negativo, introduzca el segundo numero de nuevo";
		Leer num2
	Fin Mientras
	
	Escribir num1 " - " num2 " = " num1 - num2;
FinAlgoritmo
