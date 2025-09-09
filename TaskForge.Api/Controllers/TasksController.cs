using Microsoft.AspNetCore.Mvc;
using TaskForge.Api.Models;
using TaskForge.Api.Services;

namespace TaskForge.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TasksController : ControllerBase
    {
        private readonly ITaskService _taskService;

        public TasksController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        // GET /tasks
        // English: return all tasks
        [HttpGet]
        public async Task<ActionResult<List<TaskItem>>> GetAll()
        {
            var items = await _taskService.GetAll();
            return Ok(items);
        }

        // GET /tasks/{id}
        // English: get single task or 404 if not found
        [HttpGet("{id}", Name = "GetTask")]
        public async Task<ActionResult<TaskItem>> GetById(int id)
        {
            var task = await _taskService.GetById(id);
            if (task == null) return NotFound();
            return Ok(task);
        }

        // POST /tasks
        // English: create a new task; Id is assigned by the service
        [HttpPost]
        public async Task<ActionResult<TaskItem>> Create([FromBody] TaskItem taskItem)
        {
            var created = await _taskService.Create(taskItem);
            return CreatedAtRoute("GetTask", new { id = created.Id }, created);
        }

        // PUT /tasks/{id}
        // English: full update; returns 204 on success or 404 if not found
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] TaskItem taskItem)
        {
            var ok = await _taskService.Update(id, taskItem);
            return ok ? NoContent() : NotFound();
        }

        // DELETE /tasks/{id}
        // English: delete by id; returns 204 or 404 if not found
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var ok = await _taskService.Delete(id);
            return ok ? NoContent() : NotFound();
        }
    }
}
