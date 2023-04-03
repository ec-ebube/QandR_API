using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using qandr_api.Models;

namespace qandr_api.DTO
{
    public class Lecturer_DTO
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Title { get; set; }
        public string? Gender { get; set; }
        public string? Marital_status { get; set; }
        public string? Role { get; set; }
        public DateTime Craeted_at { get; set; }
        public DateTime Updated_at { get; set; }
    }
}