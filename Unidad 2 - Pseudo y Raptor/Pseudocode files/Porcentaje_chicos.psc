//Andres Izquierdo
Algoritmo Porcentaje_chicos
	Definir chicos, chicas, procentaje Como Entero;
	Escribir "Introduce el numero de chicos y, despues, de chicas, para calcular el porcentaje.";
	Leer chicos, chicas;
	Escribir "% de chicos: " redon((chicos/(chicos+chicas)*10000))/100 "% y el % de chicas; " redon((chicas/(chicos+chicas))*10000)/100 "%";
	
FinAlgoritmo 
