using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApi.Data;

namespace TodoApi.Model.Response
{
    public class StudentResponseDto
    {
        public string StudentId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string imageUrl { get; set; }
        [System.Text.Json.Serialization.JsonIgnore]
        public virtual ICollection<Enrollment> Enrollments { get; set; }
        [System.Text.Json.Serialization.JsonIgnore]
        private ICollection<Course> Courses { get; set; }
        //public ICollection<CourseDetailResponseDto> Courses { get; set; }
    }
}