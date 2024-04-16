using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TodoApi.Contract;
using TodoApi.Data;
using TodoApi.Model;

namespace TodoApi.Controllers
{
    [ApiController]
    [Route("/api/student/")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepository IStudentRepository;
        public StudentController(IStudentRepository context)
        {
            IStudentRepository = context;
        }
        [HttpGet]
        public ActionResult<List<Student>> Get()
        {
            return IStudentRepository.GetAllAsync().Result.ToList();
        }
        [HttpGet("detail/{id}")]
        public ActionResult<Student> Get(int id)
        {
            return IStudentRepository.GetStudentDetail(id).Result;
        }

        [HttpPost]
        public ActionResult<Student> Post(StudentRequestDto student,IMapper mapper)
        {
            var studentModel = mapper.Map<Student>(student);
            IStudentRepository.AddAsync(studentModel);
            return studentModel;
        }
       
    }
}