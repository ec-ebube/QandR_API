using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using qandr_api.Models;

namespace qandr_api.Collective
{
    public class CheckEmail
    {
        private readonly QandR_DBContext? _dbContext;
        public CheckEmail(QandR_DBContext? dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Boolean> checkStudentEmail(string email)
        {
            var exists = await _dbContext!.Students.FirstOrDefaultAsync(e => e.Email == email);
            if (exists == null)
            {
                return false;
            }
            return true;
        }

        public async Task<Boolean> checkLecturerEmail(string email, object model)
        {
            var exists = await _dbContext!.Lecturers.FirstOrDefaultAsync(e => e.Email == email);
            if (exists == null)
            {
                return false;
            }
            return true;
        }
    }
}