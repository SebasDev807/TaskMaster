namespace App;

using BetterConsoles.Tables;

public class Queries(List<Task> _tasks)
{
    private readonly List<Task> Tasks = _tasks;

    // métodos para gestionar las tareas 
    public void ListTask()
    {
        Table table = new Table("Id", "Descripcion", "Completado");
        
    }

}

