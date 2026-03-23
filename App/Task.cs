
namespace App;

public class Task(string id, string description)
{
    public string? Id { get; set; } = id;
    public string? Description { get; set; } = description;
    public bool Completed { get; set; } = false;
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime ModifiedAt { get; set; } = DateTime.Now;
    public bool Deleted { get; set; } = false;

    public override string ToString()
    {
        return $"Task: \nId:{Id}, \nDescription:{Description}, \nCompleted: {Completed}, \nCreatedAt:{CreatedAt}, \nModifiedAt:{ModifiedAt}, \nDeleted:{Deleted}";
    }
}
