using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TodoApi.Contract;
using TodoApi.Data;
using TodoApi.Model.Request;
using TodoApi.Model.Response;

namespace TodoApi.Controllers
{
    [ApiController]
    [Route("/api/course/")]
    public class CourseController : ControllerBase
    {
        
        private readonly ICourseRepository _repo;
        public CourseController(ICourseRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public ActionResult<List<Course>> Get()
        {
            return _repo.GetAllAsync().Result.ToList();
        }
        [HttpGet("{id}")]
        public ActionResult<Course> Get(int id)
        {
            return _repo.GetAsync(id).Result;
        }
        [HttpGet("search/{search}")]
        public ActionResult<List<Course>> Get(string search)
        {
            return _repo.GetAllAsync().Result.Where(x => x.Tiltle.Contains(search)).ToList();
        }
        [HttpGet("detail/{id}")]

        public ActionResult<CourseDetailResponseDto> GetCourseDetails(int id,IMapper mapper)
        {
            var course = _repo.GetCourseDetails(id).Result;
            return mapper.Map<CourseDetailResponseDto>(course);
        }
       

        [HttpPost]
        public ActionResult<Course> Post(CourseRequestDto courseRequestDto,IMapper mapper)
        {
            var course = mapper.Map<Course>(courseRequestDto);
            
            Console.WriteLine(course.Tiltle);
            _repo.AddAsync(course);
            return course;
        }
        [HttpPut("{id}")]
        public ActionResult<Course> Put(int id, CourseRequestDto courseRequestDto,IMapper mapper)
        {
            var course = _repo.GetAsync(id).Result;
            if (course == null)
            {
                return NotFound();
            }
            mapper.Map(courseRequestDto, course);
            _repo.UpdateAsync(course);
            return course;
        }
        [HttpDelete("{id}")]
        public ActionResult<Course> Delete(int id)
        {
            var course = _repo.GetAsync(id).Result;
            if (course == null)
            {
                return NotFound();
            }
            _repo.DeleteAsync(id);
            return course;
        }
        
    }
}