using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Taskk = WebApi2.Models.Taskk;

namespace WebApi2.Models
{
    public class ToDoDbContext : DbContext
    {
        public ToDoDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Taskk> Tasks { get; set; }
    }
}
