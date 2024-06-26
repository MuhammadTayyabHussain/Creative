﻿using CreativeWeb.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace CreativeWeb.Controllers.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
            
        }

        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Action", DisplyOrder = 1 },
                new Category { Id = 2, Name = "Sci-Fiction", DisplyOrder = 2 },
                new Category { Id = 3, Name = "History", DisplyOrder = 3 },
                new Category { Id = 4, Name = "Adventure", DisplyOrder = 4 }
                );
        }

    }
}
