var repositorio = new Ahorcado.PalabrasEnMemoria();
Console.WriteLine("Elige una categoria:");
var categorias = repositorio.ObtenerCategorias();
for (int i = 0; i < categorias.Count; i++)
{
    Console.WriteLine($"{i + 1}. {categorias[i]}");
}

Console.Write("Opcion: ");
var opcionCategoria = Console.ReadLine();
int indiceCategoria;

while (!int.TryParse(opcionCategoria, out indiceCategoria) ||
       indiceCategoria < 1 ||
       indiceCategoria > categorias.Count)
{
    Console.WriteLine("Opcion invalida.");
    Console.Write("Opcion: ");
    opcionCategoria = Console.ReadLine();
}

var categoria = categorias[indiceCategoria - 1];
var motor = new Ahorcado.MotorAhorcado(repositorio, categoria);
var ui = new Ahorcado.ConsolaUI(motor);

Console.WriteLine("=== AHORCADO ===");

while (!motor.Ganado() && !motor.Perdido())
{
    ui.MostrarTablero();

    char letra = ui.PedirLetra();

    if (motor.LetraYaUsada(letra))
    {
        ui.MostrarMensaje("Ya usaste esa letra.");
        continue;
    }

    motor.RegistrarLetra(letra);
}

ui.MostrarTablero();

if (motor.Ganado())
    ui.MostrarMensaje($"\n¡Ganaste! La palabra era: {motor.PalabraSecreta}");
else
    ui.MostrarMensaje($"\nPerdiste. La palabra era: {motor.PalabraSecreta}");
