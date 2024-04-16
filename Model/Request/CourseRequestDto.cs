using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApi.Model.Request
{
    public class CourseRequestDto
    {
        public string Tiltle { get; set; }
        public string Description { get; set; }
        public int Credit { get; set; }
    }
}