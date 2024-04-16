using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApi.Data
{
    public class Course : BaseEntity
    {
        public string Tiltle { get; set; }
        public string Description { get; set; }
        public int Credits { get; set; }
        public virtual ICollection<Student> Students { get; set; }
       // [System.Text.Json.Serialization.JsonIgnore]
        public virtual ICollection<Enrollment> Enrollments { get; set; }
        
    }
}