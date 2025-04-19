using ToDoAPI.Models;

namespace ToDoAPI.Services;

public interface IToDoService
{
    public bool AddToDoService(ToDoItem newToDo);
    public bool UpdateToDoService(int Id, ToDoItem updatedToDo);
    public ToDoItem GetToDoService(int Id);
    public IEnumerable<ToDoItem> GetAllToDosService();
    public bool DeleteToDoService(int Id);
    public int GetHighestId();
}