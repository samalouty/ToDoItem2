using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ToDoItem2.Domain;
using ToDoItem2.Infrastructure;

namespace ToDoItem2.Services
{
    public class TaskService
    {
        private readonly AppDbContext _dbContext;

        public TaskService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<ToDoItem>> GetAllTasksAsync()
        {
            return await _dbContext.toDoItems.ToListAsync();
        }

        public async Task<ToDoItem> GetTaskAsync(int taskNum)
        {
            return await _dbContext.toDoItems.SingleOrDefaultAsync(x => x.taskNum == taskNum);
        }

        public async Task<ToDoItem> AddTaskAsync(ToDoItem toDoItem)
        {
            _dbContext.toDoItems.Add(toDoItem);
            await _dbContext.SaveChangesAsync();
            return toDoItem;
        }

        public async Task<ToDoItem> UpdateTaskAsync(ToDoItem updatedTask)
        {
            var task = await _dbContext.toDoItems.SingleOrDefaultAsync(t => t.taskNum == updatedTask.taskNum);
            if (task == null)
            {
                return null;
            }

            task.taskName = updatedTask.taskName;
            await _dbContext.SaveChangesAsync();
            return task;
        }

        public async Task<bool> DeleteTaskAsync(int taskNum)
        {
            var task = await _dbContext.toDoItems.SingleOrDefaultAsync(t => t.taskNum == taskNum);
            if (task == null)
            {
                return false;
            }

            _dbContext.toDoItems.Remove(task);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
