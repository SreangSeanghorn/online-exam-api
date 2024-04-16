using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TodoApi.Data.Configuration
{
    public class CourseConfiguation : IEntityTypeConfiguration<Course>
    {

        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.HasData(
                new Course
                {
                    Id = 1,
                    Tiltle = "Java",
                    Description = "Java Programming",
                    Credits = 4
                },
                new Course
                {
                   Id = 2,
                    Tiltle = "React",
                    Description = "React Programming",
                    Credits = 4
                },
                new Course
                {
                    Id = 3,
                    Tiltle = "C#",
                    Description = "C# Programming",
                    Credits = 4
                }
            );
        }
    }
}