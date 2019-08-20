using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi2.Models;

namespace WebApi2.Services
{
    public class TaskRepository
    {
        private readonly ToDoDbContext db;

        public TaskRepository(ToDoDbContext context)
        {
            db = context;
        }

        public List<Taskk> GetAll()
        {
            return db.Tasks.ToList();
        }

        public Taskk GetTaskById(int id)
        {
            Taskk task = db.Tasks.FirstOrDefault(t => t.Id == id);
            return task;
           
        }

        public List<Taskk> CreateTask(Taskk newTask)
        {
            db.Tasks.Add(newTask);
            db.SaveChanges();
            return GetAll();
        }

        public Taskk UpdateTask(int id, Taskk updatedTask)
        {
            Taskk task = GetTaskById(id);
            
            if(task == null)
            {
                return null;
            }
            task.Title = updatedTask.Title;
            task.Description = updatedTask.Description;
            task.IsComplete = updatedTask.IsComplete;
            db.Tasks.Update(task);
            db.SaveChanges();

            return GetTaskById(id);
        }

        
    }
}
