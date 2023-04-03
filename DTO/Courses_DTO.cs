using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using qandr_api.Models;

namespace qandr_api.DTO
{
    public class Courses_DTO
    {
        public Guid id { get; set; }
        public string? Course_code { get; set; }
        public string? Course_title { get; set; }
        public string? Level { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime Updated_at { get; set; }
        public string? LecturerId { get; set; }
        public Lecturer? Lecturer { get; set; }
    }
}