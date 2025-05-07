using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApp.API.Data;
using TodoApp.API.DTOs.Request;
using TodoApp.API.DTOs.Response;
using TodoApp.API.Models;
using AutoMapper;

namespace TodoApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoItemsController : ControllerBase
    {
        private readonly TodoContext _context;
        private readonly IMapper _mapper;

        public TodoItemsController(TodoContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TodoItemResponseDto>>> GetTodoItems()
        {
            var todos = await _context.TodoItems.ToListAsync();
            return Ok(_mapper.Map<IEnumerable<TodoItemResponseDto>>(todos));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TodoItemResponseDto>> GetTodoItem(int id)
        {
            var todo = await _context.TodoItems.FindAsync(id);
            if (todo == null) return NotFound();
            return Ok(_mapper.Map<TodoItemResponseDto>(todo));
        }

        [HttpPost]
        public async Task<ActionResult<TodoItemResponseDto>> PostTodoItem(TodoItemRequestDto request)
        {
            var todo = _mapper.Map<TodoItem>(request);
            _context.TodoItems.Add(todo);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetTodoItem), new { id = todo.Id }, _mapper.Map<TodoItemResponseDto>(todo));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutTodoItem(int id, TodoItemRequestDto request)
        {
            var todo = await _context.TodoItems.FindAsync(id);
            if (todo == null) return NotFound();

            _mapper.Map(request, todo);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodoItem(int id)
        {
            var todo = await _context.TodoItems.FindAsync(id);
            if (todo == null) return NotFound();

            _context.TodoItems.Remove(todo);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
