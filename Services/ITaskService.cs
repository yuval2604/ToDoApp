using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ToDoApp.Domain;

namespace ToDoApp.Services
{
    public interface ITaskService
    {
        Task<List<Domain.Task>> GetPostsAsync();
        Task<Domain.Task> GetPostByIdAsync(Guid taskId);
        Task<bool> CreatePostAsync(Domain.Task task);
        Task<bool> DeletePostAsync(Guid taskId);
        Task<bool> UpdatePostAsync(Domain.Task taskToUpdate);
    }
}
