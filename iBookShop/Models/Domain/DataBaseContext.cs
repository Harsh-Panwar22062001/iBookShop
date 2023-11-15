﻿using Microsoft.EntityFrameworkCore;

namespace iBookShop.Models.Domain
{
    public class DatabaseContext:DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options):base(options)
        {
            
        }

        public DbSet<Genre> Genre { get; set; }


        public DbSet<Author> Author { get; set; }
        public DbSet<Publisher> Publisher{ get; set; }
    }
}
