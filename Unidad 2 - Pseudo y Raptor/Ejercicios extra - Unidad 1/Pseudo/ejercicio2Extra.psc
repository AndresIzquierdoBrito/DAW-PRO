Algoritmo ejercicio2Extra
	Escribir "introduce:";
	Leer score;
	
	Si (score < 0) O (score > 1) O TRUNC(score*10)-score*10 <> 0
		Escribir "Puntuacion incorrecta: valores con centecimas y valores menores de 0 y mayores que 1 no aceptados";
	SiNo
		Si (score == 0.0) Entonces
			Escribir "Inaceptable";
			Escribir "No recibe dinero extra."
		SiNo
			Si (score == 0.4) Entonces
				Escribir "Aceptable";
				Escribir "Dinero por puntuacion: " score*2400;
			SiNo
				Si (score >= 0.6 Y score <= 1)
					Escribir "Meritorio";
					Escribir "Dinero por puntuacion: " score*2400;
				SiNo
					Escribir "Solo se valoran las puntuaciones: 0.0, 0.4, 0.6 o mas.";
				FinSi
			FinSi
		FinSi
	FinSi
FinAlgoritmo
