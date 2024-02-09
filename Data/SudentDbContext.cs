using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebAppStudentDatabase.Models;

namespace WebAppStudentDatabase.Data
{
    public class SudentDbContext : DbContext
    {
        public SudentDbContext (DbContextOptions<SudentDbContext> options)
            : base(options)
        {
        }

        public DbSet<WebAppStudentDatabase.Models.StudentMark> StudentMark { get; set; } = default!;
    }
}
