using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using TodosWebApi.WebApi.Data;
using TodosWebApi.WebApi.Dtos;
using TodosWebApi.WebApi.Entities;

namespace TodosWebApi.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TodosController : ControllerBase
    {

        private readonly ILogger<TodosController> _logger;
        private readonly DataContext _context;

        public TodosController(ILogger<TodosController> logger, DataContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<TodoItem>> Get()
        {
            return await _context.Items.ToListAsync();
             
        }

        [HttpPost]
        public async Task<TodoDto> Create(TodoDto item)
        {
            _context.Items.Add(new TodoItem()
            {
                Title = item.Title,
                Completed = item.Completed
            });

            await _context.SaveChangesAsync();

            return item;
        }

        [HttpDelete("{id}")]
        public async Task <IActionResult> DeleteTitle(int id)
        {
            var item = await _context.Items.FindAsync(id);

            if (item == null)
            {
                return NotFound();
            } 
            _context.Items.Remove(item);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
    
}
