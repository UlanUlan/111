using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Subject
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Test> Tests { get; set; }
        public Subject()
        {
            Tests = new List<Test>();
        }
    }
}