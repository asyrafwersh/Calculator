using Calculator.Classes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Calculator
{
    /// By : Asyraf Azahar
    //EntityFramework
    public class AppDbContext : DbContext
    {
        public AppDbContext()
            : base()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=Calculator.db");
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Data> Datas { get; set; }
    }
}
