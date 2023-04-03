using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using qandr_api.DTO;
using qandr_api.Repo;

namespace qandr_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LecturerController : ControllerBase
    {
        private readonly ILecturer? _ilecturer;

        public LecturerController(ILecturer ilecturer)
        {
            _ilecturer = ilecturer;
        }

        [HttpGet]
        public ActionResult getLecturers()
        {
            var lecturer = _ilecturer!.GetLecturers();
            return Ok(lecturer);
        }

        [HttpGet("/getLecturer/{id}")]
        public ActionResult SingleLecturer([FromRoute] string Id)
        {
            var lecturer = _ilecturer!.GetLecturer(Id);
            return Ok(lecturer);
        }

        [HttpPost]
        public ActionResult createLecturer([FromBody] Lecturer_DTO newLecturer, [FromRoute] string id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var lecturer = _ilecturer!.CreateLecturer(newLecturer);
                    return Ok(lecturer);

                }
                return BadRequest("Please fill all required feild");

            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("/updateLecturer/{id}")]
        public ActionResult updatelecturer([FromBody] Lecturer_DTO newLecturer, [FromRoute] string id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var lecturer = _ilecturer!.UpdateLecturer(id, newLecturer);
                    return Ok(lecturer);

                }
                return BadRequest("Please fill all required feild");

            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("/{id}/deleteLecturer")]
        public ActionResult deleteStudent([FromRoute] string id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var lecturer = _ilecturer!.DeleteLecturer(id);
                    return Ok("Deleted");
                }
                return BadRequest("Couldn't find a matching id");
            }
            catch (System.Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}