namespace App;


public class TaskMasterApp
{

  private static readonly FileActions<Task> fileActions = new("./App/tasks.json");
  private static readonly List<Task> tasks = fileActions.ReadFile();
  private static readonly Queries queries = new(tasks, fileActions);
  public static void ShowMenu()
  {
    bool salir = false;
    while (!salir)
    {
      ForegroundColor = ConsoleColor.White;
      WriteLine("------Menú de tareas------");
      WriteLine("\n1. Listar tareas");
      WriteLine("2. Añadir tarea");
      WriteLine("3. Marcar tarea como completada");
      WriteLine("4. Editar tarea");
      WriteLine("5. Eliminar tarea");
      WriteLine("6. Consultar tareas por estado");
      WriteLine("7. Consultar tarea por descripción");
      WriteLine("8. Salir");
      Write("\nSeleccione una opción: ");


      switch (ReadLine())
      {
        case "1":
          queries.ListTask();
          break;
        case "2":
          queries.AddTask();
          break;
        case "3":
          Write("Ingrese el id:");
          queries.MarkAsCompleted();
          break;
        case "4":
          queries.EditTask();
          break;
        case "5":
           queries.RemoveTask();
          break;
        case "6":
          queries.TasksByState();
          break;
        case "7":
          queries.TasksByDescription();
          break;
        case "8":
          salir = true;
          Clear();
          break;
        default:
          Clear();
          WriteLine("Opción no válida. Intente nuevamente.");
          break;
      }
    }
  }
}
