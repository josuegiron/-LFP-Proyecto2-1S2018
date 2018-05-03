string[] L = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "\xD1", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "\xF1", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };
string[] N = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "0" };
string[] I = { "=" };
string[] P = { "." };
string[] PC = { ";"};
string[] m = { "<"};
string[] M = { ">"};
string[] C = { ","};
string[] GB = { "_" };
string[] O = { " ", "+", "-", "*", "/", "^" };
string[] SL = { "\n" };
string[] D = { "/" };
string[] G = { "-" };
string[] DP = { ":" };
string[] A = { "!" };
string[] CN = { "\"" };

 string[,] token = new string[,] {
                { "ID", "Token", "Descripcion" },
                { "1", "Numero", "Secuencia de numeros" },
                { "2", "id", "Cadena de numeros y letras" },
                { "3", "diseño", "Palabra reservada, inicio de programa" },
                { "4", "variables", "Palabra reservda, indica seccion de variables" },
                { "5", "construccion", "Palabra reservada, indica seccion de construccion" },
                { "6", "nombre", "Palabra reservada" },
                { "7", "tipo", "Palabra reservada" },
                { "8", "valor", "Palabra reservada" },
                { "9", "terreno", "Palabra reservada" },
                { "10", "pared", "Palabra reservada" },
                { "11", "ventana", "Palabra reservada" },
                { "12", "puerta", "Palabra reservada" },
                { "13", "suelo", "Palabra reservada" },
                { "14", "ancho", "Palabra reservada" },
                { "15", "largo", "Palabra reservada" },
                { "16", "color", "Palabra reservada" },
                { "17", "alto", "Palabra reservada" },
                { "18", "inicio", "Palabra reservada"},
                { "19", "fin", "Palabra reservada"},
                { "20", "radio", "Palabra reservada"},
                { "21", "pared_asociada", "Palabra reservada"},
                { "22", "Operador", "Operador matematico"},
                { "23", ";", "Final de comando"},
                { "24", "<", "Signo menor"},
                { "25", ">", "Signo mayor"},
                { "26", ",", "Coma"},
                { "27", "=", "Signo igual, asignacion"},
                { "27", ":", "Dos puntos"} 
            };

        string[,] palabrasReservadas = new string[,] {
                { "3", "diseño" },
                { "4", "variables" }, 
                { "5", "construccion" },
                { "6", "nombre" }, 
                { "7", "tipo" }, 
                { "8", "valor" }, 
                { "9", "terreno" }, 
                { "10", "pared" }, 
                { "11", "ventana" }, 
                { "12", "puerta" }, 
                { "13", "suelo" },'
                { "14", "ancho" }, 
                { "15", "largo" }, 
                { "16", "color" }, 
                { "17", "alto" },
               	{ "18", "inicio"},
                { "19", "fin"},
                { "20", "radio"},
                { "21", "pared_asociada"},
                { "22", "Operador"},
                { "23", ";"},
                { "24", "<"},
                { "25", ">"},
                { "26", ","},
                { "27", "="},
                { "27", ":"} 
            };
