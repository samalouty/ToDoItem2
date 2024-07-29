using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;
using ToDoItem2.Domain;


namespace ToDoItem2.Presentation
{
    public class TaskController : Controller
    {
        private static int num = 0;
        

        private static List<ToDoItem> toDoItems = new List<ToDoItem>();

        [HttpGet("GetAllTasks")]
                public IActionResult getAllTasks()
                {
                    return Ok(toDoItems);

                }

                [HttpPost("addTask")]
                public IActionResult addTask(ToDoItem toDoItem)
                {
                    if (toDoItems.Count == 0)
                    {
                        num = 0;
                    }
                    num++;
                    toDoItem.taskNum = num;
                    toDoItems.Add(toDoItem);
                    return CreatedAtAction(nameof(getAllTasks), new { taskName = toDoItem.taskName }, toDoItem);
                }


                [HttpGet("getTask")]

                public IActionResult getTask(int num)
                {
                    var task = toDoItems.SingleOrDefault(x => x.taskNum == num);
                    if (task == null)
                    {
                        return NotFound();
                    }

                    return Ok(task);

                }

                [HttpPut("updateTask")]
                public IActionResult updateTask(ToDoItem updatedTask)
                {
                    var task = toDoItems.SingleOrDefault(t => t.taskNum == updatedTask.taskNum);
                    if (task == null)
                    {
                        return NotFound();
                    }
                    if (!string.IsNullOrEmpty(updatedTask.taskName))
                    {
                        task.taskName = updatedTask.taskName;
                    }
                    task.taskName = updatedTask.taskName;

                    return Ok(updatedTask);
                }


                [HttpDelete("DeleteTask")]

                public IActionResult DeleteTask(int num)
                {
                    var task = toDoItems.SingleOrDefault(t => t.taskNum == num);
                    if (task == null)
                    {
                        return NotFound();
                    }
                    toDoItems.Remove(task);
                    return NoContent();
                }
        


    }
}
