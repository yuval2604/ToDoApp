using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ToDoApp.Contract;
using ToDoApp.Contract.Request;
using ToDoApp.Contract.Response;
using ToDoApp.Domain;
using ToDoApp.Services;

namespace ToDoApp.Controllers.V1
{
    public class TasksControllers: Controller
    {
        private ITaskService _taskService;

        public TasksControllers(ITaskService taskService)
        {
            _taskService = taskService;
        }
        [HttpGet(ApiRoutes.Tasks.GetAll)]
        public IActionResult GetAll()
        {
            return Ok(_taskService.GetTasks());
        }

        [HttpPut(ApiRoutes.Tasks.Update)]
        public IActionResult Update([FromRoute] Guid taskId, [FromBody] UpdatedTaskRequest request)
        {
            var task = new Task
            {
                Id = taskId
            };
            var updated = _taskService.UpdateTask(task);
            if (updated)
                return Ok(task);
            return NotFound();
        }

        [HttpGet(ApiRoutes.Tasks.Get)]
        public IActionResult Get([FromRoute] Guid taskId)
        {
            var task = _taskService.GetTaskId(taskId);
            if (task == null) return NotFound();
            return Ok(task);
        }

        [HttpPost(ApiRoutes.Tasks.Create)]
        public IActionResult Create([FromBody] CreatedTaskRequest taskRequest)
        {
            var task = new Task { Id = taskRequest.Id, status=Task_status.NOT_DONE, content= taskRequest.content };
            if (task.Id != Guid.Empty) task.Id = Guid.NewGuid();
            //_postService.Add(post);

            var baseurl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";
            var locationUrl = baseurl + "/" + ApiRoutes.Tasks.Get.Replace("{taskId}", task.Id.ToString());
            var response = new TaskResponse { Id = task.Id };
            return Created(locationUrl, response);
        }

    }
}
