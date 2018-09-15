﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Test
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }

        public int? SubjectId { get; set; }
        public Subject Subject { get; set; }
    }
}