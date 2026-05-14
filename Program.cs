Console.WriteLine("¿Qué juego quieres jugar?");
Console.WriteLine("  1 — Ahorcado");
Console.WriteLine("  2 — Viborita");
Console.Write("Opción: ");

var opcion = Console.ReadLine();

if (opcion == "2")
{
    var motor = new Ahorcado.MotorViborita();
    var ui = new Ahorcado.ConsolaUIViborita(motor);
    var pausado = false;

    Console.CursorVisible = false;

    while (!motor.Ganado() && !motor.Perdido())
    {
        ui.MostrarTablero();

        var tecla = ui.LeerTecla();

        if (tecla == ConsoleKey.Q)
            break;

        if (tecla == ConsoleKey.P)
            pausado = !pausado;

        if (pausado)
        {
            ui.MostrarMensaje("Pausado. Presiona P para continuar.");
            Thread.Sleep(100);
            continue;
        }

        if (tecla != ConsoleKey.NoName)
            motor.CambiarDireccion(tecla);

        motor.Avanzar();

        var velocidad = Math.Max(90, 170 - motor.Puntos * 5);
        Thread.Sleep(velocidad);
    }

    ui.MostrarTablero();

    ui.MostrarMensaje(motor.Ganado()
        ? $"\n¡Ganaste! Llegaste a {motor.PuntosParaGanar} puntos."
        : "\nGame over.");

    Console.CursorVisible = true;
}
else
{
    var repositorio = new Ahorcado.PalabrasEnMemoria();
    var motor = new Ahorcado.MotorAhorcado(repositorio);
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
}
