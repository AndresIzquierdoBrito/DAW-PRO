Algoritmo sin_titulo
	Definir nota Como Real
	Escribir "Introduce tu nota:";
	Leer nota;
	
	Mientras nota > 10 O nota < 0
		Escribir "La nota no puede ser superior a 10 o inferior a 0. Introduce la nota de nuevo.";
		Leer nota;
	FinMientras
	
	Si nota < 5 
		Escribir "Suspenso. (" nota ",  0 a 4,9: suspenso)";
	SiNo
		Si nota >= 5 Y nota < 7
			Escribir "Aprobado. (" nota ", 5 a 6,9: aprobado)";
		SiNo
			Si nota >= 7 Y nota < 9
				Escribir "Notable. (" nota ",  7 a 8,9: notable.)";
			SiNo
				Escribir "Sobresaliente. (" nota ", 9 a 10: sobresaliente)";
			FinSi
		FinSi
	FinSi
FinAlgoritmo
