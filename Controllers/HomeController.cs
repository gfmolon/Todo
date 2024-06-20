using Microsoft.AspNetCore.Mvc;
using Todo.Data;
using Todo.Models;

namespace Todo.Controllers;

// configuration for API controller
[ApiController]
public class HomeController : ControllerBase
{
    // Methods in a controller will be -Action-
    //[CRUD]//

    //get List
    [HttpGet("/")]
    public IActionResult Get([FromServices] AppDbContext context) 
        => Ok(context.Todos.ToList());
    

    //get Id
    [HttpGet("/{id:int}")]
    public IActionResult GetById(
        [FromRoute] int id,
        [FromServices] AppDbContext context)
    {
        var todos = context.Todos.FirstOrDefault(x => x.Id == id);
        if (todos == null)
            return NotFound();
        
        return Ok(todos);
    }

    //post 
    [HttpPost("/")]
    public IActionResult Post([FromBody] TodoModel todo,
        [FromServices] AppDbContext context)
    {
        context.Todos.Add(todo);
        context.SaveChanges();

        return Created($"/{todo.Id}",todo);
    }

    //put
    [HttpPut("/{id:int}")]
    public IActionResult Put(
        [FromRoute] int id,
        [FromBody] TodoModel todo,
        [FromServices] AppDbContext context)
    {
        var model = context.Todos.FirstOrDefault(x => x.Id == id);
        if (model == null)
            return NotFound();

        model.Title = todo.Title;
        model.Done = todo.Done;

        context.Todos.Update(model);
        context.SaveChanges();
        return Ok(model);
    }
    
    //delete
    [HttpDelete("/{id:int}")]
    public IActionResult Put(
        [FromRoute] int id,
        [FromServices] AppDbContext context)
    {
        var model = context.Todos.FirstOrDefault(x => x.Id == id);
        if (model == null)
            return NotFound();
        
        context.Todos.Remove(model);
        context.SaveChanges();
        return Ok(model);
    }
    
    
}