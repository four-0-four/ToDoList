namespace ToDoAPI.Models;

public class ToDoItem
{
    public int Id { get; set; }
    public String Task { get; set; }
    public String? Description { get; set; }
    public DateTime? Deadline { get; set; }
}