using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using qandr_api.DTO;
using qandr_api.Models;

namespace qandr_api.Repo
{
    public interface ICourse
    {
        public Task<IEnumerable<Course>> GetCourse();
        public Task<Course> GetCourse(string id);
        public Task<Course> UpdateCourse(String id, Courses_DTO course);
        public void DeleteCourse(string id);
        public Task<Course> CreateCourse(Courses_DTO course);
    }
}