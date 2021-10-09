using Microsoft.EntityFrameworkCore;
using BabyApp.Models;

namespace BabyApp
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        { }

        public DbSet<Pee> Pees { get; set;}
        public DbSet<Poo> Poos { get; set; }
    }
}