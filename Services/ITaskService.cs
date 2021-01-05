using System;
using System.Collections.Generic;
using ToDoApp.Domain;

namespace ToDoApp.Services
{
    public interface ITaskService
    {
        List<Task> GetTasks();
        Task GetTaskId(Guid TaskId);
        bool UpdateTask(Task taskToUpdate);
    }
}
