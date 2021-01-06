using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ToDoApp.Domain;

namespace ToDoApp.Services
{
    public interface ITaskService
    {
        Task<List<Domain.Task>> GetTasksAsync();
        Task<Domain.Task> GetTaskByIdAsync(Guid taskId);
        Task<bool> CreateTaskAsync(Domain.Task task);
        Task<bool> DeleteTaskAsync(Guid taskId);
        Task<bool> UpdateTaskAsync(Guid taskId);
        Task<bool> UnDoneTaskAsync(Guid taskId);
    }
}
