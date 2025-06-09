// See https://aka.ms/new-console-template for more information
using EnumTipoOperacion;
using EspacioOperacion;

int opcion = 0, continuar = 0;
double numeroActual = 0, numeroAnterior = 0;

Console.WriteLine("Bienvenido a la calculadra simple :D");

do
{
    Console.WriteLine("Eliga que operacion quiere realizar: \n1) SUMA \n2)RESTA \n3)MULTIPLICACION \n4)DIVISION \n5)SALIR...");
    int.TryParse(Console.ReadLine(), out opcion);

    if (opcion >= 1 && opcion <= 4)
    {
        Console.WriteLine("Ingrese el numero a calcular:");
        double.TryParse(Console.ReadLine(), out numeroActual);

        TipoOperacion tipo = (TipoOperacion)opcion;
        Operacion calculo = new Operacion(numeroAnterior, numeroActual, tipo);

        Console.WriteLine($"El resultado actual es: {calculo.Resultado}");

        numeroAnterior = numeroActual;

        Console.WriteLine("¿Quiere realizar una nueva operacion?\n 1)Si \n 2)No");
        int.TryParse(Console.ReadLine(), out continuar);
    }
    else if (opcion == 5)
    {
        Console.WriteLine("Bye Bye :]");
    }
    else
    {
        Console.WriteLine("Opcion invalido");
        break;
    }

    if (continuar == 1)
    {   
        Operacion op = new Operacion(10, 5, TipoOperacion.Limpiar);
        Console.WriteLine($"Resultado actual {op.Resultado}"); // Muestra 0
        op.Limpiar();
    }
} while (opcion != 5);
