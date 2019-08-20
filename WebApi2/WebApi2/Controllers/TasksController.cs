using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi2.Models;
using WebApi2.Services;
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


        private readonly TaskRepository repo;

        public TasksController(TaskRepository _repo)
        {
            repo = _repo;
        }
        // GET api/tasks
        [HttpGet]
        public ActionResult<List<Taskk>> Get()
        {
            
            return Ok(repo.GetAll());
        }

        //[HttpGet]
        //public ActionResult<IEnumerable<Taskk>> Get()
        //{
        //    //return StatusCode(StatusCodes.Status200OK, "Hi :)");
        //    return Ok(_tasks);
            
        //}

        [HttpGet("{id}")]
        public ActionResult<Taskk> Get(int id)
        {
            Taskk task = repo.GetTaskById(id);
            if (null== task)
            {
                return NotFound($"Task with id: {id} not found");
            }

            return Ok(task);
        }

        [HttpPost]
        public ActionResult<Taskk> Post([FromBody] Taskk newTask)
        {
            List<Taskk> tasks = repo.CreateTask(newTask);
            return Ok(tasks);
        }

        [HttpPut("{id}")]
        public ActionResult<Taskk> Put([FromBody] Taskk obj, int id)
        {
            Taskk task = repo.UpdateTask(id, obj);
            if(task == null)
            {
                return NotFound();
            }
            task.Title = obj.Title;
            task.Description = obj.Description;

            return Ok(task);
        }
        [HttpDelete("{id}")]
        public void Delete(int id)
        {

        }
    }
}