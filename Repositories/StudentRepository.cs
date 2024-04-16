using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TodoApi.Data;
using TodoApi.Contract;
namespace TodoApi.Repositories
{
    public class StudentRepository : GenericRepository<Student>, IStudentRepository
    {
        private readonly StudentDBContext _context;
        public StudentRepository(StudentDBContext context) : base(context)
        {
            _context = context;
        }


        public async Task<Student> GetStudentDetail(int studentId)
        {
            return Task.FromResult(_context.Students.Include(e => e.Enrollments)
            .ThenInclude(e => e.Course).FirstOrDefault(e => e.Id == studentId)).Result;
        }
    }
}