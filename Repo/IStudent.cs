using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using qandr_api.DTO;
using qandr_api.Models;

namespace qandr_api.Repo
{
    public interface IStudent
    {
        public Task<IEnumerable<Student>> GetStudents();
        public Task<Student> GetStudent(string id);
        public Task<Student> UpdateStudent(string id, Student_DTO student);
        public Task<string> DeleteStudent(string id);
        public Task<string> CreateStudent(Student_DTO student);
    }
}