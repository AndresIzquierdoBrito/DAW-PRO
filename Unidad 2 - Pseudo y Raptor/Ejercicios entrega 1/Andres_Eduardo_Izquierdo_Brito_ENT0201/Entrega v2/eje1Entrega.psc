Algoritmo eje1Entrega
	Escribir "Introduce un numero entero."
	Leer num;
	Si (trunc(num) == num) Y (trunc(num/2) == (num/2)) Entonces
			Si ((num/2)%2 <> 0) Entonces
				Escribir "Si cumple" //La mitad del numero es impar, por ende cumple
			Sino
				Escribir "No cumple" //La mitad del numero es par, por ende no cumple.
			FinSi
	SiNo
		Escribir "No cumple" //El numero introducido no es entero o la mitad del numero tiene decimales, por ende no cumple.
	FinSi
FinAlgoritmo