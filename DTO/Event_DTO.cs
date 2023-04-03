using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using qandr_api.Models;

namespace qandr_api.DTO
{
    public class Event_DTO
    {
        public Guid id { get; set; }
        public string? Type { get; set; }
        public string? Description { get; set; }
        public string? Course_code { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime Updated_at { get; set; }
        public string? StudentId { get; set; }
        public string? LecturerId { get; set; }
        public Lecturer? Lecturer { get; set; }
        public Student? Student { get; set; }
    }
}