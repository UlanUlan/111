using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Models
{
    public class TestsListViewModel
    {
        public IEnumerable<Test> Tests { get; set; }
        public SelectList Statuses { get; set; }
    }
}