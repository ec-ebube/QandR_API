using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace qandr_api.Models
{
    public class Lecturer : IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Title { get; set; }
        public string? Gender { get; set; }
        public string? Marital_status { get; set; }
        public string? Role { get; set; } = "User";
        public DateTime Created_at { get; set; }
        public DateTime Updated_at { get; set; }
        public string? SearchString { get; set; }
        public List<Course>? Courses { get; set; }
        public List<Event>? Events {get;set;}
    }
}