﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSTDotNetCoreTraining.ConsoleApp.Models
{
    public class BlogDataModel
    {
        public int BlogID { get; set; }
        public string BlogTitle { get; set; }
        public string BlogAuthor { get; set; }
        public string BlogContent { get; set; }
        public string DeleteFlag { get; set; }

    }
}
