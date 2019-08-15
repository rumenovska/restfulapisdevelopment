using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Task = WebApi2.Models.Task;

namespace WebApi2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {

        private static List<Task> _tasks = new List<Task>
        {
           new Task
           {
               Id= 1,
               Title= "Task 1",
               Description= "Description of taks 1"
           },
           new Task
           {
               Id= 2,
               Title= "Task 2",
               Description= "Description of taks 2"
           },
           new Task
           {
               Id= 3,
               Title= "Task 3",
               Description= "Description of taks 3"
           },
            new Task
           {
               Id= 4,
               Title= "Task 4",
               Description= "Description of taks 4"
           },
             new Task
           {
               Id= 5,
               Title= "Task 5",
               Description= "Description of taks 4"
           }
        };

        

  
        [HttpGet]
        public ActionResult<IEnumerable<Task>> Get()
        {
            //return StatusCode(StatusCodes.Status200OK, "Hi :)");
            return Ok(_tasks);
            
        }

        [HttpGet("{id}")]
        public ActionResult<Task> Get(int id)
        {
            Task task = _tasks.FirstOrDefault(t => t.Id == id);
            if (null== task)
            {
                return NotFound($"Task with id: {id} not found");
            }

            return Ok(task);
        }
    }
}