using System;
using System.Collections.Generic;

namespace SistemaSeguimientoTareas
{
    // Clase base Tarea
    public class Tarea
    {
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaLimite { get; set; }

        // Método virtual para mostrar detalles
        public virtual void MostrarDetalles()
        {
            Console.WriteLine($"Título: {Titulo}, Descripción: {Descripcion}, Fecha Límite: {FechaLimite.ToShortDateString()}");
        }
    }

    // Clase derivada TareaUrgente
    public class TareaUrgente : Tarea
    {
        public int NivelUrgencia { get; set; }

        // Sobrescribir método para incluir el nivel de urgencia
        public override void MostrarDetalles()
        {
            base.MostrarDetalles();
            Console.WriteLine($"Nivel de Urgencia: {NivelUrgencia}");
        }
    }

    class Program
    {
        static List<Tarea> listaTareas = new List<Tarea>();

        static void Main(string[] args)
        {
            bool salir = false;

            do
            {
                Console.WriteLine("\nMenú Principal:");
                Console.WriteLine("1. Agregar Tarea");
                Console.WriteLine("2. Ver Todas las Tareas");
                Console.WriteLine("3. Salir");
                Console.Write("Seleccione una opción: ");
                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        AgregarTarea();
                        break;
                    case "2":
                        ListarTareas();
                        break;
                    case "3":
                        salir = true;
                        break;
                    default:
                        Console.WriteLine("Opción inválida. Intente nuevamente.");
                        break;
                }

            } while (!salir);
        }

        static void AgregarTarea()
        {
            Console.Write("Ingrese el título de la tarea: ");
            string titulo = Console.ReadLine();
            Console.Write("Ingrese la descripción de la tarea: ");
            string descripcion = Console.ReadLine();
            Console.Write("Ingrese la fecha límite (yyyy-mm-dd): ");
            DateTime fechaLimite = DateTime.Parse(Console.ReadLine());

            Console.Write("¿Es una tarea urgente? (s/n): ");
            string esUrgente = Console.ReadLine().ToLower();

            if (esUrgente == "s")
            {
                Console.Write("Ingrese el nivel de urgencia (1-10): ");
                int nivelUrgencia = int.Parse(Console.ReadLine());
                TareaUrgente tareaUrgente = new TareaUrgente()
                {
                    Titulo = titulo,
                    Descripcion = descripcion,
                    FechaLimite = fechaLimite,
                    NivelUrgencia = nivelUrgencia
                };
                listaTareas.Add(tareaUrgente);
            }
            else
            {
                Tarea tarea = new Tarea()
                {
                    Titulo = titulo,
                    Descripcion = descripcion,
                    FechaLimite = fechaLimite
                };
                listaTareas.Add(tarea);
            }

            Console.WriteLine("Tarea agregada con éxito.");
        }

        static void ListarTareas()
        {
            Console.WriteLine("\nLista de Tareas:");
            foreach (var tarea in listaTareas)
            {
                tarea.MostrarDetalles();
                Console.WriteLine(); // Espacio adicional para mejor legibilidad
            }
        }
    }
}
