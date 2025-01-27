using Microsoft.AspNetCore.Mvc;
using taskmanagementapi.Models;

namespace taskmanagementapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : Controller
    {
        private readonly DataContext _context;

        public TaskController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetTasks()
        {
            var item =  _context.TaskItems.ToList();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(item);
        }

        [HttpGet("{taskId}")]
        public IActionResult GetTask(int taskId)
        {
            var task = _context.TaskItems.Where(task => task.Id == taskId).FirstOrDefault();

            if (task == null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(task);
        }

        [HttpPost]
        public IActionResult CreateTask([FromBody] TaskItem task)
        {
            if (task == null)
            {
                return BadRequest(ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Add(task);
            _context.SaveChanges();

            return Ok("Succesfully added");

        }

        [HttpPut("{taskId}")]
        public IActionResult UpdateTask([FromBody] TaskItem task, int taskId)
        {
            if (task == null)
            {
                return BadRequest(ModelState);
            }

            if (task.Id != taskId)
            {
                return BadRequest(ModelState);
            }

            _context.Update(task);
            _context.SaveChanges();

            return Ok("Updated Succesfully");
        }

        [HttpDelete("{taskId}")]
        public IActionResult DeleteTask(int taskId)
        {
            var task = _context.TaskItems.Where(task => task.Id == taskId).FirstOrDefault();

            if (task == null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Remove(task);
            _context.SaveChanges();

            return Ok("DEleted");

        }

    }
}
