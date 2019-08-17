using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using User = WebApi2.Models.User;

namespace WebApi2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private static List<User> _users = new List<User>
        {
            new User
            {
                Id= 1,
                FirstName= "Marija",
                LastName= "Rmenovska",
                Age= 23
                
            },

            new User
            {
                Id= 2,
                FirstName= "Frosina",
                LastName= "Rmenovska",
                Age= 19

            },
            new User
            {
                Id= 3,
                FirstName= "Simona",
                LastName= "Zelovska",
                Age=16

            }

        };

        [HttpGet]
        public ActionResult<IEnumerable<Task>> Get()
        {
           
            return Ok(_users);

        }

        [HttpGet("{id}")]
        public ActionResult<Task> Get(int id)
        {
            User user = _users.FirstOrDefault(u => u.Id == id);
            if(null== user)
            {
                return NotFound($"User with id: {id} not found");
            }
            return Ok(user);

          }

        //[HttpGet("{id}/isadult")]
        //public ActionResult<bool> IsAdult(int id)
        //{
        //    User user = _users.FirstOrDefault(u => u.Id == id);
        //    if (user != null && user.Age != null)
        //    {
        //        if (user.Age >= 18)
        //        {
        //            return true;
        //        }
        //    }

        //    return false;
        //}



    }
}