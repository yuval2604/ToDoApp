using System;
using System.ComponentModel.DataAnnotations;

namespace ToDoApp.Domain
{
    public class Task
    {
      [Key]
        public Guid Id { get; set; }
        public Task_status status { get; set; }
        public string content { get; set; }
       
 }
}
    

