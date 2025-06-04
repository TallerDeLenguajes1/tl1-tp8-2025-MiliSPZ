// See https://aka.ms/new-console-template for more information
using EspacioTarea;
using enumEstados;

List<Tarea> ListaTareaPendientes = new List<Tarea>();
List<Tarea> ListaTareasRealizadas = new List<Tarea>();

int cantTarea = 0, cambiarEstado = 0, opcion = 1;
string? descripcion;

Console.WriteLine("Bienvenido");

do
{
    switch (opcion)
    {
        case 1:
            Console.WriteLine("¿Cuantas tareas desea ingresar?");
            int.TryParse(Console.ReadLine(), out cantTarea);

            Random rnd = new Random();

            for (int i = 0; i < cantTarea; i++)
            {
                Tarea newTarea = new Tarea();
                newTarea.TareaID = i + 1;
                newTarea.Duracion = rnd.Next(10, 101);
                newTarea.Estado = EstadoTarea.pendiente;
                Console.WriteLine("Agregue una descripcion de su tarea:");
                descripcion = Console.ReadLine();
                newTarea.Descripcion = descripcion;

                if (newTarea.VerificarDuracion(newTarea.Duracion))
                {
                    Console.WriteLine("La duracion de la tarea es correcta");
                }
                else
                {
                    Console.WriteLine("La duracion de la tarea es menos o supera el limite que se esperan");
                    break;
                }

                ListaTareaPendientes.Add(newTarea);
            }
            break;
        case 2:
            Tarea TareaACambiar = new Tarea();
            Console.WriteLine("Elija que tarea que tarea quiere cambiar Realizado:");
            int.TryParse(Console.ReadLine(), out cambiarEstado);

            foreach (var Tarea in ListaTareaPendientes)
            {
                if (Tarea.TareaID == cambiarEstado)
                {
                    Tarea.Estado = EstadoTarea.realizado;
                    ListaTareasRealizadas.Add(Tarea);
                    TareaACambiar = Tarea;
                }
            }
            ListaTareaPendientes.Remove(TareaACambiar);
            break;
        case 3:
            Console.WriteLine("\n");
            Console.WriteLine("---------------Lista de Prendientes---------------");
            foreach (Tarea TareaActual in ListaTareaPendientes)
            {
                Console.WriteLine($"TareaID: {TareaActual.TareaID}, Descripcion: {TareaActual.Descripcion}, Duracion: {TareaActual.Duracion}, Estado: {TareaActual.Estado}");
            }
            Console.WriteLine("\n");
        
            Console.WriteLine("---------------Lista de Prendientes---------------");
            foreach (Tarea TareaActual in ListaTareasRealizadas)
            {
                Console.WriteLine($"TareaID: {TareaActual.TareaID}, Descripcion: {TareaActual.Descripcion}, Duracion: {TareaActual.Duracion}, Estado: {TareaActual.Estado}");
            }
            Console.WriteLine("\n");
            break;
        case 4:
            Console.WriteLine("Escriba la descripcion para buscar a tarea:");
            descripcion = Console.ReadLine();

            foreach (var Tarea in ListaTareaPendientes)
            {
                if (Tarea.Descripcion == descripcion)
                {
                    Console.WriteLine($"TareaID: {Tarea.TareaID}, Descripcion: {Tarea.Descripcion}, Duracion: {Tarea.Duracion}, Estado: {Tarea.Estado}");
                }
            }
            break;
        default:
            break;
    }

    Console.WriteLine("\n------------------------------");
    Console.WriteLine("¿Que desea hacer ahora? \n(1: Agregar mas tareas)\n(2: Cambiar estado de la tarea)\n(3: Ver Listas)\n(4: Buscar tarea por descripcion)\n(5: Salir)");
    int.TryParse(Console.ReadLine(), out opcion);

} while (opcion !=  5);