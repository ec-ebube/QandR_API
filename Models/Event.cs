using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace qandr_api.Models
{
    public class Event
    {
        public Guid id { get; set; }
        public string? Id { get; internal set; }
        public string? Type { get; set; }
        public string? Description { get; set; }
        public string? Course_code { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime Updated_at { get; set; }
        public string? StudentId { get; set; }
        public string? LecturerId { get; set; }
        public Lecturer? Lecturer { get; set; }
        public Student? Student { get; set; }
        public object? Events { get; internal set; }
    }
}