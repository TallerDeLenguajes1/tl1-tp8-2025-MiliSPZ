using enumEstados;

namespace EspacioTarea;

public class Tarea
{
    public int TareaID { get; set; }
    public string? Descripcion { get; set; }
    public int Duracion { get; set; }
    public EstadoTarea Estado { get; set; }

    public Tarea()
    {

    }


    public bool VerificarDuracion(int number)
    {
        if (number < 100 && number > 10)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
