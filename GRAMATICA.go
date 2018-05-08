Terminales = { id, numero, comentario, cadena, operador, '<', '>', '/','diseño', 'variables', 'construccion', 'nombre', 'tipo', 'valor', ':', 'terreno', 'pared' 'ventana','puerta', 'suelo' 'ancho' 'largo' 'color', 
	'alto','inicio' 'fin', ';', ',', 'longitud', 'pared_asociada', 'redonda', 'cuadrada', 'Potencia', '=', 'cadena', 'entero', 'doble'
}

No Terminales = { }

S = <DESIGN>, 

Producciones = {
	<DESIGN> ::= '<' 'diseño' '>' <VARIABLES> <CONSTRUCCION> '<' '/' 'diseño' '>'

	<COMENTARIO> ::= <COMENTARIO_LINEAL> | <COMENTARIO_MULTILINEA> | <EPSILON>

	<VARIABLES> ::=  '<' 'variables' '>' <CUERPO_DE_VARIABLE> '<' '/' 'variables' '>'
	<CUERPO_VARIABLES> ::= <VARIABLE> <OTRA_VARIABLE>
	<VARIABLE> ::= <NOMBRE> <TIPO> <VALOR> 
	<NOMBRE> ::= 'nombre' ':' id
	<TIPO> ::= 'tipo' = 'cadena' | 'entero' | 'doble'
	<VALOR> ::= 'valor' = numero <EXPRESION> | id | cadena
	<EXPRESION> ::=  operador numero <EXPRESION> | <EPSILON>
	<OTRA_VARIABLE> ::= ';' <VARIABLE> <OTRA_VARIABLE> | <EPSILON>


	<CONSTRUCCION> ::= '<' 'construccion' '>' <TERRENO> <PARED_S> <VENTANA_S> <PUERTA_S> <SUELO> '<' '/' 'construccion' '>'

	<TERRENO> ::= '<' 'terreno' '>' <ANCHO> <LARGO> '<' '/' 'terreno' '>'
	<ANCHO> ::= 'ancho' '=' numero
	<LARGO> ::= 'largo' '=' numero

	<PARED_S> ::= '<' 'pared' '>' <PARED> <OTRA_PARED> '<' '/' 'pared' '>'
	<PARED> ::= <NOMBRE> <COLOR> <ALTO> <INICIO> <FIN>
	<COLOR> ::= 'color' ':' id
	<ALTO> ::= 'alto' ':' numero
	<INICIO> ::= 'inicio' ':' numero ',' numero
	<FIN> ::= 'fin' ':' numero ',' numero
	<OTRA_PARED> ::= ';' <PARED> <OTRA_PARED> | <EPSILON>
	 
	<VENTANA_S> ::= '<' 'ventana' '>' <VENTANA> <OTRA_VENTANA> '<' '/' 'ventana' '>'
	<VENTANA> ::= <NOMBRE> <TIPO> (<LONGITUD> | <RADIO>) <PARED_AOCIADA>
	<LONGITUD> ::= 'longitud' ':' numero
	<RADIO> ::= 'radio' '=' numero
	<PARED_AOCIADA> ::= 'pared_asociada' ':' id
	<OTRA_VENTANA> ::= ';' <VENTANA> <OTRA_VENTANA> | <EPSILON>

	<PUERTA_S> ::= '<' 'puerta' '>' <CUERPO_PUERTA> '<' '/' 'puerta' '>'
	<PUERTA> ::= <NOMBRE> <ALTO> <ANCHO> <PARED_AOCIADA> <COLOR> 
	<OTRA_PUERTA> ::= ';' <PUERTA> <OTRA_PUERTA> | <EPSILON>

	<SUELO_S> ::= '<' 'suelo' '>' <SUELO>  <OTRO_SUELO>'<' '/' 'suelo' '>'
	<SUELO> ::= <NOMBRE>  <COLOR>
	<OTRO_SUELO> ::= 

	}