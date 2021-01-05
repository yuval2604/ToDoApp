using System;
namespace ToDoApp.Contract.Request
{
    public class CreatedTaskRequest
    {
        public Guid Id { get; set; }
        public string content { get; set; }
    }
}
