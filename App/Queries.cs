namespace App;

using App.Utils;
using BetterConsoles.Tables;
using BetterConsoles.Tables.Configuration;

public class Queries(List<Task> _tasks, FileActions<Task> _fileActions)
{
    private readonly List<Task> Tasks = _tasks;
    private readonly FileActions<Task> FileActions = _fileActions;

    // métodos para gestionar las tareas 

    //Listar tareas
    public void ListTask() => ShowTasksTable(Tasks);

    public void AddTask()
    {
        try
        {
            ClearConsole();
            WriteLine("---Agregar Tarea----");

            string description = TaskUtils.ReadTaskValue("Ingrese la nueva tarea");

            Task newTask = new(TaskUtils.GenerateId(), description);
            Tasks.Add(newTask);
            ShowSuccessMessage("Tarea Agregada con exito!");
            FileActions.WriteFile(Tasks);
        }
        catch (Exception ex)
        {
            ForegroundColor = ConsoleColor.Red;
            WriteLine($"Ocurrio un error al agregar Tarea {ex.Message}");
        }
    }

    public void MarkAsCompleted()
    {
        try
        {
            ClearConsole();
            WriteLine("---Marcar Tarea Como Completada----");

            string id = TaskUtils.ReadTaskValue("Ingrese el id de la tarea que desea marcar como completada");

            //Buscar tareas
            Task task = FindTaskById(id);

            task.Completed = true;
            task.ModifiedAt = DateTime.Now;

            ShowSuccessMessage("Tarea completada con exito");

            FileActions.WriteFile(Tasks);

        }
        catch (Exception ex)
        {
            ForegroundColor = ConsoleColor.Red;
            WriteLine($"Ocurrio un error al Completar Tarea {ex.Message}");
        }
    }

    public void EditTask()
    {
        try
        {
            ClearConsole();

            WriteLine("---Marcar Tarea Como Completada----");

            string id = TaskUtils.ReadTaskValue("Ingrese el id de la tarea a editar");

            //Buscar tareas
            Task task = FindTaskById(id);

            Write("Ingrese la descripcion de la tarea:");
            string description = TaskUtils.ReadTaskValue("Ingrese la descripcion de la tarea");
            task.Description = description;
            task.ModifiedAt = DateTime.Now;

            ShowSuccessMessage("Tarea modificada con exito");

            FileActions.WriteFile(Tasks);

        }
        catch (Exception ex)
        {
            ForegroundColor = ConsoleColor.Red;
            WriteLine($"Ocurrio un error al actualizar Tarea {ex.Message}");
        }
    }

    public void RemoveTask()
    {
        string id = TaskUtils.ReadTaskValue("Ingrese el id de la tarea a eliminar");
        Task task = FindTaskById(id);
        Tasks.Remove(task);
        ShowSuccessMessage("Tarea Eliminada con exito");
        FileActions.WriteFile(Tasks);

    }

    public Task FindTaskById(string id)
    {
        Task task = Tasks.Find(task => task.Id == id)!;

        if (task == null)
        {
            ForegroundColor = ConsoleColor.Red;
            throw new Exception($"No se encontro la tarea con el id {id}");

        }

        return task;
    }

    public void TasksByState()
    {
        string taskState = TaskUtils.ReadTaskValue("Ingrese el estado de la tarea (completada, incompleta) otro: incompleta ");

        bool isCompleted = taskState.ToLower() switch
        {
            "completada" => true,
            "incompleta" => false,
            _ => false,
        };


        var tasksByState = Tasks.Where(task => task.Completed == isCompleted).ToList();

        ShowTasksTable(tasksByState);
    }
    private void ClearConsole()
    {
        ResetColor();
        Clear();
        WriteLine();
    }

    public void TasksByDescription()
    {
        string query = TaskUtils.ReadTaskValue("Ingrese el termino de busqueda");
        var taskByQuery = Tasks.Where(task => task.Description!.Contains(
            query, StringComparison.OrdinalIgnoreCase
        )).ToList();

        ShowTasksTable(taskByQuery);

    }
    private void ShowSuccessMessage(string message)
    {
        ForegroundColor = ConsoleColor.Green;
        WriteLine($"{message} ✅");
        ResetColor();
    }

    private void ShowTasksTable(List<Task> tasks)
    {
        WriteLine("-----Lista de Tareas-----");
        Table table = new Table("Id", "Descripcion", "Estado");

        foreach (Task task in tasks)
            table.AddRow(task.Id, task.Description, task.Completed ? "Completada" : "Incompleta");

        table.Config = TableConfig.Unicode();
        WriteLine(table.ToString());
        ReadKey();
    }


}

