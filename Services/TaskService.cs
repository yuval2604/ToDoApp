using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ToDoApp.Data;
using ToDoApp.Domain;

namespace ToDoApp.Services
{
    public class TaskService : ITaskService
    {
        private DataContext _dataContext;
        public TaskService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<Domain.Task>> GetTasksAsync()
        {
            return await _dataContext.Tasks.ToListAsync();

        }

        public async Task<Domain.Task> GetTaskByIdAsync(Guid postId)
        {
            return await _dataContext.Tasks.SingleOrDefaultAsync(x => x.Id == postId);
        }



        public async Task<bool> DeleteTaskAsync(Guid taskId)
        {
            var task = await GetTaskByIdAsync(taskId);
            _dataContext.Tasks.Remove(task);
            var deleted = await _dataContext.SaveChangesAsync();
            return deleted > 0;
        }

        public async Task<bool> CreateTaskAsync(Domain.Task task)
        {
            await _dataContext.Tasks.AddAsync(task);
            var created = await _dataContext.SaveChangesAsync();
            return created > 0;
        }

        public async Task<bool> UpdateTaskAsync(Guid taskId)
        {
            var task = await GetTaskByIdAsync(taskId);
            task.status = Task_status.DONE;
            _dataContext.Tasks.Update(task);
            var updated = await _dataContext.SaveChangesAsync();
            return updated > 0;
        }

        public async Task<bool> UnDoneTaskAsync(Guid taskId)
        {
            var task = await GetTaskByIdAsync(taskId);
            task.status = Task_status.NOT_DONE;
            _dataContext.Tasks.Update(task);
            var updated = await _dataContext.SaveChangesAsync();
            return updated > 0;
        }

       
    }
}
