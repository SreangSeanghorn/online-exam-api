using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApi.Data
{
    public class Enrollment
    {
        public int EnrollmentId { get; set; }
        public int CourseId { get; set; }
        public int StudentId { get; set; }
        [System.Text.Json.Serialization.JsonIgnore]
        public virtual Course Course { get; set; }
        [System.Text.Json.Serialization.JsonIgnore]
        public virtual Student Student { get; set; }
    }
}