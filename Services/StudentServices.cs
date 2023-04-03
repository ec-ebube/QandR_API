using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using qandr_api.Collective;
using qandr_api.DTO;
using qandr_api.Models;
using qandr_api.Repo;

namespace qandr_api.Services
{
    public class StudentServices : IStudent
    {
        private readonly QandR_DBContext? _dbContext;
        private readonly CheckEmail? _checkEmail;
        public StudentServices(QandR_DBContext? dBContext, CheckEmail? checkEmail)
        {
            _dbContext = dBContext;
            _checkEmail = checkEmail;
        }
        public async Task<string> CreateStudent(Student_DTO student)
        {
            try
            {
                var emailExists = await _checkEmail!.checkStudentEmail(student.Email!);
                if (emailExists) /*or if (emailExist == true)*/
                {
                    return "Email already Exists";
                }
                var newStudent = new Student();
                newStudent.FirstName = student.FirstName;
                newStudent.LastName = student.LastName;
                newStudent.Email = student.Email;
                newStudent.Gender = student.Gender;
                newStudent.PhoneNumber = student.PhoneNumber;
                newStudent.RegNo = student.RegNo;
                newStudent.Created_at = DateTime.Now;
                newStudent.Updated_at = DateTime.Now;

                if (student.Role == null)
                {
                    newStudent.Role = "User";
                }
                else
                {
                    newStudent.Role = newStudent.Role;
                }

                var stu = await _dbContext!.Students.AddAsync(newStudent);
                if (stu == null)
                {
                    throw new Exception("Not Created");
                }
                await _dbContext!.Students.AddAsync(newStudent);
                _dbContext.SaveChanges();
                return "Student Created";
            }
            catch (System.Exception ex)
            {
                return ex.Message;
            }

        }

        public async Task<string> DeleteStudent(string id)
        {
            try
            {
                var student = await _dbContext!.Students.FindAsync(id);
                if (student == null)
                {
                    throw new Exception("No student found");
                }
                _dbContext!.Remove(student);
                return "Deleted Successfully";
            }
            catch (System.Exception ex)
            {
                return ex.Message;
            }
        }

        public Task<Student> GetStudent(string id)
        {
            try
            {
                var student = _dbContext!.Students.Where(s => s.Id == id).Include(se => se.Events).FirstAsync();
                if (student == null)
                {
                    return null!;
                }
                return student;
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
                var err = new { ex.Message };
                return null!;
            }
        }

        public async Task<IEnumerable<Student>> GetStudents()
        {
            try
            {
                var students = await _dbContext!.Students.OrderBy(x => x.FirstName).Include(e => e.Events).ToListAsync();
                if (students.Count == 0)
                {
                    return null!;
                }
                return students;
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
                var errList = new List<Student>();
                return errList;
            }
        }

        public async Task<Student> UpdateStudent(string id, Student_DTO student)
        {
            try
            {
                var editStudent = await _dbContext!.Students.FindAsync(id);
                if (editStudent == null)
                {
                    return null!;
                }
                editStudent.FirstName = student.FirstName;
                editStudent.LastName = student.LastName;
                editStudent.Email = student.Email;
                editStudent.Gender = student.Gender;
                editStudent.PhoneNumber = student.PhoneNumber;
                editStudent.RegNo = student.RegNo;
                editStudent.Updated_at = DateTime.Now;
                editStudent.Role = student.Role;
                _dbContext.Students.Attach(editStudent);
                _dbContext.SaveChanges();
                return editStudent;
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null!;
            }
        }
    }
}