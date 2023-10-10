using Jungle_Models.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jungle_DataAccess.Data
{
    public class JungleDbContext : DbContext
    {
        public JungleDbContext()
        {

        }

        public JungleDbContext(DbContextOptions<JungleDbContext> options) : base(options)

        {

        }

        public DbSet<Country>? Country { get; set; }
        public DbSet<Destination>? Destination { get; set; }
        public DbSet<Guide>? Guide { get; set; }
        public DbSet<Travel>? Travel { get; set; }
        public DbSet<TravelRecommendation>? TravelRecommendation { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=LLBINFD060402\\SQLEXPRESS;Database=Jungle;Trusted_Connection=True;MultipleActiveResultSets=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<Type>();

        }
    }
}
