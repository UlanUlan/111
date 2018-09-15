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

   public class TasksDbInitializer : DropCreateDatabaseAlways<TasksContext>
    {
        protected override void Seed(TasksContext db)
        {
            Subject s1 = new Subject() { Name = "Математика" };
            Subject s2 = new Subject() { Name = "Биология" };
            Subject s3 = new Subject() { Name = "Физика" };

            db.Subjects.AddRange(new List<Subject> { s1, s2, s3 });

            db.SaveChanges();

            Test t1 = new Test() { Name = "Задание 1", Status = false, Subject=s1 };
            Test t2 = new Test() { Name = "Задание 2", Status = false, Subject = s2 };
            Test t3 = new Test() { Name = "Задание 3", Status = false, Subject = s1 };
            Test t4 = new Test() { Name = "Задание 4", Status = true, Subject = s3 };
            Test t5 = new Test() { Name = "Задание 5", Status = false, Subject = s2 };

            db.Tests.AddRange(new List<Test> { t1, t2, t3, t4, t5 });

            db.SaveChanges();


        }
    }
}