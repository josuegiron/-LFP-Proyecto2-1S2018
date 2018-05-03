
Terminales = { id, numero, comentario, cadena, operador, '<', '>', '/','diseño', 'variables', 'construccion', 'nombre', 'tipo', 'valor', ':', 'terreno', 'pared' 'ventana','puerta', 'suelo' 'ancho' 'largo' 'color', 
	'alto','inicio' 'fin', ';', ',', 'longitud', 'pared_asociada', 'redonda', 'cuadrada', 'Potencia', '=', 'cadena', 'entero', 'doble'
}

No Terminales = { }

S = <INICIO>, 

Producciones = {
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

	<CONSTRUCCION> ::= '<' 'construccion' '>' <TERRENO> <PARED_S> <VENTANA_S> <PUERTA_S> <SUELO> '<' '/' 'construccion' '>'
	
	<TERRENO> ::= '<' 'terreno' '>' <ANCHO> <LARGO> '<' '/' 'terreno' '>'
	<ANCHO> ::= 'ancho' '=' numero
	<LARGO> ::= 'largo' '=' numero

	<PARED_S> ::= '<' 'pared' '>' <CUERPO_PARED_S> '<' '/' 'pared' '>'
	<CUERPO_PARED> ::= <PARED> <OTRA_PARED>
	<OTRA_PARED> ::= ';' <PARED> <OTRA_PARED> | <EPSILON>
	<PARED> ::= <NOMBRE> <COLOR> <ALTO> <INICIO> <FIN>
	<COLOR> ::= 'color' ':' ('azul' | 'amarillo' | 'verde' | 'cafe')
	<ALTO> ::= 'alto' ':' numero
	<INICIO> ::= 'inicio' ':' numero ',' numero
	<FIN> ::= 'fin' ':' numero ',' numero
	 
	<VENTANA_S> ::= '<' 'ventana' '>' <CUERPO_VENTANA> '<' '/' 'ventana' '>'
	<CUERPO_VENTANA> ::= <VENTANA> <OTRA_VENTANA>
	<OTRA_VENTANA> ::= ';' <VENTANA> <OTRA_VENTANA> | <EPSILON>
	<VENTANA> ::= <NOMBRE> <TIPO> (<LONGITUD> | <RADIO>) <PARED_AOCIADA>
	<LONGITUD> ::= 'longitud' ':' numero
	<LONGITUD> ::= 'radio' '=' numero
	<PARED_AOCIADA> ::= 'pared_asociada' ':' id

	<PUERTA_S> ::= '<' 'puerta' '>' <CUERPO_PUERTA> '<' '/' 'puerta' '>'
	<CUERPO_PUERTA> ::= <PUERTA> <OTRA_PUERTA>
	<OTRA_PUERTA> ::= ';' <PUERTA> <OTRA_PUERTA> | <EPSILON>
	<PUERTA> ::= <NOMBRE> <ALTO> <ANCHO> <PARED_AOCIADA> <COLOR> 

	<SUELO> ::= '<' 'suelo' '>' <NOMBRE>  <COLOR>'<' '/' 'suelo' '>'

	}