using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApi.Data;
using TodoApi.Model.Response;

namespace TodoApi.Contract
{
    public interface ICourseRepository : IGenericRepository<Course>
    {
        Task<Course> GetCourseDetails(int courseId);
    }
}