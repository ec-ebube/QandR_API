using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace qandr_api.Models
{
    public class QandR_DBContext : DbContext
    {
        public QandR_DBContext(DbContextOptions<QandR_DBContext> options) : base(options)
        {

        }
        public DbSet<Student> Students { get; set; } = null!;
        public DbSet<Course> Courses { get; set; } = null!;
        public DbSet<Lecturer> Lecturers { get; set; } = null!;
        public DbSet<Event> Events { get; set; } = null!;
    }
}