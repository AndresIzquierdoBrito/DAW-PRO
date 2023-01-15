Algoritmo sin_titulo
	Definir position Como Entero;
	Definir num Como Real;
	Escribir "Introduce un numer ";
	Leer num;
	
	Repetir
		Escribir "Introduce la posicion de derecha a izquierda del digito que quieras extraer. ";
		Leer position;
	Hasta Que (abs(num)/10^(position-1) >= 1)
	
	Escribir trunc((abs(num)%10^position)/10^(position-1));

FinAlgoritmo
