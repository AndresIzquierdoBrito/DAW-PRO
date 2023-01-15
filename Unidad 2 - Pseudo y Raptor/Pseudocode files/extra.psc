Algoritmo sin_titulo
	Definir position Como Entero;
	Definir num Como Real;
	
	Repetir
		Escribir "Introduce un numero y la posicion de derecha a izquierda del digito que quieras extraer. ";
		Leer num, position;
	Hasta Que (num/10^(position-1) >= 1)
	
	Segun position Hacer
		1:
			amount <- ' unidades';
		2:
			amount <- ' decenas';
		3:
			amount <- ' centenas';
		4:
			amount <- ' millares';
	Fin Segun
	
	Si position <= 4
		Escribir trunc((num%10^position)/10^(position-1)) amount;
	SiNo
		Escribir trunc((num%10^position)/10^(position-1))
	FinSi
	
	
FinAlgoritmo
