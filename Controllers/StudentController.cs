using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using qandr_api.Collective;
using qandr_api.DTO;
using qandr_api.Models;
using qandr_api.Repo;

namespace qandr_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly IStudent? _istudent;
        private readonly CheckEmail? _checkEmail;

        public StudentController(IStudent istudent)
        {
            _istudent = istudent;
        }

        [HttpGet]
        public ActionResult getStudents()
        {
            try
            {
                var students = _istudent!.GetStudents();
                if (students.Result.ToList().Count == 0)
                {
                    throw new Exception("No student found in the db");
                }
                return Ok(students.Result);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("/getStudent/{id}")]
        public ActionResult singleStudent([FromRoute] string Id)
        {
            var student = _istudent!.GetStudent(Id);
            return Ok(student);
        }

        [HttpPost]
        public ActionResult createStudent([FromBody] Student_DTO newStudent, [FromRoute] string id)
        {
            const string A = "Email already exist";
            const string B = "Student Created";
            const string C = "Somthing went wrong";
            try
            {
                if (ModelState.IsValid)
                {
                    var student = _istudent!.CreateStudent(newStudent);
                    switch (student.Result)
                    {
                        case (A or C):
                            return Ok(student.Result);
                        case B:
                            return Ok(student.Result);
                        default:
                            return BadRequest(student.Result);
                    }

                    // if (student.Result == "Email already Exists")
                    // {
                    //     return BadRequest("Email already Exists");
                    // }
                    // if (student.Result == "Student Created")
                    // {
                    //     return Ok(student.Result);
                    // }
                    // return Ok(student.Result);

                }
                return BadRequest("Please fill all required feild");

            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("/updateStudent/{id}")]
        public ActionResult updateStudent([FromBody] Student_DTO newStudent, [FromRoute] string id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var student = _istudent!.UpdateStudent(id, newStudent);
                    return Ok(student);

                }
                return BadRequest("Please fill all required feild");

            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("/{id}/deleteStudent")]
        public ActionResult delStudent([FromRoute] string id)
        {
            try
            {
                var student = _istudent!.DeleteStudent(id);
                return Ok("Deleted");
            }
            catch (System.Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}