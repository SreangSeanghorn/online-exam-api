using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApi.Data;

namespace TodoApi.Contract
{
    public interface IStudentRepository : IGenericRepository<Student>
    {
        Task<Student> GetStudentDetail(int studentId);
    }
}