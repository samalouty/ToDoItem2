using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ToDoItem2.Domain;
using ToDoItem2.Services;

namespace ToDoItem2.Presentation
{
    [ApiController]
    [Route("[controller]")]
    public class TaskController : ControllerBase
    {
        private readonly TaskService _taskService;

        public TaskController(TaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpGet("GetAllTasks")]
        public async Task<IActionResult> GetAllTasks()
        {
            var tasks = await _taskService.GetAllTasksAsync();
            return Ok(tasks);
        }

        [HttpPost("AddTask")]
        public async Task<IActionResult> AddTask(ToDoItem toDoItem)
        {
            var addedTask = await _taskService.AddTaskAsync(toDoItem);
            return CreatedAtAction(nameof(GetAllTasks), new { taskName = addedTask.taskName }, addedTask);
        }

        [HttpGet("GetTask")]
        public async Task<IActionResult> GetTask(int num)
        {
            var task = await _taskService.GetTaskAsync(num);
            if (task == null)
            {
                return NotFound();
            }

            return Ok(task);
        }

        [HttpPut("UpdateTask")]
        public async Task<IActionResult> UpdateTask(ToDoItem updatedTask)
        {
            var task = await _taskService.UpdateTaskAsync(updatedTask);
            if (task == null)
            {
                return NotFound();
            }

            return Ok(task);
        }

        [HttpDelete("DeleteTask")]
        public async Task<IActionResult> DeleteTask(int num)
        {
            var success = await _taskService.DeleteTaskAsync(num);
            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
