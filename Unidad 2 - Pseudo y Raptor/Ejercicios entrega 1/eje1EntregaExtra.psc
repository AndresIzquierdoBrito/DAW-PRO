Algoritmo eje1EntregaExtra
	Escribir "Introduce un valor entero";
	Leer num;
	
	Mientras trunc(num) <> num
		Escribir "El numero no es entero, introducelo de nuevo";
		Leer num;
	FinMientras
	
	Si trunc(num/2)%2 <> 0
		Escribir "Si cumple. (El numero " num " es el doble de un numero impar (" trunc(num/2) ")";
	SiNo
		Escribir "No cumple. (El numero " num " NO es el doble de un numero impar (" trunc(num/2) ")";
	FinSi
FinAlgoritmo
