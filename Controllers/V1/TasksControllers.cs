using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _taskService.GetTasksAsync());
        }

        [HttpPut(ApiRoutes.Tasks.Update)]
        public async Task<IActionResult> Update([FromRoute] Guid taskId)
        {
           
            var updated = await _taskService.UpdateTaskAsync(taskId);
            if (updated)
                return Ok(taskId);
            return NotFound();
        }

        [HttpPut(ApiRoutes.Tasks.UnDone)]
        public async Task<IActionResult> UnDone([FromRoute] Guid taskId)
        {
           
            var updated = await _taskService.UnDoneTaskAsync(taskId);
            if (updated)
                return Ok(taskId);
            return NotFound();
        }

        [HttpGet(ApiRoutes.Tasks.Get)]
        public async Task<IActionResult> Get([FromRoute] Guid taskId)
        {
            var task = await _taskService.GetTaskByIdAsync(taskId);
            if (task == null) return NotFound();
            return Ok(task);
        }

        [HttpPost(ApiRoutes.Tasks.Create)]
        public async Task<IActionResult> Create([FromBody] CreatedTaskRequest taskRequest)
        {
            var task = new Domain.Task {  status=Task_status.NOT_DONE, content= taskRequest.content };
            var created= await _taskService.CreateTaskAsync(task);
            if (created == null) return NotFound();
            return Ok(created);
        }
        
        [HttpDelete(ApiRoutes.Tasks.Delete)]
        public async Task<IActionResult> Delete([FromRoute] Guid taskId)
        {
            var deleted = await _taskService.DeleteTaskAsync(taskId);
            if (deleted) return NoContent();
            return NotFound();
        }
    }
}
