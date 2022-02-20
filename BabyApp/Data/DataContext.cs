using Microsoft.EntityFrameworkCore;
using BabyApp.Models;

namespace BabyApp
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        { }

        public DbSet<Ninni> ninnis { get; set;}
        public DbSet<PosSD2> posSD2s { get; set; }
    }
}