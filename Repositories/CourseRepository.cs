using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TodoApi.Contract;
using TodoApi.Data;
using TodoApi.Model.Response;

namespace TodoApi.Repositories
{
    public class CourseRepository : GenericRepository<Course>, ICourseRepository
    {
        private readonly StudentDBContext _context;
        
        public CourseRepository(StudentDBContext context) : base(context)
        {
            _context = context;
        }
        public async Task<Course> GetCourseDetails(int Id)
        {
            Console.WriteLine("The Id is: " + Id);
            var course = await _context.Courses.Include(c => c.Enrollments).ThenInclude(e => e.Student).FirstOrDefaultAsync(c => c.Id == Id);
            Console.WriteLine("The Course is: "+course.Tiltle);
            Console.WriteLine("The count is: "+course.Enrollments.Count);
            return await Task.FromResult(course);
        }
    }
}