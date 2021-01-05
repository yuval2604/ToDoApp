using System;
namespace ToDoApp.Domain
{
    public class Task
    {
      
        public Guid Id { get; set; }
        public Task_status status { get; set; }
        public string content { get; set; }
       
 }
}
    

