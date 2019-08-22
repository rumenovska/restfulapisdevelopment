using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PhoneBook.Models;
using PhoneBook.Services;

namespace PhoneBook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhonebookController : ControllerBase
    {
        private readonly PhonebookRepository _repo;

        public PhonebookController(PhonebookRepository repo)
        {
            _repo = repo;
        }
        [HttpGet("{getusers}")]
        public ActionResult<User> GetUsers()
        {
            return Ok(_repo.GetAll<User>());
        }
    }
}