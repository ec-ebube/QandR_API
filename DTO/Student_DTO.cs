using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using qandr_api.Models;

namespace qandr_api.DTO
{
    public class Student_DTO
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Gender { get; set; }
        public string? RegNo { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? Role { get; set; }
        public string? Password { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime Updated_at { get; set; }
    }
}