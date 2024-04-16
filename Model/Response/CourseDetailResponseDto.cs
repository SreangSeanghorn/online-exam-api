using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApi.Data;
using TodoApi.Model.Response; // Add this line

namespace TodoApi.Model.Response
{
    public class CourseDetailResponseDto
    {
        public string Tiltle { get; set; }
        public string Description { get; set; }
        public int Credit { get; set; }
        public ICollection<StudentResponseDto> Students { get; set; }
    }
}