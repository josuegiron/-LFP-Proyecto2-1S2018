
Terminales = { id, numero, comentario, cadena, operador, '<', '>', '/','diseño', 'variables', 'construccion', 'nombre', 'tipo', 'valor', ':', 'terreno', 'pared' 'ventana','puerta', 'suelo' 'ancho' 'largo' 'color', 
	'alto','inicio' 'fin', ';', ',', 'longitud', 'pared_asociada', 'redonda', 'cuadrada', 'Potencia', '=', 'cadena', 'entero', 'doble'
}

No Terminales = { }

S = <INICIO>, 

P = {
	<INICIO> ::= '<' 'diseño' '>' <VARIABLES> <CONSTRUCCION> '<' '/' 'diseño' '>'

	<COMENTARIO> ::= <COMENTARIO_LINEAL> | <COMENTARIO_MULTILINEA> | <EPSILON>

	<VARIABLES> ::=  '<' 'variables' '>' <CUERPO_DE_VARIABLE> 
	<CUERPO_VARIABLES> ::= <VARIABLE> <OTRA_VARIABLE>
	<VARIABLE> ::= <NOMBRE> <TIPO> <VALOR> 
	<OTRA_VARIABLE> ::= ';' <VARIABLE> <OTRA_VARIABLE> | <EPSILON>
	<NOMBRE> ::= 'nombre' ':' id
	<TIPO> ::= 'tipo' = 'cadena' | 'entero' | 'doble'
	<VALOR> ::= 'valor' = numero | <EXPRESION> | id | cadena
	<EXPRESION> ::= numero operador numero <OTRA_EXPRESION>
	<OTRA_EXPRESION> ::= operador numero <OTRA_EXPRESION> | <EPSILON>

	<CONSTRUCCION> ::= '<' 'construccion' '>' <TERRENO> <PARED> <VENTANA> <PUERTA> <SUELO> '<' '/' 'construccion' '>'
	<TERRENO> ::= '<' 'terreno' '>' <ANCHO> <LARGO> '<' '/' 'terreno' '>'
	<ANCHO> ::= 'ancho' '=' numero
	<LARGO> ::= 'largo' '=' numero
	<PARED> ::= '<' 'pared' '>' <CUERPO_PARED> '<' '/' 'pared' '>'
	<CUERPO_PARED> ::= <PARED






	<MULTIPLICACION> ::= 'Multiplicar' <OPERACION_BINARIA>
	<DIVISION> ::= 'Dividir' <OPERACION_BINARIA>
	<POTENCIA> ::= 'Potencia' <OPERACION_BINARIA>
	<RAIZCUADRADA> ::= 'RaizCuadrada' <OPERACION_UNARIA> 
	<SENO> ::= 'Seno' <OPERACION_UNARIA> 
	<COSENO> ::= 'Coseno' <OPERACION_UNARIA> 
	<TANGENTE> ::= 'Tangente' <OPERACION_UNARIA>
	<OPERACION_BINARIA> ::= '(' (<OPERACION> | numero | id) ',' (<OPERACION> | numero | id) ')'
	<OPERACION_UNARIA> ::= '(' <OPERACION> | numero | id ')'
	// FUNCIONES DE <FUNCIONES>
	<FUNCION> ::= 'Inicio' 'Funcion' <COMENTARIO> <NOMBRE> ',' <COMENTARIO> <VALOR> <COMENTARIO> 'Fin' 'Funcion' <COMENTARIO>
	<OTRA_FUNCION> ::= <FUNCION> <OTRA_FUNCION> | <EPSILON>
	// FUNCIONES DE <GRAFICAS>
	<GRAFICA> ::= 'Inicio' 'grafica' <COMENTARIO> <NOMBRE> ',' <X_POSITIVO> ',' <COMENTARIO> <X_NEGATIVO> ',' <COMENTARIO> <Y_POSITIVO> ',' <COMENTARIO> <Y_NEGATIVO> ',' <COMENTARIO> <ANCHO> ',' <COMENTARIO> <LARGO> ',' <COMENTARIO> <RUTA> ',' <COMENTARIO> <NOMBRE_FUNCION> <COMENTARIO> 'Fin' 'grafica' <COMENTARIO>
	<X_POSITIVO> ::= 'x_positivo' = numero | <OPERACION> | id
	<X_NEGATIVO> ::= 'x_negativo' = numero | <OPERACION> | id
	<Y_POSITIVO> ::= 'y_positivo' = numero | <OPERACION> | id
	<Y_NEGATIVO> ::= 'y_negativo' = numero | <OPERACION> | id
	<ANCHO> ::= 'ancho' = numero | <OPERACION> | id
	<LARGO> ::= 'largo' = numero | <OPERACION> | id
	<RUTA> ::= 'ruta' = <CADENA>
	<NOMBRE_FUNCION> ::= 'funcion' = id
	<CADENA> ::= cadena
	// Comentarios
	<COMENTARIO_LINEAL> ::= comentarioLineal
	<COMENTARIO_MULTILINEA> ::= comentarioMultilieal
}