using System;
using System.Collections.Generic;
using System.Linq;
using ToDoApp.Domain;

namespace ToDoApp.Services
{
    public class TaskService : ITaskService
    {
        private readonly List<Task> _tasks;

        public TaskService()
        {
            _tasks = new List<Task>();
            for (int i = 0; i < 5; i++)
            {
                _tasks.Add(new Task
                {
                    Id = Guid.NewGuid(),
                    status = Task_status.NOT_DONE,
                    content = $"task {i}"
                });
            }
        }


        public Task GetTaskId(Guid TaskId)
        {
            return _tasks.SingleOrDefault(x => x.Id == TaskId);
        }

        public List<Task> GetTasks()
        {
            return _tasks;
        }

        public bool UpdateTask(Task taskToUpdate)
        {
            var exsists = GetTaskId(taskToUpdate.Id) != null;
            if (!exsists) return false;
            var index = _tasks.FindIndex(x => x.Id == taskToUpdate.Id);
            _tasks[index] = taskToUpdate;
            return true;
        }
    }
}
