using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace qandr_api.Models
{
    public class Course
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