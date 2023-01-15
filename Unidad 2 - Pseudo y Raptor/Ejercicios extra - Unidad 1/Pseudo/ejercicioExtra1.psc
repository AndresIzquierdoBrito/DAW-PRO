Algoritmo ejercicioExtra1
	Escribir "Introduce tu renta anual:";
	Leer rentaAnual;
	Si (rentaAnual < 0) Entonces
		Escribir "Tu renta anual no puede ser inferior a 0.";
		Si (rentaAnual < 10000) Entonces 									// Menos de 10.000 euros
			Escribir "Tu tipo impositivo es del 5% (Menos de 10.000 euros)"; 
		SiNo		
			Si (rentaAnual >= 10000 Y rentaAnual < 20000) Entonces 			// Entre 10.000 euros y 20.000 euros
				Escribir "Tu tipo impositivo es del 15% (Entre 10.000 euros y 20.000 euros)";
			SiNo
				Si (rentaAnual >= 20000 Y rentaAnual < 35000) Entonces		// Entre 20.000 eurosy 35.000 euros
					Escribir "Tu tipo impositivo es del 20% (Entre 20.000 eurosy 35.000 euros)";
				SiNo
					Si (rentaAnual >= 35000 Y rentaAnual < 65000) Entonces	// Entre 35.000 eurosy 60.000 euros
						Escribir "Tu tipo impositivo es del 30% (Entre 35.000 eurosy 60.000 euros)";
					SiNo													// Mas de 60.000 euros
						Escribir "Tu tipo impositivo es del 45% (Mas de 60.000 euros)";
					FinSi;
				FinSi;
			FinSi;
		FinSi
	FinSi;	
FinAlgoritmo
