Algoritmo getHundreds
	Definir num, mil, cent, dec, unit Como Real
	Escribir "Introduce un numero: "
	Leer num;
	// Millares
	mil = trunc(num/1000)%10
	Si mil = 1 O mil = -1
		Escribir mil " millar";
	Sino
		Escribir mil " millares";
	FinSi
	// Centenas
	cent = trunc((num%1000)/100)
	Si cent = 1 O cent = -1
		Escribir cent " centena";
	Sino 
		Escribir cent " centenas";
	FinSi
	// Decenas
	dec = trunc((num%100)/10)
	Si dec = 1 O dec = -1
		Escribir dec " decena";
	Sino 
		Escribir dec " decenas";
	FinSi
	// Unidades
	unit = num%10;
	Si  unit  = 1 O unit = -1
		Escribir  unit " unidad";
	Sino 
		Escribir unit  " unidades";
	FinSi
	
	
	//Extra 
	Escribir " ";
	Si num > 9999 
		Escribir "relaja mas de 4 digitos ya es mucho para mi"
	FinSi;
FinAlgoritmo
