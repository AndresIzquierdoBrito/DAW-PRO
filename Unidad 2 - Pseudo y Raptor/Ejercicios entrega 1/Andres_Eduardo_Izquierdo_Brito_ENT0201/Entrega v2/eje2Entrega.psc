 Algoritmo eje2Entrega
	Escribir "Introduce 3 numeros; los dos primeros son los limites de un intervalo de IZQUIERDA a DERECHA, el tercero pertenecera (o no) al intervalo.";
	Leer num1, num2, num3;	
	Si ((num3 >= num1) Y (num3 <= num2)) Entonces
		Escribir "Pertenece"
	SiNo
		Escribir "Error"		
	FinSi;
FinAlgoritmo