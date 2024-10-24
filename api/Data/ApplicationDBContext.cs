using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Data
{
    public class ApplicationDBContext(DbContextOptions<ApplicationDBContext> dbContextOptions) : DbContext(dbContextOptions)
    {
        public required DbSet<Stock> Stocks { get; set; }
        public required DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Add any custom configurations here
        }
    }
}