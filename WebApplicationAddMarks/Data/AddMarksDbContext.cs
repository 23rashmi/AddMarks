using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplicationAddMarks.Models;

namespace WebApplicationAddMarks.Data
{
    public class AddMarksDbContext : DbContext
    {
        public AddMarksDbContext (DbContextOptions<AddMarksDbContext> options)
            : base(options)
        {
        }

        public DbSet<WebApplicationAddMarks.Models.Marks> Mark { get; set; } = default!;
    }
}
