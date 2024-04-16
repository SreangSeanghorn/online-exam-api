using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApi.Data;

namespace TodoApi.Model
{
    public class StudentRequestDto : BaseEntity
    {
        public string StudentId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string imageUrl { get; set; }
        public string Password { get; set; }
        
    }
}