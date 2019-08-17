using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi2.Models;
using Taskk = WebApi2.Models.Taskk;

namespace WebApi2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {

        private static List<Taskk> _tasks = new List<Taskk>
        {
           new Taskk
           {
               Id= 1,
               Title= "Task 1",
               Description= "Description of taks 1"
           },
           new Taskk
           {
               Id= 2,
               Title= "Task 2",
               Description= "Description of taks 2"
           },
           new Taskk
           {
               Id= 3,
               Title= "Task 3",
               Description= "Description of taks 3"
           },
            new Taskk
           {
               Id= 4,
               Title= "Task 4",
               Description= "Description of taks 4"
           },
             new Taskk
           {
               Id= 5,
               Title= "Task 5",
               Description= "Description of taks 4"
           }
        };

        

  
        [HttpGet]
        public ActionResult<IEnumerable<Taskk>> Get()
        {
            //return StatusCode(StatusCodes.Status200OK, "Hi :)");
            return Ok(_tasks);
            
        }

        [HttpGet("{id}")]
        public ActionResult<Taskk> Get(int id)
        {
            Taskk task = _tasks.FirstOrDefault(t => t.Id == id);
            if (null== task)
            {
                return NotFound($"Task with id: {id} not found");
            }

            return Ok(task);
        }

        [HttpPost]
        public ActionResult<string> Post([FromBody] Taskk obj)
        {
            Taskk newTask = new Taskk
            {
                Id = _tasks.Count() + 1,
                Title= obj.Title,
                Description= obj.Description
                
            };
            _tasks.Add(newTask);
            return Ok(newTask);
        }

        [HttpPut("{id}")]
        public ActionResult<string> Put([FromBody] Taskk obj, int id)
        {
            Taskk task = _tasks.FirstOrDefault(t => t.Id == id);
            if(task == null)
            {
                return NotFound();
            }
            task.Title = obj.Title;
            task.Description = obj.Description;

            return Ok(task);
        }

    }
}