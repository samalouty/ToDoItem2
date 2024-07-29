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

        // Task Methods
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

        // User Methods
        public async Task<List<User>> GetAllUsersAsync()
        {
            return await _dbContext.Users.Include(u => u.toDoItems).ToListAsync();
        }

        public async Task<User> GetUserAsync(int userId)
        {
            return await _dbContext.Users.Include(u => u.toDoItems).SingleOrDefaultAsync(x => x.Id == userId);
        }

        public async Task<User> AddUserAsync(User user)
        {
            _dbContext.Users.Add(user);
            await _dbContext.SaveChangesAsync();
            return user;
        }

        public async Task<User> UpdateUserAsync(User updatedUser)
        {
            var user = await _dbContext.Users.SingleOrDefaultAsync(u => u.Id == updatedUser.Id);
            if (user == null)
            {
                return null;
            }

            user.UserName = updatedUser.UserName;
            await _dbContext.SaveChangesAsync();
            return user;
        }

        public async Task<bool> DeleteUserAsync(int userId)
        {
            var user = await _dbContext.Users.Include(u => u.toDoItems).SingleOrDefaultAsync(u => u.Id == userId);
            if (user == null)
            {
                return false;
            }

            _dbContext.Users.Remove(user);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
