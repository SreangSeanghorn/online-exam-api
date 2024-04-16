using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace TodoApi.Data
{
    public class Users : IdentityUser
    {
        public string Fullname { get; set; }
        public DateTime DateOfBirth { get; set; }
        
    }
}