## Ahorcado
*Un juego sencillo escrito en C#*

### Identificación de violaciones SOLID en Juego.cs

| Situación | Principio violado |
|---|---|
| La clase `Juego` controla turnos, dibuja el tablero, muestra mensajes, valida la victoria y elige la palabra, tiene muchas responsabilidades. | SRP - Principio de Responsabilidad Única |
| Las palabras están hardcodeadas dentro de la clase `Juego`. | OCP - Principio Abierto/Cerrado |
| Para agregar otro tipo de juego habría que modificar directamente la clase `Juego`. | OCP - Principio Abierto/Cerrado |