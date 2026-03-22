namespace App;

public class Queries(List<Task> _tasks)
{
    private readonly List<Task> Tasks = _tasks;

    // métodos para gestionar las tareas 
    public void ListTask()
    {
        ForegroundColor = ConsoleColor.DarkBlue;
        WriteLine("-----Lista de tareas-----");
        WriteLine("\n{0,-8} {1,-35} {2,-15}", "Id", "Descripcion", "Completado");
        foreach (Task task in Tasks)
        {
            WriteLine(new string('-', 58));
            WriteLine("\n{0,-8} {1,-35} {2,-15}", task.Id, task.Description, task.Completed ? "Si" : "No");

        }
    }

}

