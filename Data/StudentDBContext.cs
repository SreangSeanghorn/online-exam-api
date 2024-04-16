using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace TodoApi.Data
{
    public class StudentDBContext : IdentityDbContext<Users>
    {
      public StudentDBContext(DbContextOptions<StudentDBContext> options) : base(options)
      {
        
      }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }  
      
      protected override void OnModelCreating(ModelBuilder modelBuilder){ 
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new Configuration.CourseConfiguation());
        modelBuilder.ApplyConfiguration(new Configuration.UserRoleConfiguration());
        modelBuilder.ApplyConfiguration(new Configuration.RoleConfiguration());
        modelBuilder.ApplyConfiguration(new Configuration.UserConfiguration());
      }

    }
}