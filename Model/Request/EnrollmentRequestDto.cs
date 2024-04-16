using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApi.Model.Request
{
    public class EnrollmentRequestDto
    {
        public int CourseId { get; set; }
        public int StudentId { get; set; }
    }
}