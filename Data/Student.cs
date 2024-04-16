using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApi.Data
{
    public class Student : BaseEntity
    {
        public string StudentId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string imageUrl { get; set; }
    
        public virtual ICollection<Enrollment> Enrollments { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
    }
}