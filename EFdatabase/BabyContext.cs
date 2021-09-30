using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using EFdatabase.Models;

namespace EFdatabase
{
    public class BabyContext : DbContext
    {
        public DbSet<Pee> Pee { get; set; }
        public DbSet<Poo> Poo { get; set; }

        public string DbPath { get; private set; }

        public BabyContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = $"{path}{System.IO.Path.DirectorySeparatorChar}baby.db";
        }

        // The following configures EF to create a Sqlite database file in the
        // special "local" folder for your platform.
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");
    }
}