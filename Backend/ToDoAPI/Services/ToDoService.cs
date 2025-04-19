using ToDoAPI.Data;
using ToDoAPI.Models;

namespace ToDoAPI.Services;

public class ToDoService : IToDoService
{
    private readonly ToDoDbContext _context;

    public ToDoService(ToDoDbContext context)
    {
        _context = context;
    }

    public IEnumerable<ToDoItem> GetAllToDosService()
    {
        return _context.ToDos.ToList();
    }

    public ToDoItem? GetToDoService(int id)
    {
        return _context.ToDos.Find(id);
    }

    public bool AddToDoService(ToDoItem newToDo)
    {
        _context.ToDos.Add(newToDo);
        _context.SaveChanges();
        return true;
    }

    public bool UpdateToDoService(int id, ToDoItem updatedToDo)
    {
        var toDo = _context.ToDos.Find(id);
        if (toDo == null) return false;

        toDo.Task = updatedToDo.Task;
        toDo.Description = updatedToDo.Description;
        toDo.Deadline = updatedToDo.Deadline;

        _context.SaveChanges();
        return true;
    }

    public bool DeleteToDoService(int id)
    {
        var toDo = _context.ToDos.Find(id);
        if (toDo == null) return false;

        _context.ToDos.Remove(toDo);
        _context.SaveChanges();
        return true;
    }

    public int GetHighestId()
    {
        return _context.ToDos.Any() ? _context.ToDos.Max(t => t.Id) : 0;
    }
}