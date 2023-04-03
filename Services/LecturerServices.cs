using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using qandr_api.DTO;
using qandr_api.Models;
using qandr_api.Repo;

namespace qandr_api.Services
{
    public class LecturerServices : ILecturer
    {
        private readonly QandR_DBContext? _dbContext;
        public LecturerServices(QandR_DBContext? dBContext)
        {
            _dbContext = dBContext;
        }

        // public LecturerServices()
        // {
        // }

        public async Task<string> CreateLecturer(Lecturer_DTO lecturer)
        {
            var newLecturer = new Lecturer();
            newLecturer.FirstName = lecturer.FirstName;
            newLecturer.LastName = lecturer.LastName;
            newLecturer.Gender = lecturer.Gender;
            newLecturer.Marital_status = lecturer.Marital_status;
            newLecturer.Title = lecturer.Title;
            newLecturer.Created_at = DateTime.Now;
            newLecturer.Updated_at = DateTime.Now;

            if (lecturer.Role == null)
            {
                newLecturer.Role = "User";
            }
            else
            {
                newLecturer.Role = newLecturer.Role;
            }

            var lec = await _dbContext!.Lecturers.AddAsync(newLecturer);
            if (lec == null)
            {
                throw new Exception("Not Created");
            }
            await _dbContext!.Lecturers.AddAsync(newLecturer);
            _dbContext.SaveChanges();
            return "New Student Created";
        }

        public async Task<string> DeleteLecturer(string id)
        {
            try
            {
                var lecturer = await _dbContext!.Lecturers.FindAsync(id);
                if (lecturer == null)
                {
                    throw new Exception("No lecturer found");
                }
                _dbContext!.Remove(lecturer);
                return "Deleted Successfully";
            }
            catch (System.Exception ex)
            {
                return ex.Message;
            }
        }

        public async Task<IEnumerable<Lecturer>> GetLecturers()
        {
            try
            {
                var lecturers = await _dbContext!.Lecturers.Include(e => e.Events).ToListAsync();
                if (lecturers == null)
                {
                    return Enumerable.Empty<Lecturer>();
                }
                return lecturers;
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
                var errList = new List<Lecturer>();
                return errList;
            }
        }

        public Task<Lecturer> GetLecturer(string id)
        {
            try
            {
                var lecturer = _dbContext!.Lecturers.Where(l => l.Id == id).Include(se => se.Events).FirstAsync();
                if (lecturer == null)
                {
                    return null!;
                }
                return lecturer;
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
                var err = new { ex.Message };
                return null!;
            }
        }



        public async Task<string> UpdateLecturer(string id, Lecturer_DTO lecturer)
        {
            try
            {
                var editLecturer = await _dbContext!.Lecturers.FindAsync(id);
                if (editLecturer == null)
                {
                    return "null!";
                }
                editLecturer.FirstName = lecturer.FirstName;
                editLecturer.LastName = lecturer.LastName;
                editLecturer.Gender = lecturer.Gender;
                editLecturer.Marital_status = lecturer.Marital_status;
                editLecturer.Title = lecturer.Title;
                editLecturer.Created_at = DateTime.Now;
                editLecturer.Updated_at = DateTime.Now;
                _dbContext.Lecturers.Attach(editLecturer);
                _dbContext.SaveChanges();
                return "Lecturer Edited";
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
                return "null!";
            }
        }
    }
}