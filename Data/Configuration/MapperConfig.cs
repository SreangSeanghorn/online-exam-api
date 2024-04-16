using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using TodoApi.Model;
using TodoApi.Model.Request;
using TodoApi.Model.Response;

namespace TodoApi.Data.Configuration
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
           CreateMap<Course, CourseRequestDto>().ReverseMap();
           CreateMap<Enrollment, EnrollmentRequestDto>().ReverseMap();
           CreateMap<Student, StudentRequestDto>().ReverseMap();
           CreateMap<Student, StudentResponseDto>().ReverseMap();
           CreateMap<Course, CourseDetailResponseDto>()
                .ForMember(dest => dest.Students, 
                opt => opt.MapFrom(src => src.Enrollments.Select(e => e.Student)));
        }
    }
    
}