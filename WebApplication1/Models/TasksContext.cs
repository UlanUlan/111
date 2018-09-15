using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class TasksContext : DbContext
    {
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Test> Tests { get; set; }
    }
}