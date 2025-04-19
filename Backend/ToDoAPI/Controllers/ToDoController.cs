using Microsoft.AspNetCore.Mvc;
using ToDoAPI.Models;
using ToDoAPI.Services;

namespace ToDoAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ToDoController:ControllerBase
{
    private IToDoService _ToDoService;

    public ToDoController(IToDoService ToDoService)
    {
        _ToDoService = ToDoService;
    }
    [HttpGet("{id}")]
    public ActionResult<ToDoItem> GetToDoById(int id)
    {
        var ToDo = _ToDoService.GetToDoService(id);
        if (ToDo == null)
        {
            return NotFound();
        }

        return Ok(ToDo);
    }

    [HttpGet]
    public ActionResult<IEnumerable<ToDoItem>> GetAllToDos()
    {
        var ToDos = _ToDoService.GetAllToDosService();
        return Ok(ToDos);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteToDo(int id)
    {
        var isDeleted = _ToDoService.DeleteToDoService(id);
        if (isDeleted)
        {
            return NoContent();
        }
        return NotFound();
    }

    [HttpPost]
    public ActionResult<ToDoItem> AddToDo(ToDoItem newToDo)
    {
        newToDo.Id = _ToDoService.GetHighestId() + 1;
        var isAdded = _ToDoService.AddToDoService(newToDo);
        if (isAdded)
        {
            return Ok(newToDo);
        }
        return NotFound();
    }

    [HttpPut("{id}")]
    public ActionResult<ToDoItem> UpdateToDo(int id, ToDoItem newToDo)
    {
        var isUpdated = _ToDoService.UpdateToDoService(id, newToDo);
        if (isUpdated)
        {
            return Ok(newToDo);
        }
        return NotFound();
    }
}