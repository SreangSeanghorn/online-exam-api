using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApi.Data;
using TodoApi.Model.Request;

namespace TodoApi.Controllers
{
   [ApiController]
   [Route("/api/enrollment/")]
    public class EnrollmentController : ControllerBase
    {
        private readonly StudentDBContext _context;
        public EnrollmentController(StudentDBContext context)
        {
            _context = context;
        }
        [HttpGet]
        public ActionResult<List<Enrollment>> Get()
        {
            return _context.Enrollments.Include(enr=>enr.Course).Where(enr=>enr.Course.Tiltle.Contains("a")).Take(1)
            .Include(stu=>stu.Student)
            .ToList();
        }


        [HttpPost]
        public ActionResult<Enrollment> Post(EnrollmentRequestDto enrollmentRequestDto,IMapper mapper)
        {
            var enrollment = mapper.Map<Enrollment>(enrollmentRequestDto);
            _context.Enrollments.Add(enrollment);
            _context.SaveChanges();
            return enrollment;
        }
      
    }
}