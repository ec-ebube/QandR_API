using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using qandr_api.DTO;
using qandr_api.Models;

namespace qandr_api.Repo
{
    public interface ILecturer
    {
        public Task<IEnumerable<Lecturer>> GetLecturers();
        public Task<Lecturer> GetLecturer(string id);
        public Task<string> UpdateLecturer(string id, Lecturer_DTO lecturer);
        public Task<string> DeleteLecturer(string id);
        public Task<string> CreateLecturer(Lecturer_DTO lecturer);
        // object Updatelecturer(string id, Lecturer_DTO newlecturer);
    }
}