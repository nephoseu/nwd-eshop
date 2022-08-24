using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using LegacyApp.Models;
namespace LegacyApp.DataContext
{
    class ApplicationDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("<CONNECTION_STRING_FOR_LEGACY_DB>");
        }
        public DbSet<Order> Orders { get; set; }

        
    }
}

