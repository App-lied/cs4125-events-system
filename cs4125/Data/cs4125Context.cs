using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using cs4125.Models;

namespace cs4125.Data
{
    public class cs4125Context : DbContext
    {
        public cs4125Context (DbContextOptions<cs4125Context> options)
            : base(options)
        {
        }

        public DbSet<cs4125.Models.Event> Event { get; set; } = default!;
    }
}
